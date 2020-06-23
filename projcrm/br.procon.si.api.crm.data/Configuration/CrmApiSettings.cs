using System.Collections.Generic;
using br.procon.si.api.crm.data.Standard.RestHttp;

namespace br.procon.si.api.crm.data.Configuration
{
    public class CrmApiSettings
    {
        public const string CrmApiSettingsOptions = "ApiCrmOptions";
        public string ClientId {get;set;}
        public string Secret {get;set;}
        public List<Endpoint> Endpoints {get;set;}

        public class Endpoint 
        {
            public string Chave{get;set;}
            public string Url {get;set;}
            public string HttpMetodo{get;set;}
        }

        public CRMHelperDictionary ConverterParaCRMHelperDictionary()
        {
            var dicionario = new CRMHelperDictionary();
            this.Endpoints.ForEach(item => dicionario.Add(item.Chave,new CRMHelperUriDetail(){Url=item.Url, HttpMetodo = item.HttpMetodo}));
            return dicionario;
        }
    }
}