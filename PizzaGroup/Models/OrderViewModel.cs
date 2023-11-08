namespace PizzaGroup.Models
{
    public class OrderViewModel
    {
        public Order? Order { get; set; }
        public List<OrderPizza>? OrderPizzas { get; set; }
        public List<Pizza>? Pizzas { get; set; }
    }
}
