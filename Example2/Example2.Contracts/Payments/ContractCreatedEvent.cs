using System;

namespace Example2.Contracts.Payments
{
    public interface ContractCreatedEvent
    {
        int UserId { get; set; }
    }

    public interface ContractCreatedExtendedEvent : ContractCreatedEvent
    {
        DateTime Date { get; set; }
    }
}
