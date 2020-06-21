using AutoMapper;
using br.procon.si.api.crm.domain.VO;
using br.procon.si.api.crm.domain.VO.Crm;

namespace br.procon.si.api.crm.domain.Adapters
{
     public class ParaCrmVOsProfile : Profile
    {
        public ParaCrmVOsProfile()
        {
            CreateMap<ConsumidorVO,CrmConsumidorVO>();
        }
    }
}