using CalixtosStore.Domain.Core.Events;
using Confluent.Kafka;
using Newtonsoft.Json;
using Serilog;
using Serilog.Core;
using Serilog.Sinks.SystemConsole.Themes;
using System;

namespace CalixtosStore.Domain.Producers
{
    public abstract class Producer<T> : IProducer<T> where T : Mensagem
    {
        protected Producer(string topico)
        {
            Topico = topico;
        }

        public void SendMensage(T mensagem)
        {
            Logger logger = ObterLogger();

            logger.Information("Iniciando envio da mensagem");

            var config = ObterConfiguracao();

            var producerMessage = new Message<Null, string>();
            producerMessage.Value = JsonConvert.SerializeObject(mensagem);

            using (var producer = new ProducerBuilder<Null, string>(config).Build())
            {
                producer.Produce(
                        Topico,
                        producerMessage,
                        ErrorHandler());
            }
        }

        private Logger ObterLogger()
        {
            return new LoggerConfiguration()
                .WriteTo.Console(theme: AnsiConsoleTheme.Literate)
                .CreateLogger();
        }

        private ProducerConfig ObterConfiguracao()
        {
            return new ProducerConfig
            {
                BootstrapServers = "localhost:9092",
                Partitioner = Partitioner.Murmur2,
                EnableDeliveryReports = true,
                Acks = Acks.Leader
            };
        }

        private Action<DeliveryReport<Null, string>> ErrorHandler()
        {
            return r =>
            Log.Information(!r.Error.IsError
                ? $"Mensagem entre em: {r.TopicPartitionOffset}"
                : $"Erro ao entregar a mensagem: {r.Error.Reason}");
        }

        public string Topico { get; private set; }
    }
}