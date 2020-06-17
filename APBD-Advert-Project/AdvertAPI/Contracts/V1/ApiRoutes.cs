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

        public static readonly string Base = $"{Root}/{Version}";
    }
}
