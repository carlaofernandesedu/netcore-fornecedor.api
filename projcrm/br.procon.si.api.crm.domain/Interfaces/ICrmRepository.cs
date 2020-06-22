using br.procon.si.api.crm.domain.VO.Crm;

namespace br.procon.si.api.crm.domain.Interfaces
{
    public interface ICrmRepository
    {
         bool ConsumidorAtualizar(CrmConsumidorVO consumidor);
         bool FornecedorAtualizar(CrmConsumidorVO crmFornecedor);
    }
}