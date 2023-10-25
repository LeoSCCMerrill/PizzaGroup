using System.Diagnostics;

namespace PizzaGroup.Models
{
    public enum OrderStatus
    {
        NOT_SUBMITTED, SUBMITTED, ASSIGNED, TOSSING_DOUGH, ADDING_TOPPINGS, BAKING_PIZZAS, FINAL_CHECK, OUT_FOR_DELIVERY, DELIVERED
    }
}
