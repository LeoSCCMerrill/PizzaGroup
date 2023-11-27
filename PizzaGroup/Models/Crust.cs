using System.ComponentModel.DataAnnotations;

namespace PizzaGroup.Models
{
    public class Crust
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public IList<Pizza> Pizzas { get; set; } = new List<Pizza>();
    }
}
