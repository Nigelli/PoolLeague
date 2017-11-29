using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace UIS.Pool
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
        }
    }
}
