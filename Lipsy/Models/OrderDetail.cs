namespace Lipsy.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int DrinkId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public virtual Lipstick Lipstick { get; set; }
        public virtual Order Order { get; set; }
    }
}