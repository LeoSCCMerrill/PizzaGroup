using System.ComponentModel.DataAnnotations;

namespace PizzaGroup.Models
{
    public class Topping
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "You must enter a topping name")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Price is required")]
        [Range(0, 999.99)]
        public decimal Price { get; set; } = decimal.Zero;
        public ICollection<Pizza> Pizzas { get; set; } = new List<Pizza>();
        public ToppingType ToppingType { get; set; }
    }
}
