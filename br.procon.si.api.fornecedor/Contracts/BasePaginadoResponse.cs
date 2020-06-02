using System.Collections.Generic;

namespace br.procon.si.api.fornecedor.Contracts
{
    public class BasePaginadoResponse<T>
    {
        public BasePaginadoResponse() {}
        public BasePaginadoResponse(IEnumerable<T> data)
        {
            Data = data;
        }
        public IEnumerable<T> Data { get; set; }

        public int? TamanhoPagina {get;set;}
        public int? NumeroPagina {get;set;}
        public string ProximaPagina {get;set;}
        public string PaginaAnterior {get;set;}
    }
}