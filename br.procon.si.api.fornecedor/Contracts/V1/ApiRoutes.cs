namespace br.procon.si.api.fornecedor.Contracts.V1
{
    public class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public class Fichas
        {
            public const string Get = Base + "/Fichas/Listar";

            public const string GetMediator = Base + "/Fichas/Mediator/Listar";
        }
    }
}