using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advert.API.Contracts.V1
{
    public static class ApiRoutes
    {
        public const string Root = "api";

        public const string Version = "v1";

        public const string Base = Root + "/" + Version;

        internal static class Campaigns
        {
            public const string GetAll = Base + "/Campaigns";

            public const string Get = Base + "/Campaigns/{id}";
        }
    }
}
