using br.procon.si.api.fornecedor.infra;

namespace br.procon.si.api.fornecedor.data.Repositories
{
    public class RepositoryAsync<TEntity> : IRepositoryAsync<TEntity> where TEntity : class
    {

        protected readonly IUnitOfWork _providerDB;

        protected RepositoryAsync(IUnitOfWork providerDB)
        {
            _providerDB = providerDB;
        }

        public void Dispose()
        {
            _providerDB.Dispose();
        }
    }
}