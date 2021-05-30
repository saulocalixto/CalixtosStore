using CalixtosStore.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalixtosStore.Domain.Events
{
    public class RegistrarNovoClienteEvent : Evento
    {
        public RegistrarNovoClienteEvent(Guid id, string nome, string email, DateTime dataNascimento)
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