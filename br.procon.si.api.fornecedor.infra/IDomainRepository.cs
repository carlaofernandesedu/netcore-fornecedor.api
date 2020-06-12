namespace br.procon.si.api.fornecedor.infra
{
    public interface IDomainRepository<TEntity> : IRepositoryAsync<TEntity> where TEntity : class
    {
    }
}