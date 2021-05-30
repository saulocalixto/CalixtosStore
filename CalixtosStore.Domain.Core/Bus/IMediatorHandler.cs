using CalixtosStore.Domain.Core.Commands;
using System.Threading.Tasks;

namespace CalixtosStore.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
    }
}