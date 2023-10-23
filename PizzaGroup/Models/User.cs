namespace PizzaGroup.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User : IdentityUser
    {
        [NotMapped]
        public IList<string>? RoleNames { get; set; }
        public IList<Pizza>? Pizzas { get; set; }
    }
}
