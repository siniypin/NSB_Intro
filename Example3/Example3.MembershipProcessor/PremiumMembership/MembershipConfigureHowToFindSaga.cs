using System;
using NServiceBus;
using NServiceBus.Saga;
using Example3.Contracts.Payments;


namespace Example3.PremiumMembership
{
    public partial class Membership
    {
        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<MembershipSagaData> mapper)
        {
            mapper.ConfigureMapping<ContractCreatedEvent>(x => x.UserId).ToSaga(x => x.UserId);
            mapper.ConfigureMapping<InvoiceSentToCollection>(x => x.UserId).ToSaga(x => x.UserId);
            
            // If you add new messages to be handled by your saga, you will need to manually add a call to ConfigureMapping for them.
        }
    }
}
