using System;
using Example1.Contracts.Sales;
using NServiceBus;

namespace Example1.PaymentGateway
{
    public class EndpointConfigurator : IConfigureThisEndpoint
    {
        public void Customize(EndpointConfiguration endpointConfiguration)
        {
            endpointConfiguration.EnableInstallers();
            endpointConfiguration.UsePersistence<InMemoryPersistence>();
            var transport = endpointConfiguration.UseTransport<MsmqTransport>();
            transport.Routing().RegisterPublisher(typeof(OrderPlacedEvent), "Example1.Sales");
            endpointConfiguration.SendFailedMessagesTo("billingErrorQueue");
            endpointConfiguration.AuditProcessedMessagesTo("auditQueue");
            endpointConfiguration.Conventions()
                .DefiningCommandsAs(x => x.Name.EndsWith("Command"))
                .DefiningEventsAs(x => x.Namespace != null && x.Namespace.Contains("Contracts") && x.Name.EndsWith("Event"));
            endpointConfiguration.Recoverability().Delayed(x =>
            {
                x.NumberOfRetries(2);
                x.TimeIncrease(TimeSpan.FromSeconds(10));
            });
        }
    }
}
