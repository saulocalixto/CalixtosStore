using CalixtosStore.Domain.Commands;
using CalixtosStore.Domain.Core.Notifications;
using CalixtosStore.Domain.Events;
using CalixtosStore.Domain.Interfaces;
using CalixtosStore.Domain.Models;
using CalixtosStore.Domain.Producers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CalixtosStore.Domain.CommandHandllers
{
    public class AtualizarClienteCommandHandler : CommandHandler, IRequestHandler<AtualizarClienteCommand, bool>
    {
        private readonly IProducer<AtualizarClienteEvent> _producer;
        private readonly IClienteRepositorio _repositorio;

        public AtualizarClienteCommandHandler(IUnitOfWork uow,
            INotificationHandler<NotificacaoDominio> notifications,
            IProducer<AtualizarClienteEvent> producer,
            IClienteRepositorio repositorio) : base(uow, notifications)
        {
            _producer = producer;
            _repositorio = repositorio;
        }

        public Task<bool> Handle(AtualizarClienteCommand request, CancellationToken cancellationToken)
        {
            if (request.IsValid())
            {
                _producer.SendMensage(new AtualizarClienteEvent(request.Id, request.Nome, request.Email, request.DataDeNascimento));

                var cliente = new Cliente(request.Id, request.Nome, request.Email, request.DataDeNascimento);
                _repositorio.Atualizar(cliente);

                return Task.FromResult(Commit());
            }

            return Task.FromResult(false);
        }
    }
}