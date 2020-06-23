
using br.procon.si.api.crm.Contracts.V1;
using br.procon.si.api.crm.domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace br.procon.si.api.crm.Controllers.V1
{
    public class EventosController : BaseController
    {
        private readonly IEventoService _eventoService;
        public EventosController(IEventoService eventoService)        
        {
            _eventoService = eventoService;
        }

        [HttpPost(ApiRoutes.Eventos.Get)]
        public IActionResult Get()
        {
            _eventoService.Processar();
            return Ok(new{Teste="Retorno de Informações"});

        }
    }
}