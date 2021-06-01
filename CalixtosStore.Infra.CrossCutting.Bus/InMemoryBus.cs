using CalixtosStore.Domain.Core.Bus;
using CalixtosStore.Domain.Core.Commands;
using MediatR;
using System.Threading.Tasks;

namespace CalixtosStore.Infra.CrossCutting.Bus
{
    public class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public InMemoryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }
    }
}