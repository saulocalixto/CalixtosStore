using CalixtosStore.Domain.Commands;
using CalixtosStore.Domain.Core.Notifications;
using CalixtosStore.Domain.Events;
using CalixtosStore.Domain.Interfaces;
using CalixtosStore.Domain.Producers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CalixtosStore.Domain.CommandHandllers
{
    public class RemoverClienteCommandHandler : CommandHandler, IRequestHandler<RemoverClienteCommand, bool>
    {
        private readonly IProducer<RemoverClienteEvent> _producer;
        private readonly IClienteRepositorio _repositorio;

        public RemoverClienteCommandHandler(IUnitOfWork uow,
            INotificationHandler<NotificacaoDominio> notifications,
            IProducer<RemoverClienteEvent> producer,
            IClienteRepositorio repositorio) : base(uow, notifications)
        {
            _producer = producer;
            _repositorio = repositorio;
        }

        public Task<bool> Handle(RemoverClienteCommand request, CancellationToken cancellationToken)
        {
            if (request.IsValid())
            {
                _producer.SendMensage(new RemoverClienteEvent(request.Id));
                _repositorio.Remover(request.Id);

                return Task.FromResult(Commit());
            }

            return Task.FromResult(false);
        }
    }
}