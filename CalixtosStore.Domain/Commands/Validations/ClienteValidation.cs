using FluentValidation;
using System;

namespace CalixtosStore.Domain.Commands.Validations
{
    public class ClienteValidation<T> : AbstractValidator<T> where T : ClienteCommand
    {
        protected void ValidarNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome deve ser preenchido.")
                .Length(2, 60).WithMessage("O nome deve ter entre 2 e 60 caracteres.");
        }

        protected void ValidarDataDeNascimento()
        {
            RuleFor(c => c.DataDeNascimento)
                .NotEmpty()
                .Must(EMaiorDeIdade)
                .WithMessage("O cliente deve ter mais de 18 anos.");
        }

        protected void ValidarEmail()
        {
            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();
        }

        protected void ValidarId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected static bool EMaiorDeIdade(DateTime birthDate)
        {
            return birthDate <= DateTime.Now.AddYears(-18);
        }
    }
}