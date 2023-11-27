using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaGroup.Models;
//{
public class Order
{
    [Key]
    public int Id { get; set; }
    public string CustomerId { get; set; } = string.Empty;
    public string EmployeeId { get; set; } = string.Empty;
    public OrderStatus OrderStatus { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    [NotMapped]
    public IDictionary<int, int> Pizzas { get; set; } = new Dictionary<int, int>();
    [NotMapped]
    public IList<Pizza> PizzaList { get; set; } = new List<Pizza>();
    public IList<OrderPizza> OrderPizza { get; set; } = new List<OrderPizza>();
    public Order()
    {
        Pizzas = new Dictionary<int, int>();
        PizzaList = new List<Pizza>();
    }



}

