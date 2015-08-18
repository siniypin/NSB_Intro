using NServiceBus;
using System;

namespace Example1.Internal.Commands.Payments
{
    public class PlaceOrderCommand
    {
        public int UserId { get; set; }
        public int Price { get; set; }
    }
}
