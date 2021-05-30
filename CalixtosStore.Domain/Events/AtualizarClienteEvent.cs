using CalixtosStore.Domain.Core.Events;
using System;

namespace CalixtosStore.Domain.Events
{
    public class AtualizarClienteEvent : Evento
    {
        public AtualizarClienteEvent(Guid id, string nome, string email, DateTime dataNascimento)
        {
            Nome = nome;
            Email = email;
            DataDeNascimento = dataNascimento;
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataDeNascimento { get; set; }
    }
}