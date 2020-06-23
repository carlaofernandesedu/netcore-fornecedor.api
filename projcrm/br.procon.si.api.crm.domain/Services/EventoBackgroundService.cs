using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using br.procon.si.api.crm.domain.Interfaces;
using br.procon.si.api.crm.infra.HostApp;
using Microsoft.Extensions.Logging;

namespace br.procon.si.api.crm.domain.Services
{
    public class EventoBackgroundService : BackgroundService , IEventoService
    {   
        private readonly ILogger<EventoBackgroundService> _logger;
        private readonly IProconRepository _repositorioProcon;
        private readonly ICrmRepository _repositorioCrm;
        private readonly IMapper _servicoMapper;
        

        public EventoBackgroundService(IProconRepository repositorioProcon, ICrmRepository repositorioCrm, IMapper servicoMapper,
            ILogger<EventoBackgroundService> logger)
        {
                _repositorioProcon = repositorioProcon;
                _repositorioCrm = repositorioCrm;
                _servicoMapper = servicoMapper;
                _logger = logger;
        }

        public bool Processar()
        {
            _logger.LogDebug($"EventoBackgroundService usou o metodo Processar.");
            return true;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogDebug($"EventoBackgroundService is starting.");

            stoppingToken.Register(() =>
                _logger.LogDebug($" EventoBackgroundService background task is stopping."));

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogDebug($"EventoBackgroundService task doing background work.");

                Processar();

                await Task.Delay(10000, stoppingToken);
            }

            _logger.LogDebug($"EventoBackgroundService background task is stopping.");
        }

    
    }
}