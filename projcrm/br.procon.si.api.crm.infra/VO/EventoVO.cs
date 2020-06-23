using System;

namespace br.procon.si.api.crm.infra.VO
{
    public class EventoVO
    {
       public string Evento { get; set; }
       public string Entidade { get; set; }
       public int? ConsumidorId { get; set; }
       public DateTime DataCriacao {get; set;}
       public int? FornecedorId { get; set; }
    }
}