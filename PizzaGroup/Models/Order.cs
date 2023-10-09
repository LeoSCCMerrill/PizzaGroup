using System.ComponentModel.DataAnnotations;

namespace PizzaGroup.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        [Required(ErrorMessage = "Please Enter A CustomerID")] 
        public int customerID { get; set; }
        [Required(ErrorMessage = "Please Enter A PizzaID")]
        public int PizzaID { get; set; }

        
    }
}
