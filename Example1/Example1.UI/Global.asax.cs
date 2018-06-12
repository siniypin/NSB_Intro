using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using NServiceBus;
using Autofac;
using Autofac.Integration.Mvc;
using NServiceBus.Features;

namespace Example1.UI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        private IEndpointInstance endpoint;

        protected void Application_Start()
        {
            var endpointConfiguration = new EndpointConfiguration("Example1.UI");

            endpointConfiguration.EnableInstallers();
            endpointConfiguration.UsePersistence<InMemoryPersistence>();
            endpointConfiguration.SendFailedMessagesTo("salesErrorQueue");
            endpointConfiguration.AuditProcessedMessagesTo("auditQueue");
            endpointConfiguration.UseTransport<MsmqTransport>();

            endpointConfiguration.Conventions().DefiningCommandsAs(x => x.Name.EndsWith("Command"));

            endpoint = Endpoint.Start(endpointConfiguration).GetAwaiter().GetResult();

            ContainerBuilder mvcContainerBuilder = new ContainerBuilder();
            mvcContainerBuilder.RegisterInstance(endpoint);

            // Register MVC controllers.
            mvcContainerBuilder.RegisterControllers(typeof(MvcApplication).Assembly);

            var mvcContainer = mvcContainerBuilder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(mvcContainer));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_End()
        {
            endpoint?.Stop().GetAwaiter().GetResult();
        }
    }
}