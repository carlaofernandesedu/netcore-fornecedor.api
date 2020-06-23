using System.Threading;
using System.Threading.Tasks;

namespace br.procon.si.api.crm.infra.HostApp
{
    public interface IScopedProcessingService
    {
        Task DoWork(CancellationToken stoppingToken);
    }
}