using Langben.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
 
namespace App
{
    public class MvcApplication : System.Web.HttpApplication 
    {
        /// <summary>  
        /// 解决BaseApiController中的HttpContext.Current.Session为null问题 zhangerhu
        /// </summary>
        public override void Init()
        {
            this.PostAuthenticateRequest += (sender, e) => HttpContext.Current.SetSessionStateBehavior(System.Web.SessionState.SessionStateBehavior.Required);
            base.Init();
        }
        protected void Application_Start()
        {
            //GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            //GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_Error(object sender, EventArgs e)
        {
            ExceptionHandlerStarter();
        }
        public void ExceptionHandlerStarter()
        {

            string s = HttpContext.Current.Request.Url.ToString();
            HttpServerUtility server = HttpContext.Current.Server;
            if (server.GetLastError() != null)
            {
                Exception lastError = server.GetLastError();
                Application["LastError"] = lastError;
                int statusCode = HttpContext.Current.Response.StatusCode;
                string exceptionOperator = System.Configuration.ConfigurationManager.AppSettings["ExceptionUrl"];

                Models.LogClassModels.WriteServiceLog("，人员的信息，ddw", "人员qqw"
                   );//写入日志 

                ExceptionsHander.WriteExceptions(lastError);//将异常写入数据库
                exceptionOperator = new System.Web.UI.Control().ResolveUrl(exceptionOperator);
                if (!String.IsNullOrEmpty(exceptionOperator) && !s.Contains(exceptionOperator))
                {
                    string url = string.Format("{0}?ErrorUrl={1}", exceptionOperator, server.UrlEncode(s));
                    string script = String.Format("<script language='javascript' type='text/javascript'>window.top.location='{0}';</script>", url);
                    Response.Write(script);
                    Response.End();
                }


            }
        }
    }
}

