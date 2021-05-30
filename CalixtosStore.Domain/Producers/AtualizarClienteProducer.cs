using CalixtosStore.Domain.Events;

namespace CalixtosStore.Domain.Producers
{
    public class AtualizarClienteProducer : Producer<AtualizarClienteEvent>
    {
        public AtualizarClienteProducer() : base("atualizar-cliente")
        {
        }
    }
}