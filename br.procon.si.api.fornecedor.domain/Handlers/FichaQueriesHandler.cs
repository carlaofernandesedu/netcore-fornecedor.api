using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using br.procon.si.api.fornecedor.domain.Interfaces;
using br.procon.si.api.fornecedor.domain.Queries;
using br.procon.si.api.fornecedor.domain.Validations;
using br.procon.si.api.fornecedor.domain.VO;
using br.procon.si.api.fornecedor.infra;
using MediatR;

namespace br.procon.si.api.fornecedor.domain
{
    public class FichaQueriesHandler : BaseHandler, IRequestHandler<FichasPorFiltroQuery,ResultadoServico<IEnumerable<FilaAtendimento>>>
    {
        private readonly IFichaRepository _fichaRepository;

        public FichaQueriesHandler(IFichaRepository fichaRepository, IUnitOfWork uow) : base(uow)
        {
            _fichaRepository = fichaRepository;
        }
        public Task<ResultadoServico<IEnumerable<FilaAtendimento>>> Handle(FichasPorFiltroQuery request, CancellationToken cancellationToken)
        {
            var validacao = new ListarValidation(request).Validar();
            
            if (validacao.Falhou)
            {
                return Task.FromResult<ResultadoServico<IEnumerable<FilaAtendimento>>>(new ResultadoServico<IEnumerable<FilaAtendimento>>(validacao));
            }
            var lista = _fichaRepository.Listar(request);
            
            return Task.FromResult<ResultadoServico<IEnumerable<FilaAtendimento>>>(new ResultadoServico<IEnumerable<FilaAtendimento>>(lista));
        }
    }
}