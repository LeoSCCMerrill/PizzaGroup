namespace PizzaGroup.Models
{
    public class PizzaTopping
    {
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; } = new Pizza();
        public int ToppingId { get; set; }
        public Topping Topping { get; set; } = new Topping();
    }
}
