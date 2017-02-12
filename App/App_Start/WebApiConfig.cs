using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace App
{
    public static class WebApiConfig
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            //自定义路由 wp 20150720
            config.Routes.MapHttpRoute(
               name: "InsusApi",
               routeTemplate: "api/{controller}/{action}/{id}",
               defaults: new { id = RouteParameter.Optional }
           );
            config.Routes.MapHttpRoute(
                                  name: "DefaultApi",
                                  routeTemplate: "api/{controller}/{id}",
                                  defaults: new { id = RouteParameter.Optional }
                              );

        }
    }
}
