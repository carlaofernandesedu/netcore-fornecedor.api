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

namespace br.procon.si.api.fornecedor.Controllers.V1
{
    
    public class FichasController : BaseController
    {
        [HttpPost(ApiRoutes.Fichas.Get)]
        public IActionResult Get([FromBody] FiltroAtendimentoRequest filtro)
        {
            var validator = new FiltroAtendimentoRequestContract(filtro).Validar();
            
            if(!validator.Sucesso)
              return BadRequest(new ResultadoCriticaResponse(validator.Criticas));
            
            var resultado = "Retorno OK";
            return Ok(new ResultadoResponse<string>(resultado));
        }
    }
}