using System.Collections.Generic;
using br.procon.si.api.crm.domain.VO;

namespace br.procon.si.api.crm.domain.Interfaces
{
    public interface IProconRepository
    {
            IEnumerable<EventoVO> EventoObterNaoProcessados();

            IEnumerable<ConsumidorVO> ConsumidorObterPorEventos(IEnumerable<EventoVO> eventos);

    }
}