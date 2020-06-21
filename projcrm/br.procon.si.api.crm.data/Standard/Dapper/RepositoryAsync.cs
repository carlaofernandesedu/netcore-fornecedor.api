using System;
using br.procon.si.api.crm.data.Standard.Dapper;
using br.procon.si.api.crm.infra;

namespace br.procon.si.api.crm.data.Standard.Dapper
{
    public class RepositoryAsync<TEntity> : BaseRepositoryAsync, IRepositoryAsync<TEntity> where TEntity : class
    {

        protected readonly DapperUnitOfWork _providerDB;

        protected RepositoryAsync(ServiceResolver serviceResolver)
        {
            _providerDB = (DapperUnitOfWork) serviceResolver(RepositorieTypesEnum.Dapper);
        }

        public void Dispose()
        {
            _providerDB.Dispose();
        }
    }
}