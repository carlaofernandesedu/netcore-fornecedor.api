using System.Collections.Generic;
using br.procon.si.api.fornecedor.domain.VO;
using MediatR;

namespace br.procon.si.api.fornecedor.domain.Queries
{
    public class FichasPorFiltroQuery : IRequest<ResultadoServico<IEnumerable<FilaAtendimento>>>
    {
        public string NomeConsumidor { get; set; }
        public string NumDocumento { get; set; }
    }
}