using System;
namespace br.procon.si.api.crm.infra
{
    public interface IRepositoryAsync<TEntity> : IDisposable where TEntity : class
    {
    }
}