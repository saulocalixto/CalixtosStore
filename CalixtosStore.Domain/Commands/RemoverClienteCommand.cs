using CalixtosStore.Domain.Commands.Validations;
using System;

namespace CalixtosStore.Domain.Commands
{
    public class RemoverClienteCommand : ClienteCommand
    {
        public RemoverClienteCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoverClienteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}