using br.procon.si.api.fornecedor.infra;

namespace br.procon.si.api.fornecedor.domain
{
    public class BaseHandler
    {
        private readonly IUnitOfWork _uow;

        public BaseHandler(IUnitOfWork uow)
        {
            _uow = uow;    
        }

        public void BeginTransaction()
        {
            _uow.BeginTransaction();
        }

        public void SaveChanges()
        {
            _uow.SaveChanges();
        }
    }
}