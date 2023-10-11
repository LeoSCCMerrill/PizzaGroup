namespace PizzaGroup.Models
{
    public class CustomizeViewModel
    {
        public Pizza Pizza { get; set; }
        public List<Size> Sizes { get; set; }
        public List<Crust> Crusts { get; set; }
        public List<Topping> Toppings { get; set; }

    }
}
