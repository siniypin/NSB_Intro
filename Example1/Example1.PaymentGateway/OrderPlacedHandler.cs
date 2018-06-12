using System;
using System.Threading.Tasks;
using Example1.Contracts.Sales;
using NServiceBus;

namespace Example1.PaymentGateway
{
    public class OrderPlacedHandler : IHandleMessages<OrderPlacedEvent>
    {
        public Task Handle(OrderPlacedEvent message, IMessageHandlerContext context)
        {
            Console.WriteLine("OrderPlacedHandler received a " + message + " event");
            return Task.CompletedTask;
        }
    }
}
