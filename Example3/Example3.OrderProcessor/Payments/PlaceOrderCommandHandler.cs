using System;
using NServiceBus;
using Example3.Internal.Commands.Payments;


namespace Example3.Payments
{
    public partial class PlaceOrderCommandHandler
    {
		
        partial void HandleImplementation(PlaceOrderCommand message)
        {
            // TODO: PlaceOrderCommandHandler: Add code to handle the PlaceOrderCommand message.
            Console.WriteLine("Payments received " + message.GetType().Name);
            var createInvoiceCommand = new Example3.Internal.Commands.Payments.CreateInvoiceCommand() { UserId = message.UserId };
            Bus.Send(createInvoiceCommand);
            var contractCreatedEvent = new Example3.Contracts.Payments.ContractCreatedEvent() { UserId = message.UserId };
            Bus.Publish(contractCreatedEvent);
        }

    }
}
