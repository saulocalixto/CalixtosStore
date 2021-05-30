using CalixtosStore.Domain.Commands;
using CalixtosStore.Domain.Core.Notifications;
using CalixtosStore.Domain.Events;
using CalixtosStore.Domain.Interfaces;
using CalixtosStore.Domain.Models;
using CalixtosStore.Domain.Producers;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CalixtosStore.Domain.CommandHandllers
{
    public class RegistrarClienteCommandHandler : CommandHandler, IRequestHandler<RegistrarNovoClienteCommand, bool>
    {
        private readonly IProducer<RegistrarNovoClienteEvent> _producer;
        private readonly IClienteRepositorio _repositorio;

        public RegistrarClienteCommandHandler(
            IUnitOfWork uow,
            INotificationHandler<NotificacaoDominio> notifications,
            IProducer<RegistrarNovoClienteEvent> producer,
            IClienteRepositorio repositorio) : base(uow, notifications)
        {
            _producer = producer;
            _repositorio = repositorio;
        }

        public Task<bool> Handle(RegistrarNovoClienteCommand request, CancellationToken cancellationToken)
        {
            if (request.IsValid())
            {
                var id = Guid.NewGuid();
                _producer.SendMensage(new RegistrarNovoClienteEvent(id, request.Nome, request.Email, request.DataDeNascimento));
                var cliente = new Cliente(id, request.Nome, request.Email, request.DataDeNascimento);

                _repositorio.Adicionar(cliente);

                return Task.FromResult(Commit());
            }

            return Task.FromResult(false);
        }
    }
}