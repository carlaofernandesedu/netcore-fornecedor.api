using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using br.procon.si.api.fornecedor.Contracts.V1.Responses;
using br.procon.si.api.fornecedor.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using br.procon.si.api.fornecedor.Validations;
using br.procon.si.api.fornecedor.Contracts.V1.Requests;
using br.procon.si.api.fornecedor.Contracts.V1;
using br.procon.si.api.fornecedor.domain.Interfaces;
using br.procon.si.api.fornecedor.domain.VO;
using AutoMapper;
using MediatR;
using br.procon.si.api.fornecedor.domain;
using br.procon.si.api.fornecedor.domain.Queries;

namespace br.procon.si.api.fornecedor.Controllers.V1
{
    
    public class FichasController : BaseController
    {
        
        private readonly IMapper _servicoMapper;
        public FichasController( IMapper servicoMapper, IMediator mediator)
        {
            _servicoMapper = servicoMapper;
        }

        [HttpPost(ApiRoutes.Fichas.Get)]
        public IActionResult Get(
            [FromServices] IFichaService servicoFicha,
            [FromBody] FiltroAtendimentoRequest filtroRequest)
        {
            var validator = new FiltroAtendimentoRequestContract(filtroRequest).Validar();

            if (validator.Falhou)
                return BadRequest(new ResultadoCriticaResponse(validator.Criticas));

            var filtro = _servicoMapper.Map<FiltroAtendimento>(filtroRequest);
            var respostaServico = servicoFicha.Listar(filtro);

            if (respostaServico.Validacao.Falhou)
                return BadRequest(new ResultadoCriticaResponse(respostaServico.Validacao.Criticas));
            
            var resultResponse = _servicoMapper.Map<List<FilaAtendimentoResponse>>(respostaServico.Data);    

            return Ok(new ResultadoResponse<List<FilaAtendimentoResponse>>(resultResponse));



        }

        [HttpPost(ApiRoutes.Fichas.GetMediator)]
        public IActionResult GetMediator(
            [FromServices] IMediator mediator,
            [FromBody] FiltroAtendimentoRequest filtroRequest)
        {
            var validator = new FiltroAtendimentoRequestContract(filtroRequest).Validar();

            if (validator.Falhou)
                return BadRequest(new ResultadoCriticaResponse(validator.Criticas));

            var filtro = _servicoMapper.Map<FichasPorFiltroQuery>(filtroRequest);
            var respostaServico = mediator.Send<ResultadoServico<IEnumerable<FilaAtendimento>>>(filtro).Result;

            if (respostaServico.Validacao.Falhou)
                return BadRequest(new ResultadoCriticaResponse(respostaServico.Validacao.Criticas));
            
            var resultResponse = _servicoMapper.Map<List<FilaAtendimentoResponse>>(respostaServico.Data);    

            return Ok(new ResultadoResponse<List<FilaAtendimentoResponse>>(resultResponse));



        }
    }
}