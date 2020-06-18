using br.procon.si.api.crm.infra;

namespace br.procon.si.api.crm.data.Standard.RestHttp
{
     public class RepositoryAsync<TEntity> : IRepositoryAsync<TEntity> where TEntity : class
    {

        protected readonly CRMHelperUnitOfWork _providerDB;

        protected RepositoryAsync(IUnitOfWork providerDB)
        {
            _providerDB = (CRMHelperUnitOfWork) providerDB;
        }

        public void Dispose()
        {
            _providerDB.Dispose();
        }
    }
}