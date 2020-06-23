using System;
using br.procon.si.api.crm.infra;
using br.procon.si.api.crm.data.Interfaces;
using br.procon.si.api.crm.infra.VO.Crm;


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