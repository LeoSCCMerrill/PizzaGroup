namespace PizzaGroup.Models
{
    public class Topping
    {
        public int ToppingID { get; set; }
        public string ToppingName { get; set; }
        public Decimal ToppingPrice { get; set; }
        public ICollection<PizzaTopping> PizzaToppings { get; set; }
    }
}
