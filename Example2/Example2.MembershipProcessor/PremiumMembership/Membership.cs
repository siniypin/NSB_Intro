using System;
using NServiceBus;
using Example2.Contracts.Payments;
using Example2.Internal.Events.PremiumMembership;
using NServiceBus.Saga;


namespace Example2.PremiumMembership
{
    public partial class Membership : IHandleTimeouts<MembershipExpiredTimeout>
    {
		
        partial void HandleImplementation(OrderPlacedEvent message)
        {
            // TODO: Membership: Add code to handle the OrderPlacedEvent message.
            Console.WriteLine("PremiumMembership received " + message.GetType().Name);
            Data.UserId = message.UserId;
            Data.IsPremium = true;
            Console.WriteLine("User {0} became premium", Data.UserId);

            RequestTimeout(TimeSpan.FromSeconds(10), new MembershipExpiredTimeout());
        }

        partial void HandleImplementation(InvoiceSentInEncashmentEvent message)
        {
            // TODO: Membership: Add code to handle the InvoiceSentInEncashmentEvent message.
            Console.WriteLine("PremiumMembership received " + message.GetType().Name);

            Data.IsPremium = false;
            Console.WriteLine("User {0} became basic due to dunned invoice", Data.UserId);
        }

        public void Timeout(MembershipExpiredTimeout timeout)
        {
            if (Data.IsPremium)
            {
                Data.IsPremium = false;
                Console.WriteLine("User {0} became basic due to expired membership", Data.UserId);
            }
        }

    }
}
