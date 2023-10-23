using System.ComponentModel.DataAnnotations;

namespace PizzaGroup.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter A CustomerID")] 
        public string CustomerId { get; set; }
        public string EmployeeId { get; set; }
        public string OrderStatus { get; set; }
        public IList<Pizza> Pizzas { get; set; }


        
    }
}
