using System;
using NServiceBus;
using Example1.Internal.Commands.Payments;


namespace Example1.Payments
{
    public partial class CreateInvoiceCommandHandler
    {
		
        partial void HandleImplementation(CreateInvoiceCommand message)
        {
            // TODO: CreateInvoiceCommandHandler: Add code to handle the CreateInvoiceCommand message.
            Console.WriteLine("Payments received " + message.GetType().Name);
        }

    }
}
