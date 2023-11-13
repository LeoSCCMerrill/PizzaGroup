using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaGroup.Models;
//{
public class Order
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Please Enter A CustomerID")]
    public string CustomerId { get; set; }
    public string EmployeeId { get; set; }
    public OrderStatus OrderStatus { get; set; } // Change Back to OrderStatus Later
    [NotMapped]
    public IDictionary<int, int> Pizzas { get; set; }
    [NotMapped]
    public IList<Pizza> PizzaList { get; set; } = new List<Pizza>();
    public IList<OrderPizza> OrderPizza { get; set; } = new List<OrderPizza>();
    public Order()
    {
        Pizzas = new Dictionary<int, int>();
        PizzaList = new List<Pizza>();
    }



}

