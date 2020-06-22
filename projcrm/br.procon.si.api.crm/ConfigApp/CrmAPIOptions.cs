using System.Collections.Generic;

namespace br.procon.si.api.crm.ConfigApp
{
    public class CrmAPIOptions
    {
        public string ClientId {get;set;}
        public string Secret {get;set;}
        public List<Endpoint> Endpoints {get;set;}

        public class Endpoint 
        {
            public string Chave{get;set;}
            public string Url {get;set;}
            public string HttpMetodo{get;set;}
        }
    }
}