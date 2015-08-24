using System;
using NServiceBus;
using Example2.Internal.Commands.Payments;
using Example2.Contracts.Payments;


namespace Example2.Payments
{
    public partial class CreateInvoiceCommandHandler
    {
        //public Schedule Scheduler { get; set; }

        partial void HandleImplementation(CreateInvoiceCommand message)
        {
            // TODO: CreateInvoiceCommandHandler: Add code to handle the CreateInvoiceCommand message.
            Console.WriteLine("Payments received " + message.GetType().Name);
            //Scheduler.Every(TimeSpan.FromSeconds(5), () => Bus.Publish<InvoiceSentInEncashmentEvent>(x => x.UserId = message.UserId));
        }

    }
}
