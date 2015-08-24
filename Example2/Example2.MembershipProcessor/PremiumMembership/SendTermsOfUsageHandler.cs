using System;
using NServiceBus;
using Example2.Contracts.Payments;


namespace Example2.PremiumMembership
{
    public partial class SendTermsOfUsageHandler
    {
		
        partial void HandleImplementation(ContractCreatedEvent message)
        {
            // TODO: SendTermsOfUsageHandler: Add code to handle the ContractCreatedEvent message.
            Console.WriteLine("PremiumMembership received " + message.GetType().Name);
        }

    }
}
