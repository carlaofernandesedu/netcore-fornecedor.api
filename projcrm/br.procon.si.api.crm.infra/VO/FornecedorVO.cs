namespace br.procon.si.api.crm.infra.VO
{
    public class FornecedorVO
    {
        public int FornecedorId { get; set; }
        public string Nome { get; set; }
        public string  NumDocumento { get; set; }

        public bool  EhCNPJ { get; set; }
        
    }
}