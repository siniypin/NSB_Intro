using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example1.Contracts.Billing;
using Example1.Contracts.Sales;
using NServiceBus;

namespace Eample1.Content
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "Example1.Content";
            var endpointConfiguration = new EndpointConfiguration("Example1.Content");
            endpointConfiguration.EnableInstallers();
            endpointConfiguration.UsePersistence<InMemoryPersistence>();
            var transport = endpointConfiguration.UseTransport<MsmqTransport>();
            transport.Routing().RegisterPublisher(typeof(OrderAcceptedEvent), "Example1.Sales");
            transport.Routing().RegisterPublisher(typeof(OrderBilledEvent), "Example1.Billing");
            endpointConfiguration.SendFailedMessagesTo("errors");
            endpointConfiguration.AuditProcessedMessagesTo("audit");
            endpointConfiguration.Conventions()
                .DefiningCommandsAs(x => x.Name.EndsWith("Command"))
                .DefiningEventsAs(x => x.Name.EndsWith("Event"));

            var endpointInstance = await Endpoint.Start(endpointConfiguration)
                .ConfigureAwait(false);
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            await endpointInstance.Stop()
                .ConfigureAwait(false);
        }
    }
}
