using System;
using System.Collections.Generic;
using System.Text;

namespace br.procon.si.api.fornecedor.infra.DTO
{
    public class BaseFiltroPaginado
    {
        public int NumeroPagina { get; set; }
        public int TamanhoPagina { get; set; }
    }
}
