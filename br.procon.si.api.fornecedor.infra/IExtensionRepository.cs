namespace br.procon.si.api.fornecedor.infra
{
    public interface IExtensionRepository<TEntity> : IRepositoryAsync<TEntity> where TEntity : class
    {
    }
}