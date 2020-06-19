using br.procon.si.api.crm.domain.Interfaces;

namespace br.procon.si.api.crm.domain.Services
{
    public class EventoService : IEventoService
    {
        private readonly IProconRepository _repositorioProcon;
        private readonly ICrmRepository _repositorioCrm;

        public EventoService(IProconRepository repositorioProcon, ICrmRepository repositorioCrm)
        {
            _repositorioProcon = repositorioProcon;
            _repositorioCrm = repositorioCrm;
        }
        public void Processar()
        {
            throw new System.NotImplementedException();
        }
    }
}