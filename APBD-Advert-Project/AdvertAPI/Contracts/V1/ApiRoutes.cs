namespace Advert.API.Contracts.V1
{
    public static class ApiRoutes
    {
        private const string Root = "api";

        private const string Version = "v1";

        private const string Base = Root + "/" + Version;

        internal static class Campaigns
        {
            public const string GetAll = Base + "/Campaigns";

            public const string Get = Base + "/Campaigns/{id:int}";

            public const string Create = Base + "/Campaigns";
        }

        internal static class Clients
        {
            public const string GetAll = Base + "/Clients";

            public const string Get = Base + "/Clients/{id:int}";

            public const string Create = Base + "/Clients";

            public const string LogIn = Base + "/Clients/login";

            public const string Refresh = Base + "/Clients/refresh";
        }

        internal static class Buildings
        {
            public const string GetAll = Base + "/Buildings";

            public const string Get = Base + "/Buildings/{id:int}";
        }
    }
}