namespace PizzaGroup.Models
{
    public class Topping
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Decimal Price { get; set; }
        public ICollection<Pizza>? Pizzas { get; set; }
        public ToppingType ToppingType { get; set; }
    }
}
