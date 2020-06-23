using br.procon.si.api.crm.infra.VO.Crm;

namespace br.procon.si.api.crm.data.Interfaces
{
    public interface ICrmRepository
    {
         bool ConsumidorAtualizar(CrmConsumidorVO consumidor);
         bool FornecedorAtualizar(CrmFornecedorVO crmFornecedor);
    }
}