using System.ComponentModel.DataAnnotations;

namespace PizzaGroup.Models
{
    public class Pizza
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a pizza name")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please choose a size")]
        public int SizeId { get; set; }
        public Size? Size { get; set; }
        [Required(ErrorMessage = "Please choose a crust")]
        public int CrustId { get; set; }
        public Crust? Crust { get; set; }
        public decimal Price { get; set; } = decimal.Zero;
        public IList<Topping> Toppings { get; set; } = new List<Topping>();
        public IList<Order> Orders { get; set; } = new List<Order>();
        public IList<PizzaTopping> PizzaToppings { get; set; } = new List<PizzaTopping>();
        public IList<OrderPizza> OrderPizzas { get; set; } = new List<OrderPizza>();
        public string? UserId { get; set; }
        public User? User { get; set; }
    }
}
