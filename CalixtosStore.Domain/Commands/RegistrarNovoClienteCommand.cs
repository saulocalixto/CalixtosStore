using CalixtosStore.Domain.Commands.Validations;
using System;

namespace CalixtosStore.Domain.Commands
{
    public class RegistrarNovoClienteCommand : ClienteCommand
    {
        public RegistrarNovoClienteCommand(string nome, string email, DateTime dataNascimento)
        {
            Nome = nome;
            Email = email;
            DataDeNascimento = dataNascimento;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegistrarNovoClienteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}