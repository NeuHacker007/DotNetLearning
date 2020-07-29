using System.Threading;
using System.Threading.Tasks;

namespace BackgroundServiceDemo
{
    public interface IWorker
    {
        Task DoWork(CancellationToken cancellationToken);
    }
}