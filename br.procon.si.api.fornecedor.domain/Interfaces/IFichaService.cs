using br.procon.si.api.fornecedor.domain.VO;
using System;
using System.Collections.Generic;
using System.Text;

namespace br.procon.si.api.fornecedor.domain.Interfaces
{
    public interface IFichaService
    {
        ResultadoServico<IEnumerable<FilaAtendimento>> Listar(FiltroAtendimento filtro);
    }
}
