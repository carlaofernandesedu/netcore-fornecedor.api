using br.procon.si.api.fornecedor.data.Standard.Dapper;
using br.procon.si.api.fornecedor.infra;

namespace br.procon.si.api.fornecedor.data.Standard.EFCore
{
    public class RepositoryAsync<TEntity> : IRepositoryAsync<TEntity> where TEntity : class
    {
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}