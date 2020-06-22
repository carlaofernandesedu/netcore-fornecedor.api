using System;
using br.procon.si.api.crm.domain.Entities;
using br.procon.si.api.crm.domain.Interfaces;
using br.procon.si.api.crm.domain.VO.Crm;


namespace br.procon.si.api.crm.data.Standard.RestHttp
{
    public class CrmRepository : RepositoryAsync<BaseEntity>, ICrmRepository
    {
        public CrmRepository(ServiceResolver serviceResolver) :base(serviceResolver)
        {
            
        }

        public bool ConsumidorAtualizar(CrmConsumidorVO consumidor)
        {
            return true;
        }

        public bool FornecedorAtualizar(CrmFornecedorVO crmFornecedor)
        {
             var response =  _providerDB.Execute("fornecedoratualizar", crmFornecedor, autenticar: false);
             return response;
        }
    }
}