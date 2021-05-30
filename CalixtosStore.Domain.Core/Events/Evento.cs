using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalixtosStore.Domain.Core.Events
{
    public abstract class Evento : Mensagem, INotification
    {
        public DateTime Timestamp { get; private set; }

        protected Evento()
        {
            Timestamp = DateTime.Now;
        }
    }
}