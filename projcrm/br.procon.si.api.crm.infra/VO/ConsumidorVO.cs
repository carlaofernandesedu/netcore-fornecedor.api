namespace br.procon.si.api.crm.infra.VO
{
    public class ConsumidorVO
    {
        public int ConsumidorId { get; set; }
        public string  Nome { get; set; }

        public string  Email { get; set; }
        public object FornecedorId { get; set; }
    }
}