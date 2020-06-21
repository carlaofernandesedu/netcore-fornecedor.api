using System;
using br.procon.si.api.crm.infra;
using br.procon.si.api.crm.data.Standard;

namespace br.procon.si.api.crm.data.Standard.RestHttp
{
     public class RepositoryAsync<TEntity> : BaseRepositoryAsync, IRepositoryAsync<TEntity> where TEntity : class
    {

        protected readonly CRMHelperUnitOfWork _providerDB;

        protected RepositoryAsync(ServiceResolver serviceResolver)
        {
            _providerDB = (CRMHelperUnitOfWork) serviceResolver(RepositorieTypesEnum.CRM);
        }

        public void Dispose()
        {
            _providerDB.Dispose();
        }
    }
}