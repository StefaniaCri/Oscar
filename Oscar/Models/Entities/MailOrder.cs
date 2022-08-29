namespace Oscar.Models.Entities
{
    public class MailOrder: Order
    {
        public string Email { get; set; }
        public int OrderId { get; set; }

        public Order order { get; set; }
    }
}
