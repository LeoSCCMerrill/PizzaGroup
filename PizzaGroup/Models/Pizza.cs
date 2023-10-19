using System.ComponentModel.DataAnnotations;

namespace PizzaGroup.Models
{
    public class Pizza
    {
        [Key]
        public int PizzaID { get; set; } //PK
        [Required(ErrorMessage = "Please enter a pizza name")]
        public string PizzaName { get; set; }
        public double? PizzaPrice { get; set; }
        [Required(ErrorMessage = "Please choose a size")]
        public int SizeId { get; set; }
        public Size PizzaSize { get; set; }
        [Required(ErrorMessage = "Please choose a crust")]
        public int CrustId { get; set; }
        public Crust PizzaCrust { get; set; }
        public ICollection<PizzaTopping>? PizzaToppings { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
