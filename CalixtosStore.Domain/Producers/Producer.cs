using CalixtosStore.Domain.Core.Events;
using Confluent.Kafka;
using Confluent.Kafka.Admin;
using Newtonsoft.Json;
using Serilog;
using Serilog.Core;
using Serilog.Sinks.SystemConsole.Themes;
using System;
using System.Linq;

namespace CalixtosStore.Domain.Producers
{
    public abstract class Producer<T> : IProducer<T> where T : Mensagem
    {
        private readonly string _bootstrapServer = "localhost:9092";

        protected Producer(string topico)
        {
            Topico = topico;
        }

        public void SendMensage(T mensagem)
        {
            Logger logger = GetLogger();

            logger.Information("Iniciando envio da mensagem");

            var config = GetConfiguration();

            var producerMessage = new Message<Null, string>();
            producerMessage.Value = JsonConvert.SerializeObject(mensagem);

            CreateTopic();

            using (var producer = new ProducerBuilder<Null, string>(config).Build())
            {
                producer.Produce(
                        Topico,
                        producerMessage,
                        ErrorHandler());
            }
        }

        /// <summary>
        /// Vai criar um tópico com 3 partições sem replicação de partições.
        /// </summary>
        private void CreateTopic()
        {
            using (var adminClient = new AdminClientBuilder(new AdminClientConfig { BootstrapServers = _bootstrapServer }).Build())
            {
                try
                {
                    if (TopicNotFound(adminClient))
                    {
                        adminClient.CreateTopicsAsync(
                        new TopicSpecification[]
                        {
                            new TopicSpecification { Name = Topico, ReplicationFactor = 1, NumPartitions = 3 }
                        }).Wait();
                    }
                }
                catch (CreateTopicsException e)
                {
                    Console.WriteLine($"Ocorreu um erro ao criar o tópico: {e.Results[0].Topic}: {e.Results[0].Error.Reason}");
                }
            }
        }

        private bool TopicNotFound(IAdminClient adminClient)
        {
            return !adminClient.GetMetadata(TimeSpan.FromSeconds(20)).Topics.Any(x => x.Topic == Topico);
        }

        private Logger GetLogger()
        {
            return new LoggerConfiguration()
                .WriteTo.Console(theme: AnsiConsoleTheme.Literate)
                .CreateLogger();
        }

        private ProducerConfig GetConfiguration()
        {
            return new ProducerConfig
            {
                BootstrapServers = _bootstrapServer,
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