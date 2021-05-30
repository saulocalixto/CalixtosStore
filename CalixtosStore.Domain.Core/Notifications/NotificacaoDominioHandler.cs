using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CalixtosStore.Domain.Core.Notifications
{
    public class NotificacaoDominioHandler : INotificationHandler<NotificacaoDominio>
    {
        private List<NotificacaoDominio> _notificacoes;

        public NotificacaoDominioHandler()
        {
            _notificacoes = new List<NotificacaoDominio>();
        }

        public Task Handle(NotificacaoDominio message, CancellationToken cancellationToken)
        {
            _notificacoes.Add(message);

            return Task.CompletedTask;
        }

        public virtual List<NotificacaoDominio> GetNotifications()
        {
            return _notificacoes;
        }

        public virtual bool HasNotifications()
        {
            return GetNotifications().Any();
        }

        public void Dispose()
        {
            _notificacoes = new List<NotificacaoDominio>();
        }
    }
}