using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PizzaGroup.Models;

namespace PizzaGroup.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> ApplicationUsers { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Topping> Toppings { get; set; }
        public DbSet<PizzaTopping> PizzaToppings { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Crust> Crusts { get; set; }
        public DbSet<Size> Sizes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the User entity
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Order>().HasKey(o=> o.OrderID);

            modelBuilder.Entity<User>().HasKey(x => x.Id);
            const string OWNER_USER_ID = "5cb99a62-bceb-4b4a-98d7-b250d8d7ae11";
            const string OWNER_ROLE_ID = OWNER_USER_ID;
            const string MANAGER_USER_ID = "b4280b6a-0613-4cbd-a9e6-f1701e926e73";
            const string MANAGER_ROLE_ID = MANAGER_USER_ID;
            const string EMPLOYEE_ROLE_ID = "22d6208e-e968-487e-a8f6-59a1c3ce94d7";
            const string EMPLOYEE_USER_ID = EMPLOYEE_ROLE_ID;
            modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = OWNER_ROLE_ID,
                Name = "Owner",
                NormalizedName = "OWNER",
            },
            new IdentityRole
            {
                Id = MANAGER_ROLE_ID,
                Name = "Manager",
                NormalizedName = "MANAGER",
            },
            new IdentityRole
            {
                Id = EMPLOYEE_ROLE_ID,
                Name = "Employee",
                NormalizedName = "EMPLOYEE",
            });

            modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = OWNER_USER_ID,
                UserName = "owner@hizza.com",
                NormalizedUserName = "OWNER@HIZZA.COM",
                Email = "owner@hizza.com",
                NormalizedEmail = "OWNER@HIZZA.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEALfXOO0MYDpnaWi+2TO6u67hE3xzrew03QVb8Vb3wTOdiKZzWGSm42SscHBRPRT0g==", // Password1!
                SecurityStamp = "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINA",
                ConcurrencyStamp = "c8554266-b401-4519-9aeb-a9283053fc58"
            }, new User
            {
                Id = MANAGER_USER_ID,
                UserName = "manager@hizza.com",
                NormalizedUserName = "MANAGER@HIZZA.COM",
                Email = "manager@hizza.com",
                NormalizedEmail = "MANAGER@HIZZA.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEALfXOO0MYDpnaWi+2TO6u67hE3xzrew03QVb8Vb3wTOdiKZzWGSm42SscHBRPRT0g==", // Password1!
                SecurityStamp = "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINA",
                ConcurrencyStamp = "c8554266-b401-4519-9aeb-a9283053fc58"
            }, new User
            {
                Id = EMPLOYEE_USER_ID,
                UserName = "employee@hizza.com",
                NormalizedUserName = "EMPLOYEE@HIZZA.COM",
                Email = "employee@hizza.com",
                NormalizedEmail = "EMPLOYEE@HIZZA.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEALfXOO0MYDpnaWi+2TO6u67hE3xzrew03QVb8Vb3wTOdiKZzWGSm42SscHBRPRT0g==", // Password1!
                SecurityStamp = "1",
                ConcurrencyStamp = "1"
            });
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = OWNER_ROLE_ID,
                UserId = OWNER_ROLE_ID
            }, new IdentityUserRole<string>
            {
                RoleId = MANAGER_ROLE_ID,
                UserId = MANAGER_USER_ID
            }, new IdentityUserRole<string>
            {
                RoleId = EMPLOYEE_ROLE_ID,
                UserId = EMPLOYEE_ROLE_ID
            });
            // configure the pizza topping relationship
            modelBuilder.Entity<PizzaTopping>().HasKey(pt => new { pt.PizzaID, pt.ToppingID });
            modelBuilder.Entity<PizzaTopping>()
                .HasOne(pt => pt.Pizza)
                .WithMany(p => p.PizzaToppings)
                .HasForeignKey(pt => pt.PizzaID);
            modelBuilder.Entity<PizzaTopping>()
                .HasOne(pt => pt.Topping)
                .WithMany(t => t.PizzaToppings)
                .HasForeignKey(pt => pt.ToppingID);
            modelBuilder.Entity<Topping>().HasData(
                new Topping
                {
                    ToppingID = 1,
                    ToppingName = "Pepperoni"
                },
                new Topping
                {
                    ToppingID = 2,
                    ToppingName = "Beef"
                },
                new Topping
                {
                    ToppingID = 3,
                    ToppingName = "Do not use"
                }
                );
            modelBuilder.Entity<Pizza>().HasData(
                new Pizza
                {
                    PizzaID = 1,
                    PizzaName = "Custom 1",
                    PizzaPrice = 10.00,
                    PizzaSize = "Medium",
                    PizzaCrust = "Classic"
                }
                );
            modelBuilder.Entity<PizzaTopping>().HasData(
                new PizzaTopping { PizzaID = 1, ToppingID = 1 },
                new PizzaTopping { PizzaID = 1, ToppingID = 2 }
                );


        }
    }
}