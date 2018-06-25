//using System;
//using NServiceBus;
//using System.Diagnostics;
//using System.Threading.Tasks;
//using Example1.Contracts.Sales;
//
//namespace Example1.Billing
//{
//    static class Program    
//    {
//        static async Task Main()
//        {
//            Console.Title = "Example1.PaymentGateway";
//            var endpointConfiguration = new EndpointConfiguration("Example1.PaymentGateway");
//
//            endpointConfiguration.EnableInstallers();
//            endpointConfiguration.UsePersistence<InMemoryPersistence>();
//            var transport = endpointConfiguration.UseTransport<MsmqTransport>();
//            transport.Routing().RegisterPublisher(typeof(OrderPlacedEvent), "Example1.Sales");
//            endpointConfiguration.SendFailedMessagesTo("billingErrorQueue");
//            endpointConfiguration.AuditProcessedMessagesTo("auditQueue");
//            endpointConfiguration.Conventions()
//                .DefiningCommandsAs(x => x.Name.EndsWith("Command"))
//                .DefiningEventsAs(x => x.Namespace != null && x.Namespace.Contains("Contracts") && x.Name.EndsWith("Event"));
//            endpointConfiguration.Recoverability().Delayed(x =>
//            {
//                x.NumberOfRetries(2);
//                x.TimeIncrease(TimeSpan.FromSeconds(10));
//            });
//
//            var endpointInstance = await Endpoint.Start(endpointConfiguration)
//                .ConfigureAwait(false);
//            Console.WriteLine("Press any key to exit");
//            Console.ReadKey();
//            await endpointInstance.Stop()
//                .ConfigureAwait(false);
//        }
//    }
//}
