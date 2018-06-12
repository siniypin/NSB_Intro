using System;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Features;

namespace Example1.Sales
{
    public static class Program
    {
        static async Task Main()
        {
            Console.Title = "Example1.Sales";
            var endpointConfiguration = new EndpointConfiguration("Example1.Sales");
            endpointConfiguration.EnableInstallers();
            endpointConfiguration.UsePersistence<InMemoryPersistence>();
            endpointConfiguration.UseTransport<MsmqTransport>();
            endpointConfiguration.SendFailedMessagesTo("salesErrorQueue");
            endpointConfiguration.AuditProcessedMessagesTo("auditQueue");
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
