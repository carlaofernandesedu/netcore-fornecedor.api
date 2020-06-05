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

namespace br.procon.si.api.fornecedor.Controllers.V1
{
    
    public class FichasController : BaseController
    {
        [HttpPost(ApiRoutes.Fichas.Get)]
        public IActionResult Get(
            [FromServices] IFichaService servico,
            [FromBody] FiltroAtendimentoRequest filtroRequest)
        {
            var validator = new FiltroAtendimentoRequestContract(filtroRequest).Validar();

            if (validator.Falhou)
                return BadRequest(new ResultadoCriticaResponse(validator.Criticas));

            var filtro = new FiltroAtendimento
            {
                NomeConsumidor = filtroRequest.NomeConsumidor,
                NumDocumento = filtroRequest.NumDocumento
            };

            var respostaServico = servico.Listar(filtro);

            if (respostaServico.Validacao.Falhou)
                return BadRequest(new ResultadoCriticaResponse(respostaServico.Validacao.Criticas));

            var resultResponse = new List<FilaAtendimentoResponse>();
            foreach( var item in respostaServico.Data)
            {
                resultResponse.Add(new FilaAtendimentoResponse()
                {
                    ConsumidorNome = item.NomeConsumidor,
                    NumDocumento = item.NumDocumento
                });
            }
            return Ok(new ResultadoResponse<List<FilaAtendimentoResponse>>(resultResponse));



        }
    }
}