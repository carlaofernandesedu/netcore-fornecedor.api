using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using br.procon.si.api.crm.data.Interfaces;
using br.procon.si.api.crm.domain.Interfaces;
using br.procon.si.api.crm.infra.HostApp;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace br.procon.si.api.crm.domain.Services
{
    public class EventoScopedService : IEventoService, IScopedProcessingService
    {
        private readonly IProconRepository _repositorioProcon;
        private readonly ICrmRepository _repositorioCrm;
        private readonly IMapper _servicoMapper;
        private int executionCount = 0;
        private readonly ILogger _logger;
        public EventoScopedService(IProconRepository repositorioProcon, ICrmRepository repositorioCrm, IMapper servicoMapper,
        ILogger<EventoScopedService> logger)
        {
            _repositorioProcon = repositorioProcon;
            _repositorioCrm = repositorioCrm;
            _servicoMapper = servicoMapper;
             _logger = logger;
        }

        public async Task DoWork(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                executionCount++;

               Processar();


                await Task.Delay(5000, stoppingToken);
            }
        }

        public bool Processar()
        {
             _logger.LogInformation(
                    "Scoped Processing Service is working. Count: {Count}", executionCount);
            return true;
        }

    }
}