using System.ComponentModel.DataAnnotations;

namespace PizzaGroup.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        [Required(ErrorMessage = "Please Enter A CustomerID")] 
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public ICollection<Pizza> Pizzas { get; set; }


        
    }
}
