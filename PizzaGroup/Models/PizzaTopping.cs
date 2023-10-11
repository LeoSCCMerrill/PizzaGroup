namespace PizzaGroup.Models
{
    public class PizzaTopping
    {
        
        public int PizzaID { get; set; }
        public int ToppingID { get; set; }


        public Pizza Pizza { get; set; }
        public Topping Topping { get; set; }

    }
}
