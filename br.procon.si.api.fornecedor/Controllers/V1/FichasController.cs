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

namespace br.procon.si.api.fornecedor.Controllers.V1
{
    
    public class FichasController : BaseController
    {
        private readonly IFichaService _servicoFicha;
        private readonly IMapper _servicoMapper;
        public FichasController(IFichaService servicoFicha, IMapper servicoMapper)
        {
            _servicoFicha = servicoFicha;
            _servicoMapper = servicoMapper;
        }

        [HttpPost(ApiRoutes.Fichas.Get)]
        public IActionResult Get(
            [FromBody] FiltroAtendimentoRequest filtroRequest)
        {
            var validator = new FiltroAtendimentoRequestContract(filtroRequest).Validar();

            if (validator.Falhou)
                return BadRequest(new ResultadoCriticaResponse(validator.Criticas));

            var filtro = _servicoMapper.Map<FiltroAtendimento>(filtroRequest);
            var respostaServico = _servicoFicha.Listar(filtro);

            if (respostaServico.Validacao.Falhou)
                return BadRequest(new ResultadoCriticaResponse(respostaServico.Validacao.Criticas));
            
            var resultResponse = _servicoMapper.Map<List<FilaAtendimentoResponse>>(respostaServico.Data);    

            return Ok(new ResultadoResponse<List<FilaAtendimentoResponse>>(resultResponse));



        }
    }
}