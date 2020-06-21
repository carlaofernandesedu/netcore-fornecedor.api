﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using br.procon.si.api.crm.domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace br.procon.si.api.crm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IEventoService _eventoService;
        public ValuesController(IEventoService eventoService)        
        {
            _eventoService = eventoService;
            _eventoService.Processar();
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

       
    }
}