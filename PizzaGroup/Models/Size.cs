namespace PizzaGroup.Models
{
    public class Size
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Inches { get; set; }
        public Decimal PriceMultiplier { get; set; }
        public ICollection<Pizza> Pizzas { get; set; } = new List<Pizza>();
    }
}
