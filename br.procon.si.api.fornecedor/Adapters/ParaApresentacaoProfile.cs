using AutoMapper;
using br.procon.si.api.fornecedor.Contracts.V1.Responses;
using br.procon.si.api.fornecedor.domain.VO;


namespace br.procon.si.api.fornecedor.Adapters
{
    public class ParaApresentacaoProfile : Profile
    {
        public ParaApresentacaoProfile()
        {
            CreateMap<FilaAtendimento,FilaAtendimentoResponse>();    
        }
    }
}