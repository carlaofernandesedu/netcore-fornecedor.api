using br.procon.si.api.fornecedor.data.Standard.Dapper;
using br.procon.si.api.fornecedor.infra;

namespace br.procon.si.api.fornecedor.data.Standard.Dapper
{
    public class RepositoryAsync<TEntity> : IRepositoryAsync<TEntity> where TEntity : class
    {

        protected readonly DapperUnitOfWork _providerDB;

        protected RepositoryAsync(IUnitOfWork providerDB)
        {
            _providerDB = (DapperUnitOfWork) providerDB;
        }

        public void Dispose()
        {
            _providerDB.Dispose();
        }
    }
}