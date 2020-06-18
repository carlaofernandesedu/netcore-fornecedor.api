using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace br.procon.si.api.crm.data.Standard.RestHttp
{
    public class CRMHelperDictionary : Dictionary<string,CRMHelperUriDetail>
    {
    }

    public class CRMHelperUriDetail
    {
        public string Url { get; set; }
        public string HttpMetodo { get; set; }
        public string FormatoConteudo { get; set; }
    
        public HttpMethod ObterMetodoHttp()
        {
            HttpMethod retorno = System.Net.Http.HttpMethod.Get;

            if (string.IsNullOrWhiteSpace(HttpMetodo))
                return retorno;

            switch (HttpMetodo.ToLower())
            {
                case "get":
                retorno = System.Net.Http.HttpMethod.Get;
                    break;
                case "post":
                    retorno = System.Net.Http.HttpMethod.Post;
                    break;
                case "put":
                    retorno = System.Net.Http.HttpMethod.Put;
                    break;
                case "delete":
                    retorno = System.Net.Http.HttpMethod.Delete;
                    break;
            }
            return retorno;
        }

        public string ObterMediaType()
        {
            return String.IsNullOrWhiteSpace(FormatoConteudo)? "application/json" : FormatoConteudo;
        }
    }
}
