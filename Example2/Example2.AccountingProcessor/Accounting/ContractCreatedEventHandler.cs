using System;
using NServiceBus;
using Example2.Contracts.Payments;


namespace Example2.Accounting
{
    public partial class ContractCreatedEventHandler
    {
		
        partial void HandleImplementation(ContractCreatedEvent message)
        {
            // TODO: ContractCreatedEventHandler: Add code to handle the ContractCreatedEvent message.
            Console.WriteLine("Accounting received " + message.GetType().Name);
        }

    }
}
