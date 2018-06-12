using System;
using System.Threading.Tasks;
using Example1.Contracts.Sales;
using NServiceBus;

namespace Example1.Sales
{
    public class PlaceOrderCommandHandler : IHandleMessages<PlaceOrderCommand>
    {
		public Task Handle(PlaceOrderCommand message, IMessageHandlerContext context)
        {
            Console.WriteLine("Sales order processor received a " + message);
            context.Publish(new OrderPlacedEvent {UserId = message.UserId});
            return Task.CompletedTask;
        }
    }
}
