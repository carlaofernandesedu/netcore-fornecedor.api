using System;

namespace br.procon.si.api.fornecedor.infra
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        void SaveChanges();

    }

}