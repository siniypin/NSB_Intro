using System;
using Example1.Contracts.Sales;
using NServiceBus;
#pragma warning disable 618

namespace Example1.Billing
{
    public class EndpointConfigurator : IConfigureThisEndpoint
    {
        public void Customize(EndpointConfiguration endpointConfiguration)
        {
            //configure OS components, etc
            endpointConfiguration.EnableInstallers();
            //store subscriptions, timeouts, saga data in memory
            endpointConfiguration.UsePersistence<InMemoryPersistence>();
            //use msmq as a queuing transport
            var transport = endpointConfiguration.UseTransport<MsmqTransport>();
            //subscribe to sales events
            transport.Routing().RegisterPublisher(typeof(OrderAcceptedEvent), "Example1.Sales");
            //set 2d level error policy properties
            endpointConfiguration.Recoverability().Delayed(x =>
            {
                x.NumberOfRetries(2);
                x.TimeIncrease(TimeSpan.FromSeconds(10));
            });
            //define 3d level error handling strategy destination
            endpointConfiguration.SendFailedMessagesTo("errors");
            //enable audit
            endpointConfiguration.AuditProcessedMessagesTo("audit");
            //explain how to map names to concepts
            endpointConfiguration.Conventions()
                .DefiningCommandsAs(x => x.Name.EndsWith("Command"))
                .DefiningEventsAs(x =>
                    x.Namespace != null && x.Namespace.Contains("Contracts") && x.Name.EndsWith("Event"));
        }
    }
}