namespace CalixtosStore.Domain.Commands.Validations
{
    public class RemoverClienteCommandValidation : ClienteValidation<RemoverClienteCommand>
    {
        public RemoverClienteCommandValidation()
        {
            ValidarId();
        }
    }
}