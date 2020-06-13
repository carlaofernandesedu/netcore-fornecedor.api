using System.Collections.Generic;
using br.procon.si.api.fornecedor.data.Standard.Dapper;
using br.procon.si.api.fornecedor.domain.Entities;
using br.procon.si.api.fornecedor.domain.Interfaces;
using br.procon.si.api.fornecedor.domain.VO;
using br.procon.si.api.fornecedor.infra;

namespace br.procon.si.api.fornecedor.data.Repositories
{
    public class FichaRepository : ExtensionRepository<FichaAtendimento>, IFichaRepository
    {
        private readonly DapperUnitOfWork _dapperProvider;
        public FichaRepository(IUnitOfWork providerDB) : base(providerDB)
        {
            _dapperProvider = (DapperUnitOfWork) providerDB;
        }
        public IEnumerable<FilaAtendimento> Listar(FiltroAtendimento filtro)
        {
            throw new System.NotImplementedException();
        }
    }
}