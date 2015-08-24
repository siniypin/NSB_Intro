using System;
using NServiceBus;
using Example2.Contracts.Payments;
using NServiceBus.Saga;


namespace Example2.PremiumMembership
{
    public partial class MembershipSagaData
    {
        public int UserId { get; set; }
        public bool IsPremium { get; set; }
    }
}
