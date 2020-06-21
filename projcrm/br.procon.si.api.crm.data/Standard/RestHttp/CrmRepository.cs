using System;
using br.procon.si.api.crm.domain.Entities;
using br.procon.si.api.crm.domain.Interfaces;
using br.procon.si.api.crm.infra;

namespace br.procon.si.api.crm.data.Standard.RestHttp
{
    public class CrmRepository : RepositoryAsync<BaseEntity>, ICrmRepository
    {
        public CrmRepository(ServiceResolver serviceResolver) :base(serviceResolver)
        {
            
        }
    }
}