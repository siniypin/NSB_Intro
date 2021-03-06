using System;
using Example2.Contracts.Marketing;

namespace Example2.Contracts.Payments
{
    public interface ContractCreatedEvent
    {
        int UserId { get; set; }
    }

    public interface ContractCreatedExtendedEvent : ContractCreatedEvent//, CampaignActivityOccured
    {
        DateTime Date { get; set; }
    }
}
