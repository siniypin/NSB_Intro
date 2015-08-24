using System;
using NServiceBus;
using Example2.Internal.Commands.Payments;
using Example2.Contracts.Payments;


namespace Example2.Payments
{
    public partial class PlaceOrderCommandHandler
    {
		
        partial void HandleImplementation(PlaceOrderCommand message)
        {
            // TODO: PlaceOrderCommandHandler: Add code to handle the PlaceOrderCommand message.
            Console.WriteLine("Payments received " + message.GetType().Name);
            var createInvoiceCommand = new Example2.Internal.Commands.Payments.CreateInvoiceCommand { UserId = message.UserId };
            Bus.Send(createInvoiceCommand);
            
            Bus.Publish<ContractCreatedEvent>(x => x.UserId = message.UserId);
            //Bus.Publish<ContractCreatedExtendedEvent>(x => x.UserId = message.UserId);
            
            
            var orderPlacedEvent = new Example2.Contracts.Payments.OrderPlacedEvent { UserId = message.UserId };
            Bus.Publish(orderPlacedEvent);
        }
    }
}
