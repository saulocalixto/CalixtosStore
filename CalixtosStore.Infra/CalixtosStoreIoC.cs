using CalixtosStore.Application.Interface;
using CalixtosStore.Application.Services;
using CalixtosStore.Data.Context;
using CalixtosStore.Data.Repository;
using CalixtosStore.Data.UoW;
using CalixtosStore.Domain.CommandHandllers;
using CalixtosStore.Domain.Commands;
using CalixtosStore.Domain.Core.Bus;
using CalixtosStore.Domain.Core.Notifications;
using CalixtosStore.Domain.Events;
using CalixtosStore.Domain.Interfaces;
using CalixtosStore.Domain.Producers;
using CalixtosStore.Infra.CrossCutting.Bus;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CalixtosStore.Infra.CossCutting.IoC
{
    public static class CalixtosStoreIoC
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IProducer<RegistrarNovoClienteEvent>, RegistrarClienteProducer>();
            services.AddScoped<IProducer<AtualizarClienteEvent>, AtualizarClienteProducer>();
            services.AddScoped<IProducer<RemoverClienteEvent>, RemoverClienteProducer>();

            services.AddScoped<IRequestHandler<RegistrarNovoClienteCommand, bool>, RegistrarClienteCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarClienteCommand, bool>, AtualizarClienteCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverClienteCommand, bool>, RemoverClienteCommandHandler>();

            services.AddScoped<INotificationHandler<NotificacaoDominio>, NotificacaoDominioHandler>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<CalixtosStoreContext>();
            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();

            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IMediatorHandler, InMemoryBus>();
        }
    }
}