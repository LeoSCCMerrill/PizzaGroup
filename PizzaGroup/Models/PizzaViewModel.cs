namespace PizzaGroup.Models
{
    public class PizzaViewModel
    {
        public Pizza Pizza { get; set; }
        public IList<PizzaTopping> PizzaToppings { get; set; }
        public IList<Topping> Toppings { get; set; }


    }
}
