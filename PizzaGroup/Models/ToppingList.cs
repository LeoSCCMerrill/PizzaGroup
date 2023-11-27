namespace PizzaGroup.Models
{
    public class ToppingList
    {
        public Topping Topping { get; set; } = new Topping();
        public bool IsSelected { get; set; }
    }
}
