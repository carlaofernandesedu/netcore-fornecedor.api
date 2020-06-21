using br.procon.si.api.crm.infra;

namespace br.procon.si.api.crm.data.Standard
{
    public class BaseRepositoryAsync
    {
        public delegate IUnitOfWork ServiceResolver(RepositorieTypesEnum key);

        public enum RepositorieTypesEnum
        {
            Dapper,
            CRM
        }
    }
}