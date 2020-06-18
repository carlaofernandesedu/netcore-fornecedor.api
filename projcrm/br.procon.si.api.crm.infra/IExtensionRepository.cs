namespace br.procon.si.api.crm.infra
{
    public interface IExtensionRepository<TEntity> : IRepositoryAsync<TEntity> where TEntity : class
    {
    }
}