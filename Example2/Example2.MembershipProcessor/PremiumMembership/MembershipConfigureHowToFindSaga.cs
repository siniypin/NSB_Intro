using System;
using NServiceBus;
using Example2.Contracts.Payments;
using NServiceBus.Saga;


namespace Example2.PremiumMembership
{
    public partial class Membership
    {
        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<MembershipSagaData> mapper)
        {
            mapper.ConfigureMapping<OrderPlacedEvent>(x => x.UserId).ToSaga(x => x.UserId);
            mapper.ConfigureMapping<InvoiceSentInEncashmentEvent>(x => x.UserId).ToSaga(x => x.UserId);
            
            // If you add new messages to be handled by your saga, you will need to manually add a call to ConfigureMapping for them.
        }
    }
}
