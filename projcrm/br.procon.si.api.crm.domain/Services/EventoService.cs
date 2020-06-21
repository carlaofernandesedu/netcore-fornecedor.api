using System.Linq;
using br.procon.si.api.crm.domain.Interfaces;
using AutoMapper;
using br.procon.si.api.crm.domain.VO.Crm;

namespace br.procon.si.api.crm.domain.Services
{
    public class EventoService : IEventoService
    {
        private readonly IProconRepository _repositorioProcon;
        private readonly ICrmRepository _repositorioCrm;
        private readonly IMapper _servicoMapper;
        public EventoService(IProconRepository repositorioProcon, ICrmRepository repositorioCrm, IMapper servicoMapper)
        {
            _repositorioProcon = repositorioProcon;
            _repositorioCrm = repositorioCrm;
            _servicoMapper = servicoMapper;
        }
        public bool Processar()
        {
            var eventos = _repositorioProcon.EventoObterNaoProcessados();
            var eventosConsumidores = eventos.Where(x=> x.Entidade == "consumidor");
            var consumidoresAProcessar =_repositorioProcon.ConsumidorObterPorEventos(eventosConsumidores);
            consumidoresAProcessar.ForEach( consumidor => 
            {
                var crmConsumidor = _servicoMapper.Map<CrmConsumidorVO>(consumidor);  
               _repositorioCrm.ConsumidorAtualizar(crmConsumidor);  
              
            });

            return true;
        }
    }
}