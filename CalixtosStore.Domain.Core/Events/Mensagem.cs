using MediatR;
using System;

namespace CalixtosStore.Domain.Core.Events
{
    public abstract class Mensagem : IRequest<bool>
    {
        public string MessageType { get; protected set; }
        public Guid AggregateId { get; protected set; }

        protected Mensagem()
        {
            MessageType = GetType().Name;
        }
    }
}