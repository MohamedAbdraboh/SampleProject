using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.App.Api.Routes.V1
{
    public static class APIRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class Status
        {
            public const string Get = Base + "/Status/{id}";
            public const string GetAll = Base + "/Status";
            public const string Create = Base + "/Status";
            public const string Update = Base + "/Status/{id}";
            public const string Delete = Base + "/Status/{id}";
        }

        public static class SubStatus
        {
            public const string Get = Base + "/SubStatus/{id}";
            public const string GetAll = Base + "/SubStatus";
            public const string GetStatusSubstatues = Base + "/SubStatus/{statusId}";
            public const string Create = Base + "/SubStatus";
            public const string Update = Base + "/SubStatus/{id}";
            public const string Delete = Base + "/SubStatus/{id}";
        }

        public static class Tag
        {
            public const string Get = Base + "/Tag/{id}";
            public const string GetAll = Base + "/Tag";
            public const string Create = Base + "/Tag";
            public const string Update = Base + "/Tag/{id}";
            public const string Delete = Base + "/Tag/{di}";
        }

        public static class Identity
        {
            public const string Login = Base + "/idenity/login";
            public const string Register = Base + "/identity/register";
        }
    }
}
