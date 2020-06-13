using br.procon.si.api.fornecedor.infra;

namespace br.procon.si.api.fornecedor.data.Repositories
{
    public abstract class ExtensionRepository<TEntity> : RepositoryAsync<TEntity>,
                                                  IExtensionRepository<TEntity> where TEntity : class
    {
        protected ExtensionRepository(IUnitOfWork providerDB) :base(providerDB)
        {
            
        }
        
    }
}