namespace br.procon.si.api.fornecedor.infra
{
    public class ResultadoValidator
    {
        public bool Sucesso {get;private set;}
        public string Mensagem{get;private set;}
        public object Criticas {get;private set;}

        public bool Falhou { get => !Sucesso; }

        public ResultadoValidator(bool sucesso, string mensagem = null, object data = null)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            Criticas = data;
        }

    }
}