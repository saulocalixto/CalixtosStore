namespace CalixtosStore.Domain.Commands.Validations
{
    public class RegistrarNovoClienteCommandValidation : ClienteValidation<RegistrarNovoClienteCommand>
    {
        public RegistrarNovoClienteCommandValidation()
        {
            ValidarNome();
            ValidarDataDeNascimento();
            ValidarEmail();
        }
    }
}