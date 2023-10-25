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

        private Decimal _Price;
        [NotMapped]
        public Decimal Price
        {
            get
            {
                return _Price;
            }
            set
            {
                _Price = (IsAdmin ? value : 5.0m + ToppingsPrice() + CrustPrice()) * (Size == null ? 1m : Size.PriceMultiplier);
            }
        }
        public IList<Topping>? Toppings { get; set; } = new List<Topping>();
        public IList<Order>? Orders { get; set; } = new List<Order>();
        public IList<PizzaTopping>? PizzaToppings { get; set; } = new List<PizzaTopping>();
        public string? UserId { get; set; }
        public User? User { get; set; }
        [NotMapped]
        public Boolean IsAdmin { get; set; } = false;

        private Decimal ToppingsPrice()
        {
            Decimal toppingsPrice = 0.0m;
            if (Toppings != null)
            {
                foreach (Topping topping in Toppings)
                {
                    toppingsPrice += topping.Price;
                }
            }
            return toppingsPrice;
        }

        private Decimal CrustPrice()
        {
            Decimal toppingsPrice = 0.0m;
            if (Crust != null)
            {
                toppingsPrice += Crust.Price;
            }
            return toppingsPrice;
        }
    }
}
