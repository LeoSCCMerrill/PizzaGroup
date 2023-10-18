namespace PizzaGroup.Models
{
    public class CustomizeViewModel
    {
        public Pizza Pizza { get; set; }
        public IDictionary<Topping, bool> ToppingDictionary { get; set; } = new Dictionary<Topping, bool>();

    }
}
