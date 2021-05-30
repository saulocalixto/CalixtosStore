namespace CalixtosStore.Domain.Commands.Validations
{
    public class AtualizarClienteCommandValidation : ClienteValidation<AtualizarClienteCommand>
    {
        public AtualizarClienteCommandValidation()
        {
            ValidarId();
            ValidarEmail();
            ValidarNome();
            ValidarDataDeNascimento();
        }
    }
}