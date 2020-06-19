namespace br.procon.si.api.crm.Contracts.V1
{
    public class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public class Eventos
        {
            public const string Get = Base + "/Eventos/Listar";

        }
    }
}