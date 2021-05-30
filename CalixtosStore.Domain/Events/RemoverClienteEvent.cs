using CalixtosStore.Domain.Core.Events;
using System;

namespace CalixtosStore.Domain.Events
{
    public class RemoverClienteEvent : Evento
    {
        public RemoverClienteEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}