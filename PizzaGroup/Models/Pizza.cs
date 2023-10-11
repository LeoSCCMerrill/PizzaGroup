using System.ComponentModel.DataAnnotations;

namespace PizzaGroup.Models
{
    public class Pizza
    {
        [Key]
        public int PizzaID { get; set; } //PK
        [Required(ErrorMessage = "Please enter a pizza name")]
        public string PizzaName { get; set; }
        [Required(ErrorMessage = "Please enter a pizza price")]
        public double PizzaPrice { get; set; }
        [Required(ErrorMessage = "Please select a pizza price")]
        public string PizzaSize { get; set; }
        [Required(ErrorMessage = "Please select a pizza size")]
        public string PizzaCrust { get; set; }
        public ICollection<PizzaTopping>? PizzaToppings { get; set; }
    }
}
