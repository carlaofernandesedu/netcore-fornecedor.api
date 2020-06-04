namespace br.procon.si.api.fornecedor.Contracts.V1.Responses
{
    public class ResultadoCriticaResponse
    {
        public const string Mensagem = "Ocorreram problemas na validação";
        public object Data {get; private set;}
        public ResultadoCriticaResponse(object criticas)
        {
            Data = criticas;
        }
    }
}