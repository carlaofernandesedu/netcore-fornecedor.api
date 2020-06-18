using System;
namespace br.procon.si.api.crm.infra
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        void SaveChanges();

    }
}




