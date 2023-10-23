using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
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
        public DbSet<Order> Orders { get; set; }
        public DbSet<Crust> Crusts { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<OrderPizza> OrderPizzas { get; set; }
        public DbSet<PizzaTopping> PizzaToppings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the User entity
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Order>().HasKey(o => o.Id);
            modelBuilder.Entity<Pizza>()
                .HasMany(e => e.Toppings)
                .WithMany(e => e.Pizzas)
                .UsingEntity<PizzaTopping>();
            modelBuilder.Entity<Order>()
                .HasMany(e => e.Pizzas)
                .WithMany(e => e.Orders)
                .UsingEntity<OrderPizza>();
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
            modelBuilder.Entity<Topping>().HasData(
                new Topping
                {
                    Id = 1,
                    Name = "Pepperoni",
                    Price = 0.29m,
                    ToppingType = ToppingType.MEAT
                },
                new Topping
                {
                    Id = 2,
                    Name = "Beef",
                    Price = 0.29m,
                    ToppingType = ToppingType.MEAT
                },
                new Topping
                {
                    Id = 3,
                    Name = "Bacon",
                    Price = 0.29m,
                    ToppingType = ToppingType.MEAT
                },
                new Topping
                {
                    Id = 4,
                    Name = "Chicken",
                    Price = 0.29m,
                    ToppingType = ToppingType.MEAT
                },
                new Topping
                {
                    Id = 5,
                    Name = "Sausage",
                    Price = 0.29m,
                    ToppingType = ToppingType.MEAT
                },
                new Topping
                {
                    Id = 6,
                    Name = "Canadian Bacon",
                    Price = 0.29m,
                    ToppingType = ToppingType.MEAT
                },
                new Topping
                {
                    Id = 7,
                    Name = "Anchovies",
                    Price = 0.29m,
                    ToppingType = ToppingType.MEAT
                },
                new Topping
                {
                    Id = 8,
                    Name = "Mozzarella",
                    Price = 0m,
                    ToppingType = ToppingType.CHEESE
                },
                new Topping
                {
                    Id = 9,
                    Name = "Parmesan",
                    Price = 0m,
                    ToppingType = ToppingType.CHEESE
                },
                new Topping
                {
                    Id = 10,
                    Name = "Green Pepper",
                    Price = 0.19m,
                    ToppingType = ToppingType.VEGGIE
                },
                new Topping
                {
                    Id = 11,
                    Name = "Red Pepper",
                    Price = 0.19m,
                    ToppingType = ToppingType.VEGGIE
                },
                new Topping
                {
                    Id = 12,
                    Name = "Onion",
                    Price = 0.19m,
                    ToppingType = ToppingType.VEGGIE
                },
                new Topping
                {
                    Id = 13,
                    Name = "Red Onion",
                    Price = 0.19m,
                    ToppingType = ToppingType.VEGGIE
                },
                new Topping
                {
                    Id = 14,
                    Name = "Mushroom",
                    Price = 0.19m,
                    ToppingType = ToppingType.VEGGIE
                },
                new Topping
                {
                    Id = 15,
                    Name = "Olive",
                    Price = 0.19m,
                    ToppingType = ToppingType.VEGGIE
                },
                new Topping
                {
                    Id = 16,
                    Name = "Pineapple",
                    Price = 0.19m,
                    ToppingType = ToppingType.VEGGIE
                },
                new Topping
                {
                    Id = 17,
                    Name = "Tomato Sauce",
                    Price = 0m,
                    ToppingType = ToppingType.SAUCE
                },
                new Topping
                {
                    Id = 18,
                    Name = "Barbeque",
                    Price = 0.09m,
                    ToppingType = ToppingType.SAUCE
                },
                new Topping
                {
                    Id = 19,
                    Name = "Alfredo",
                    Price = 0.19m,
                    ToppingType = ToppingType.SAUCE
                },
                new Topping
                {
                    Id = 20,
                    Name = "Buffalo",
                    Price = 0.19m,
                    ToppingType = ToppingType.SAUCE
                },
                new Topping
                {
                    Id = 21,
                    Name = "Seasoned Crust",
                    Price = 0.49m,
                    ToppingType = ToppingType.OTHER
                }
                );
            modelBuilder.Entity<Size>().HasData(
                new Size
                {
                    Id = 1,
                    Name = "Mini",
                    Inches = 8,
                    PriceMultiplier = 0.50m,
                },
                new Size
                {
                    Id = 2,
                    Name = "Small",
                    Inches = 10,
                    PriceMultiplier = 0.75m,
                },
                new Size
                {
                    Id = 3,
                    Name = "Medium",
                    Inches = 12,
                    PriceMultiplier = 1m,
                },
                new Size
                {
                    Id = 4,
                    Name = "Large",
                    Inches = 14,
                    PriceMultiplier = 1.25m,
                }
                );
            modelBuilder.Entity<Crust>().HasData(
                new Crust
                {
                    Id = 1,
                    Name = "Original Crust",
                    Price = 0m,
                },
                new Crust
                {
                    Id = 2,
                    Name = "Pan Crust",
                    Price = 0m,
                },
                new Crust
                {
                    Id = 3,
                    Name = "Thin Crust",
                    Price = 0m,
                },
                new Crust
                {
                    Id = 4,
                    Name = "Stuffed Crust",
                    Price = 1.00m,
                },
                new Crust
                {
                    Id = 5,
                    Name = "Detroit Style",
                    Price = 2.00m,
                },
                new Crust
                {
                    Id = 6,
                    Name = "Chicago Style",
                    Price = 4.00m,
                }
                );
            modelBuilder.Entity<Pizza>().HasData(
                new Pizza
                {
                    Id = 1,
                    Name = "Custom 1",
                    Price = 10.00,
                    SizeId = 1,
                    CrustId = 1,
                }
                );
        }
    }
}