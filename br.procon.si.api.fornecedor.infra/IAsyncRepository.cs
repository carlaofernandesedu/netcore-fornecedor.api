//code by https://medium.com/@adlerpagliarini/c-net-core-criando-uma-aplica%C3%A7%C3%A3o-utilizando-repository-pattern-com-dois-orms-diferentes-dapper-a821d501e317

using System;
namespace br.procon.si.api.fornecedor.infra
{
public interface IRepositoryAsync<TEntity> : IDisposable where TEntity : class
{

    // Task<TEntity> AddAsync(TEntity obj);
    // Task<int> AddRangeAsync(IEnumerable<TEntity> entities);

    // Task<TEntity> GetByIdAsync(object id);
    // Task<IEnumerable<TEntity>> GetAllAsync();

    // Task<int> UpdateAsync(TEntity obj);
    // Task<int> UpdateRangeAsync(IEnumerable<TEntity> entities);

    // Task<bool> RemoveAsync(object id);
    // Task<int> RemoveAsync(TEntity obj);
    // Task<int> RemoveRangeAsync(IEnumerable<TEntity> entities);
}
}