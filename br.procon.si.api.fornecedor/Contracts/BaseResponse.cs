namespace br.procon.si.api.fornecedor.Contracts
{
    public class BaseResponse<T>
    {
        public BaseResponse()
        {
            
        }
        public BaseResponse(T response) => Data = response;
        
        public T Data {get;set;}
    }
}