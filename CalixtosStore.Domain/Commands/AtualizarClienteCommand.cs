using CalixtosStore.Domain.Commands.Validations;
using System;

namespace CalixtosStore.Domain.Commands
{
    public class AtualizarClienteCommand : ClienteCommand
    {
        public AtualizarClienteCommand(Guid id, string nome, string email, DateTime dataNascimento)
        {
            Nome = nome;
            Email = email;
            DataDeNascimento = dataNascimento;
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new AtualizarClienteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}