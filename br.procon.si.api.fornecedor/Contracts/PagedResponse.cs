using System.Collections.Generic;

namespace br.procon.si.api.fornecedor.Contracts
{
    public class PagedResponse<T>
    {
        public PagedResponse() {}
        public PagedResponse(IEnumerable<T> data)
        {
            Data = data;
        }
        public IEnumerable<T> Data { get; set; }

        public int? PageSize {get;set;}
        public int? PageNumber {get;set;}
        public string  NextPage {get;set;}
        public string PreviousPage {get;set;}
    }
}