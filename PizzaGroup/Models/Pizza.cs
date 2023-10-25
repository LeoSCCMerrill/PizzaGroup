using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaGroup.Models
{
    public class Pizza
    {
        [Key]
        public int Id { get; set; } //PK
        [Required(ErrorMessage = "Please enter a pizza name")]
        public string? Name { get; set; }
        
        [Required(ErrorMessage = "Please choose a size")]
        public int SizeId { get; set; }
        public Size? Size { get; set; }
        [Required(ErrorMessage = "Please choose a crust")]
        public int CrustId { get; set; }
        public Crust? Crust { get; set; }
        [NotMapped]
        public Decimal Price { get; set; }
        public IList<Topping>? Toppings { get; set; } = new List<Topping>();
        public IList<Order>? Orders { get; set; } = new List<Order>();
        public IList<PizzaTopping>? PizzaToppings { get; set; } = new List<PizzaTopping>();
        public string? UserId { get; set; }
        public User? User { get; set; }

        
    }
}
