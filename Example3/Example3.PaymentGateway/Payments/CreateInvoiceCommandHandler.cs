using System;
using NServiceBus;
using Example3.Internal.Commands.Payments;
using System.Timers;


namespace Example3.Payments
{
    public partial class CreateInvoiceCommandHandler
    {
        partial void HandleImplementation(CreateInvoiceCommand message)
        {
            // TODO: CreateInvoiceCommandHandler: Add code to handle the CreateInvoiceCommand message.
            Console.WriteLine("Payments received " + message.GetType().Name);
            var t = new Timer(5000);
            t.Elapsed += (s, e) =>
            {
                var invoiceSentToCollection = new Example3.Contracts.Payments.InvoiceSentToCollection() { UserId = message.UserId };
                Bus.Publish(invoiceSentToCollection);
                t.Dispose();
            };
            t.Start();
            GC.SuppressFinalize(t);
        }
    }
}
