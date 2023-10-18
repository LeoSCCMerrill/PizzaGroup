﻿namespace PizzaGroup.Models
{
    public class Crust
    {
        public int CrustId { get; set; }
        public string CrustName { get; set; }
        public Decimal CrustPrice { get; set; }
        public ICollection<Pizza> Pizzas { get; set; } = new List<Pizza>();
    }
}
