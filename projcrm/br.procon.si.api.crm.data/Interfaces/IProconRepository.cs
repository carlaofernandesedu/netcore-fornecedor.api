using System.Collections.Generic;
using br.procon.si.api.crm.infra.VO;

namespace br.procon.si.api.crm.data.Interfaces
{
    public interface IProconRepository
    {
            IEnumerable<EventoVO> EventoObterNaoProcessados();

            List<ConsumidorVO> ConsumidorObterPorEventos(IEnumerable<EventoVO> eventos);

            List<FornecedorVO> FornecedorObterPorEventos(IEnumerable<EventoVO> eventos);

    }
}