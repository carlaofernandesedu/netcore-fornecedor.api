using br.procon.si.api.crm.ConfigApp;
using br.procon.si.api.crm.data.Standard.RestHttp;

namespace br.procon.si.api.crm.Adapters
{
    public static class ParaCRMHelper
    {
        public static CRMHelperDictionary ConverterParaCRMHelperDictionary(CrmAPIOptions config)
        {
            var dicionario = new CRMHelperDictionary();
            config.Endpoints.ForEach(item => dicionario.Add(item.Chave,new CRMHelperUriDetail(){Url=item.Url, HttpMetodo = item.HttpMetodo}));
            return dicionario;
        }
    }
}