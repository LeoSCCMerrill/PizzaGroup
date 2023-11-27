namespace PizzaGroup.Models
{
    public class OrderPizza
    {
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public Order? Order { get; set; }
        public int PizzaId { get; set; }
        public Pizza? Pizza { get; set; }
    }
}
