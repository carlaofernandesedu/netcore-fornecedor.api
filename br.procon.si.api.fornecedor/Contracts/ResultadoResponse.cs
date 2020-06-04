namespace br.procon.si.api.fornecedor.Contracts
{
    public class ResultadoResponse<T>
    {
        public ResultadoResponse()
        {
            
        }
        public ResultadoResponse(T response) => Data = response;
        
        public T Data {get;set;}
    }
}