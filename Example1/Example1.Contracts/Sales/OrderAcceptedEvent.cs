using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example1.Contracts.Sales
{
    public class OrderAcceptedEvent
    {
        public int UserId { get; set; }
        public Guid OrderId { get; set; }

        public override string ToString()
        {
            return "OrderAcceptedEvent: UserId=" + UserId + ", OrderId=" + OrderId;
        }
    }
}
