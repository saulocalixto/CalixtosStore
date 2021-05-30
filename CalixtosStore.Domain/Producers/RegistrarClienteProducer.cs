using CalixtosStore.Domain.Events;

namespace CalixtosStore.Domain.Producers
{
    public class RegistrarClienteProducer : Producer<RegistrarNovoClienteEvent>
    {
        public RegistrarClienteProducer() : base("registrar-cliente")
        {
        }
    }
}