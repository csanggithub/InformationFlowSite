using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace InformationFlow.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //string filePath = Server.MapPath("~/log4net.config");
            //FileInfo fil = new FileInfo(filePath);
            //log4net.Config.XmlConfigurator.Configure(fil); //将创建的log4net.config文件加载我到我们的项目中来  
            //以上三句代码可以用下面这一句替代  
            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(Server.MapPath("~/log4net.config")));
        }
    }
}
