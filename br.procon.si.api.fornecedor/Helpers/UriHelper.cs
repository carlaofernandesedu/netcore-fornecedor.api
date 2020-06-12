using System;
using br.procon.si.api.fornecedor.Contracts.V1.Requests;

namespace br.procon.si.api.fornecedor.Helpers
{
    public class UriHelper
    {
        private readonly string _baseUri;

        public UriHelper(string baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri ObterUriLocalizarPorId(string apiRoutes, string Id)
        {
          return new Uri(_baseUri + apiRoutes.Replace("{Id}",Id));
        } 

        public Uri ObterUriLocalizarPorPagina(string apiRoutes, BaseFiltroPaginadoRequest fitro = null)
        {
            //TODO: Implemenat Uri para pagina Numer de Pagina e Page Size
            throw new NotImplementedException();
        }
    }
}