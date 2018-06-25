using System;
using System.Threading.Tasks;
using Example1.Contracts.Sales;
using NServiceBus;

namespace Example1.Sales
{
    public class PlaceOrderCommandHandler : IHandleMessages<PlaceOrderCommand>
    {
        public async Task Handle(PlaceOrderCommand message, IMessageHandlerContext context)
        {
            Console.WriteLine("Sales order processor received a " + message);
            //Calculate discounts
            //Correct product price with various policies
            //Store the order

            await context.Publish(new OrderPlacedEvent {UserId = message.UserId}).ConfigureAwait(false);
            await context.Publish(new OrderAcceptedEvent {UserId = message.UserId, OrderId = Guid.NewGuid()})
                .ConfigureAwait(false);
            await Task.CompletedTask;
        }
    }
}