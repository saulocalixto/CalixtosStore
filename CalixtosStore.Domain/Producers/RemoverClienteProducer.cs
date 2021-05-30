using CalixtosStore.Domain.Events;

namespace CalixtosStore.Domain.Producers
{
    public class RemoverClienteProducer : Producer<RemoverClienteEvent>
    {
        public RemoverClienteProducer() : base("remover-cliente")
        {
        }
    }
}