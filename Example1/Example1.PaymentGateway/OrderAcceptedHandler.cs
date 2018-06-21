using System;
using System.Threading.Tasks;
using Example1.Contracts.Billing;
using Example1.Contracts.Sales;
using NServiceBus;

namespace Example1.Billing
{
    public class OrderAcceptedHandler : IHandleMessages<OrderAcceptedEvent>
    {
        public async Task Handle(OrderAcceptedEvent message, IMessageHandlerContext context)
        {
            Console.WriteLine("OrderAcceptedHandler received a " + message + " event");
            //pull up users' payment account
            //call out to a payment processor to charge a payment instrument configured
            //process results, store to db
            await context.Publish(new OrderBilledEvent {UserId = message.UserId, OrderId = message.OrderId})
                .ConfigureAwait(false);
        }
    }
}