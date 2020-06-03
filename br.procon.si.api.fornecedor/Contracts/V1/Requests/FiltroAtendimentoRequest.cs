using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace br.procon.si.api.fornecedor.Contracts.V1.Requests
{
    public class FiltroAtendimentoRequest
    {
        public string NomeConsumidor { get; set; }
        public string NumDocumento { get; set; }
    }
}
