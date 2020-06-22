using AutoMapper;
using br.procon.si.api.crm.domain.VO;
using br.procon.si.api.crm.domain.VO.Crm;

namespace br.procon.si.api.crm.Adapters
{
    public class ParaCRMVOsProfile : Profile
    {
        public ParaCRMVOsProfile()
        {
            CreateMap<ConsumidorVO,CrmConsumidorVO>();
            CreateMap<FornecedorVO,CrmFornecedorVO>();
        }
    }
}