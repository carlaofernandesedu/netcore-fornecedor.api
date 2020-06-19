namespace br.procon.si.api.crm.Contracts
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