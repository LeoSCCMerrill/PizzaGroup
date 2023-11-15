using System.ComponentModel.DataAnnotations;

namespace PizzaGroup.Models
{
    public class Topping
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="You must enter a topping name")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Price is required")]
        [Range(0, 999.99)]
        public Decimal? Price { get; set; } 
        public ICollection<Pizza>? Pizzas { get; set; }
        public ToppingType ToppingType { get; set; }
    }
}
