using System;
using System.Linq;
using System.Collections.Generic;
using br.procon.si.api.crm.data.Interfaces;
using br.procon.si.api.crm.infra.VO;
using br.procon.si.api.crm.infra;

namespace br.procon.si.api.crm.data.Standard.Dapper
{
    public class ProconRepository : RepositoryAsync<BaseEntity>, IProconRepository
    {
        public ProconRepository(ServiceResolver serviceResolver) :base(serviceResolver)
        {
        }

        public List<ConsumidorVO> ConsumidorObterPorEventos(IEnumerable<EventoVO> eventos)
        {
            List<ConsumidorVO> consumidores = new List<ConsumidorVO>();
            foreach(var evento in eventos)
            {
                string nome = "usuariocrm_" + Guid.NewGuid().ToString().Substring(0,5);
                string email = nome + "@teste.com";
                consumidores.Add(new ConsumidorVO()
                { 
                   ConsumidorId =  evento.ConsumidorId.Value,
                   Nome = nome,
                   Email = email
                });    
            }
            return consumidores;
        }

        public IEnumerable<EventoVO> EventoObterNaoProcessados()
        {
            
            List<EventoVO> eventos = new List<EventoVO>()
            {
                new EventoVO(){ConsumidorId = 1, Evento="consumidoralterado",Entidade = "consumidor"},
                new EventoVO(){ConsumidorId = 2, Evento="consumidoralterado",Entidade = "consumidor"},
                new EventoVO(){FornecedorId = 1, Evento="fornecedoralterado",Entidade = "fornecedor"},
                new EventoVO(){FornecedorId = 2, Evento="fornecedoralterado",Entidade = "fornecedor"}
            };
            return eventos;
        }

        public List<FornecedorVO> FornecedorObterPorEventos(IEnumerable<EventoVO> eventos)
        {
            List<FornecedorVO> fornecedores = new List<FornecedorVO>();
            foreach(var evento in eventos)
            {
                var nome = evento.FornecedorId.Value == 1 ? "vivo" : "americanas";
                fornecedores.Add(new FornecedorVO()
                { 
                   FornecedorId =  evento.FornecedorId.Value,
                   Nome =  nome,
                   EhCNPJ = true
                });    
            }
            return fornecedores;           
        }
    }
}