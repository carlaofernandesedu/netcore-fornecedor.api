using AutoMapper;
using br.procon.si.api.fornecedor.Contracts.V1.Requests;
using br.procon.si.api.fornecedor.domain.VO;

namespace br.procon.si.api.fornecedor.Adapters
{
    public class ParaServicoProfile : Profile
    {
        public ParaServicoProfile()
        {
            CreateMap<FiltroAtendimentoRequest,FiltroAtendimento>();
        }
    }
}