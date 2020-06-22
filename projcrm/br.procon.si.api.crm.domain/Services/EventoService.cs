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
            var eventosFornecedores = eventos.Where(x=> x.Entidade == "fornecedor");
            var fornecedoresAProcessar =_repositorioProcon.FornecedorObterPorEventos(eventosFornecedores);
            fornecedoresAProcessar.ForEach( fornecedor => 
            {
                var crmFornecedor = _servicoMapper.Map<CrmFornecedorVO>(fornecedor);  
               _repositorioCrm.FornecedorAtualizar(crmFornecedor);  
              
            });

            return true;
        }
    }
}