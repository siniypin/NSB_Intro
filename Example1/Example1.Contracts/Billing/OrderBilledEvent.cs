using System;

namespace Example1.Contracts.Billing
{
    public class OrderBilledEvent
    {
        public int UserId { get; set; }
        public Guid OrderId { get; set; }

        public override string ToString()
        {
            return "OrderBilledEvent: UserId=" + UserId + ", OrderId=" + OrderId;
        }
    }
}