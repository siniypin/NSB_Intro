using NServiceBus;

namespace Example1.Contracts.Sales
{
    public class OrderPlacedEvent
    {
        public int UserId { get; set; }

        public override string ToString()
        {
            return "OrderPlacedEvent: UserId=" + UserId;
        }
    }
}
