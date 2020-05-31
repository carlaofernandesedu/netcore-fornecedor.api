using Microsoft.AspNetCore.Mvc;

namespace br.procon.si.api.fornecedor.Controllers
{
    public class TestController : BaseController
    {
        [HttpGet("api/Check")]
        public IActionResult Get()
        {
            return Ok(new { Data= "Teste de Retorno"});
        }    
    }
}