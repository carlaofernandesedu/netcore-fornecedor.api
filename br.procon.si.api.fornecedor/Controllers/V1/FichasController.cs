using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using br.procon.si.api.fornecedor.Contracts.V1.Responses;
using br.procon.si.api.fornecedor.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace br.procon.si.api.fornecedor.Controllers.V1
{
    [Route("api/[controller]")]
    public class FichasController : BaseController
    {
        [HttpGet("")]
        public IActionResult Get()
        {
            return Ok(new { Retorno = "teste" });
        }
    }
}