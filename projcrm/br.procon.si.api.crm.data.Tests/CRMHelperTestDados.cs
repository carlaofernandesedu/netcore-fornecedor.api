using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.procon.si.api.crm.data.Tests
{
    public class CRMHelperTestDados
    {
    }
    [Serializable]
    public class DominioTestDados
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
    }

    public class AutenticacaoTestDados
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
    }

    public class FornecedorTestDados
    {
        public string Nome { get; set; }
        public string NumDocumento { get; set; }
        public bool EhCNPJ { get; set; }
        public int? IdFornecedor { get; set; }
    }

    public class FichaTestDados
    {
        public int Codigo { get; set; }
        public string Protocolo { get; set; } 
    }
}
