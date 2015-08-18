using System;
using NServiceBus;
using Example3.Internal.Commands.Payments;
using System.Timers;


namespace Example3.Payments
{
    public partial class CreateInvoiceCommandHandler
    {
        public Schedule Scheduler { get; set; }

        partial void HandleImplementation(CreateInvoiceCommand message)
        {
            // TODO: CreateInvoiceCommandHandler: Add code to handle the CreateInvoiceCommand message.
            Console.WriteLine("Payments received " + message.GetType().Name);
            //Scheduler.Every(TimeSpan.FromSeconds(10), () =>
            //{
            //    Bus.Publish<Example3.Contracts.Payments.InvoiceSentToCollection>(x => { x.UserId = message.UserId; });
            //});
        }
    }
}
