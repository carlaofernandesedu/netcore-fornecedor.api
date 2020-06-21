using System;
using System.Linq;
using System.Collections.Generic;
using br.procon.si.api.crm.domain.Entities;
using br.procon.si.api.crm.domain.Interfaces;
using br.procon.si.api.crm.domain.VO;
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
                new EventoVO(){ConsumidorId = 2, Evento="consumidoralterado",Entidade = "consumidor"}
            };
            return eventos;
        }
    }
}