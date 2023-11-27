namespace PizzaGroup.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User : IdentityUser
    {
        [NotMapped]
        public IList<string> RoleNames { get; set; } = new List<string>();
        public IList<Pizza> Pizzas { get; set; } = new List<Pizza>();
    }
}
