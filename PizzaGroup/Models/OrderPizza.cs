namespace PizzaGroup.Models
{
    public class OrderPizza
    {
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; } = new Order();
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; } = new Pizza();
    }
}
