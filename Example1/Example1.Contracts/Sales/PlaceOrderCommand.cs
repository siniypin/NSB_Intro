namespace Example1.Contracts.Sales
{
    public class PlaceOrderCommand
    {
        public int UserId { get; set; }
        public int Amount { get; set; }

        public override string ToString()
        {
            return "PlaceOrderCommand: UserId=" + UserId + ", Amount=" + Amount;
        }
    }
}
