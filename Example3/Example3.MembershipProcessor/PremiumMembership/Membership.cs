using System;
using NServiceBus;
using Example3.Contracts.Payments;
using NServiceBus.Saga;


namespace Example3.PremiumMembership
{
    public partial class Membership : IHandleTimeouts<MembershipExpired>
    {
		
        partial void HandleImplementation(ContractCreatedEvent message)
        {
            // TODO: Membership: Add code to handle the ContractCreatedEvent message.
            Console.WriteLine("PremiumMembership received " + message.GetType().Name);
            Console.WriteLine("User {0} became premium", message.UserId);
            Data.UserId = message.UserId;
            Data.IsPremium = true;
            RequestTimeout<MembershipExpired>(TimeSpan.FromSeconds(30), new MembershipExpired { UserId = Data.UserId });
        }

        partial void HandleImplementation(InvoiceSentToCollection message)
        {
            // TODO: Membership: Add code to handle the InvoiceSentToCollection message.
            Console.WriteLine("PremiumMembership received " + message.GetType().Name);
            Console.WriteLine("Premium membership of user {0} was paused due to invoice encashment", message.UserId);
            Data.IsPremium = false;
        }

        public void Timeout(MembershipExpired state)
        {
            if (Data.IsPremium)
            {
                Data.IsPremium = false;
                Console.WriteLine("Premium membership of user {0} has ran to an end", state.UserId);
            }
        }

    }

    public class MembershipExpired : IMessage
    {
        public int UserId { get; set; }
    }
}
