using System.Collections.Generic;
using br.procon.si.api.fornecedor.domain.Entities;
using br.procon.si.api.fornecedor.domain.VO;
using br.procon.si.api.fornecedor.infra;

namespace br.procon.si.api.fornecedor.domain.Interfaces
{
    public interface IFichaRepository : IExtensionRepository<FichaAtendimento>
    {
         IEnumerable<FilaAtendimento> Listar(FiltroAtendimento filtro);
    }
}