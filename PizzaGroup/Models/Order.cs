using System.ComponentModel.DataAnnotations;

namespace PizzaGroup.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required(ErrorMessage = "Please Enter A CustomerID")] 
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public String OrderStatus { get; set; }
        public IList<Pizza> Pizzas { get; set; }


        
    }
}
