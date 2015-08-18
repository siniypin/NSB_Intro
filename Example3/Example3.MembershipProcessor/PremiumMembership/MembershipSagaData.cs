using System;
using NServiceBus;
using NServiceBus.Saga;


namespace Example3.PremiumMembership
{
    public partial class MembershipSagaData
    {
        public int UserId { get; set; }
        public bool IsPremium { get; set; }
    }
}
