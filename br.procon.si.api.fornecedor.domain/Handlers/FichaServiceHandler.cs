using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using br.procon.si.api.fornecedor.domain.Queries;
using br.procon.si.api.fornecedor.domain.Validations;
using br.procon.si.api.fornecedor.domain.VO;
using MediatR;

namespace br.procon.si.api.fornecedor.domain
{
    public class FichaServiceHandler : IRequestHandler<FichasPorFiltroQuery,ResultadoServico<IEnumerable<FilaAtendimento>>>
    {
        public Task<ResultadoServico<IEnumerable<FilaAtendimento>>> Handle(FichasPorFiltroQuery request, CancellationToken cancellationToken)
        {
            var validacao = new ListarValidation(request).Validar();
            
            if (validacao.Falhou)
            {
                return Task.FromResult<ResultadoServico<IEnumerable<FilaAtendimento>>>(new ResultadoServico<IEnumerable<FilaAtendimento>>(validacao));
            }

            var retornoEntidade = new FilaAtendimento { NomeConsumidor = "Nome Consumidor 01", NumDocumento = "001" };
            var lista = new List<FilaAtendimento>();
            lista.Add(retornoEntidade);
            return Task.FromResult<ResultadoServico<IEnumerable<FilaAtendimento>>>(new ResultadoServico<IEnumerable<FilaAtendimento>>(lista));
        }
    }
}