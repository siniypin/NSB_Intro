﻿using System;
using NServiceBus;
using Example2.Internal.Commands.Payments;


namespace Example2.Payments
{
    public partial class PlaceOrderCommandHandler
    {
		
        partial void HandleImplementation(PlaceOrderCommand message)
        {
            // TODO: PlaceOrderCommandHandler: Add code to handle the PlaceOrderCommand message.
            Console.WriteLine("Payments received " + message.GetType().Name);
            var createInvoiceCommand = new Example2.Internal.Commands.Payments.CreateInvoiceCommand();
            Bus.Send(createInvoiceCommand);
            var contractCreatedEvent = new Example2.Contracts.Payments.ContractCreatedEvent() { UserId = message.UserId };
            Bus.Publish(contractCreatedEvent);
        }

    }
}
