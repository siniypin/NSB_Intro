using System;
using NServiceBus;
using Example2.Contracts.Payments;


namespace Example2.PremiumMembership
{
    public partial class ContractCreatedEventHandler
    {
		
        partial void HandleImplementation(ContractCreatedEvent message)
        {
            // TODO: ContractCreatedEventHandler: Add code to handle the ContractCreatedEvent message.
            Console.WriteLine("PremiumMembership received " + message.GetType().Name);
            Console.WriteLine("User {0} became premium member", message.UserId);
        }

    }
}
