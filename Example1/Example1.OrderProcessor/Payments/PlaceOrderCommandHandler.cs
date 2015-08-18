using System;
using NServiceBus;
using Example1.Internal.Commands.Payments;


namespace Example1.Payments
{
    public partial class PlaceOrderCommandHandler
    {
		
        partial void HandleImplementation(PlaceOrderCommand message)
        {
            // TODO: PlaceOrderCommandHandler: Add code to handle the PlaceOrderCommand message.
            Console.WriteLine("Payments received " + message.GetType().Name);
            var createInvoiceCommand = new Example1.Internal.Commands.Payments.CreateInvoiceCommand();
            Bus.Send(createInvoiceCommand);
        }

    }
}
