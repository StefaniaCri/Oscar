namespace Oscar.Models.Entities
{
    public class OnlineOrder: Order
    {
        public bool ? IsMember { get; set; }

        public string PromoCode { get; set; }
        public int OrderId { get; set; }
       public Order order { get; set; } 
    }
}
