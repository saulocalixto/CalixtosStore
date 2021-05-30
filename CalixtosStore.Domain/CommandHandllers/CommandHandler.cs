using CalixtosStore.Domain.Core.Commands;
using CalixtosStore.Domain.Core.Notifications;
using CalixtosStore.Domain.Interfaces;
using MediatR;

namespace CalixtosStore.Domain.CommandHandllers
{
    public class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly NotificacaoDominioHandler _notifications;

        public CommandHandler(IUnitOfWork uow, INotificationHandler<NotificacaoDominio> notifications)
        {
            _uow = uow;
            _notifications = (NotificacaoDominioHandler)notifications;
        }

        protected void NotifyValidationErrors(Command message)
        {
            foreach (var error in message.ValidationResult.Errors)
            {
            }
        }

        public bool Commit()
        {
            if (_notifications.HasNotifications()) return false;
            if (_uow.Commit()) return true;

            System.Console.WriteLine("Erro ao salvar no banco.");
            return false;
        }
    }
}