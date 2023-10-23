using System.ComponentModel.DataAnnotations;

namespace PizzaGroup.Models
{
    public class Crust
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Decimal Price { get; set; }
        public ICollection<Pizza> Pizzas { get; set; } = new List<Pizza>();
    }
}
