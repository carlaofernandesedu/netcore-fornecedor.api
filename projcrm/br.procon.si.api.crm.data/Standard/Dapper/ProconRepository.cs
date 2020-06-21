using System;
using br.procon.si.api.crm.domain.Entities;
using br.procon.si.api.crm.domain.Interfaces;
using br.procon.si.api.crm.infra;

namespace br.procon.si.api.crm.data.Standard.Dapper
{
    public class ProconRepository : RepositoryAsync<BaseEntity>, IProconRepository
    {
        public ProconRepository(ServiceResolver serviceResolver) :base(serviceResolver)
        {
            
        }
    }
}