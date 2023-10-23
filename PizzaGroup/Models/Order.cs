using System.ComponentModel.DataAnnotations;

namespace PizzaGroup.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required(ErrorMessage = "Please Enter A CustomerID")] 
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public IList<Pizza> Pizzas { get; set; }


        
    }
}
