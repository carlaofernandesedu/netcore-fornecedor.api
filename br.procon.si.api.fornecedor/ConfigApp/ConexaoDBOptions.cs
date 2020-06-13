using br.procon.si.api.fornecedor.infra;

namespace br.procon.si.api.fornecedor.ConfigApp
{
    public class ConexaoDBOptions : IDataSettings
    {
        public string DefaultConnection { get;set; }
        public int? commandTimeout { get;set;}
    }
}