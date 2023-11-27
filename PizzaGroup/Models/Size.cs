namespace PizzaGroup.Models
{
    public class Size
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Inches { get; set; }
        public decimal PriceMultiplier { get; set; } = decimal.One;
        public ICollection<Pizza> Pizzas { get; set; } = new List<Pizza>();
    }
}
