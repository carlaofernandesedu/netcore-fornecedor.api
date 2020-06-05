namespace br.procon.si.api.fornecedor.infra
{
    public class ResultadoValidator
    {
        private bool _sucesso = true;
        public bool Sucesso
        {
            get { return _sucesso; }
            set { _sucesso = value; }
        }
        public object Criticas {get;private set;}
        public bool Falhou { get => !Sucesso; }

        public ResultadoValidator()
        {
        }
        public ResultadoValidator(bool sucesso, object data = null)
        {
            Sucesso = sucesso;
            Criticas = data;
        }

    }
}