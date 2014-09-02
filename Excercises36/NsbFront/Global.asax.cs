using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using NServiceBus;
using NServiceBus.Installation.Environments;

namespace NsbFront
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        public static IBus Bus { get; private set; }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Configure.Serialization.Xml(s => s.Namespace("http://acme.com/"));

            //Bus = Configure.With()
            //       .DefaultBuilder()
            //       .RijndaelEncryptionService() // Encryption
            //       .UseTransport<Msmq>() // Msmq as the queuing system.
            //       .UnicastBus() // Creates the bus
            //       .SendOnly();

            Bus = Configure.With()
                .DefaultBuilder()
                .RijndaelEncryptionService()
                .InMemoryFaultManagement()
                .UseTransport<Msmq>()
                .UnicastBus()
                .CreateBus()
                .Start(() => Configure.Instance
                    .ForInstallationOn<Windows>().Install());
        }
    }
}