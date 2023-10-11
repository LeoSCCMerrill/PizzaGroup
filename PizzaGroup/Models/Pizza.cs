namespace PizzaGroup.Models
{
    public class Pizza
    {
        public int PizzaID { get; set; } //PK
        public string PizzaName { get; set; }
        public double PizzaPrice { get; set; }
        public string PizzaSize { get; set; }
        public string PizzaCrust { get; set; }

        public ICollection<PizzaTopping>? PizzaToppings { get; set; }
    }
}
