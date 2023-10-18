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
        public DbSet<Order> Orders { get; set; }
        public DbSet<Crust> Crusts { get; set; }
        public DbSet<Size> Sizes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the User entity
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Order>().HasKey(o => o.OrderID);

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
                    ToppingID = 1,
                    ToppingName = "Pepperoni",
                    ToppingPrice = 0.29m,
                    ToppingType = ToppingType.MEAT
                },
                new Topping
                {
                    ToppingID = 2,
                    ToppingName = "Beef",
                    ToppingPrice = 0.29m,
                    ToppingType = ToppingType.MEAT
                },
                new Topping
                {
                    ToppingID = 3,
                    ToppingName = "Bacon",
                    ToppingPrice = 0.29m,
                    ToppingType = ToppingType.MEAT
                },
                new Topping
                {
                    ToppingID = 4,
                    ToppingName = "Chicken",
                    ToppingPrice = 0.29m,
                    ToppingType = ToppingType.MEAT
                },
                new Topping
                {
                    ToppingID = 5,
                    ToppingName = "Sausage",
                    ToppingPrice = 0.29m,
                    ToppingType = ToppingType.MEAT
                },
                new Topping
                {
                    ToppingID = 6,
                    ToppingName = "Canadian Bacon",
                    ToppingPrice = 0.29m,
                    ToppingType = ToppingType.MEAT
                },
                new Topping
                {
                    ToppingID = 7,
                    ToppingName = "Anchovies",
                    ToppingPrice = 0.29m,
                    ToppingType = ToppingType.MEAT
                },
                new Topping
                {
                    ToppingID = 8,
                    ToppingName = "Mozzarella",
                    ToppingPrice = 0m,
                    ToppingType = ToppingType.CHEESE
                },
                new Topping
                {
                    ToppingID = 9,
                    ToppingName = "Parmesan",
                    ToppingPrice = 0m,
                    ToppingType = ToppingType.CHEESE
                },
                new Topping
                {
                    ToppingID = 10,
                    ToppingName = "Green Pepper",
                    ToppingPrice = 0.19m,
                    ToppingType = ToppingType.VEGGIE
                },
                new Topping
                {
                    ToppingID = 11,
                    ToppingName = "Red Pepper",
                    ToppingPrice = 0.19m,
                    ToppingType = ToppingType.VEGGIE
                },
                new Topping
                {
                    ToppingID = 12,
                    ToppingName = "Onion",
                    ToppingPrice = 0.19m,
                    ToppingType = ToppingType.VEGGIE
                },
                new Topping
                {
                    ToppingID = 13,
                    ToppingName = "Red Onion",
                    ToppingPrice = 0.19m,
                    ToppingType = ToppingType.VEGGIE
                },
                new Topping
                {
                    ToppingID = 14,
                    ToppingName = "Mushroom",
                    ToppingPrice = 0.19m,
                    ToppingType = ToppingType.VEGGIE
                },
                new Topping
                {
                    ToppingID = 15,
                    ToppingName = "Olive",
                    ToppingPrice = 0.19m,
                    ToppingType = ToppingType.VEGGIE
                },
                new Topping
                {
                    ToppingID = 16,
                    ToppingName = "Pineapple",
                    ToppingPrice = 0.19m,
                    ToppingType = ToppingType.VEGGIE
                },
                new Topping
                {
                    ToppingID = 17,
                    ToppingName = "Tomato Sauce",
                    ToppingPrice = 0m,
                    ToppingType = ToppingType.SAUCE
                },
                new Topping
                {
                    ToppingID = 18,
                    ToppingName = "Barbeque",
                    ToppingPrice = 0.09m,
                    ToppingType = ToppingType.SAUCE
                },
                new Topping
                {
                    ToppingID = 19,
                    ToppingName = "Alfredo",
                    ToppingPrice = 0.19m,
                    ToppingType = ToppingType.SAUCE
                },
                new Topping
                {
                    ToppingID = 20,
                    ToppingName = "Buffalo",
                    ToppingPrice = 0.19m,
                    ToppingType = ToppingType.SAUCE
                },
                new Topping
                {
                    ToppingID = 21,
                    ToppingName = "Seasoned Crust",
                    ToppingPrice = 0.49m,
                    ToppingType = ToppingType.OTHER
                }
                );
            modelBuilder.Entity<Size>().HasData(
                new Size
                {
                    SizeId = 1,
                    SizeName = "Mini",
                    SizeInches = 8,
                    SizePriceMultiplier = 0.50m,
                },
                new Size
                {
                    SizeId = 2,
                    SizeName = "Small",
                    SizeInches = 10,
                    SizePriceMultiplier = 0.75m,
                },
                new Size
                {
                    SizeId = 3,
                    SizeName = "Medium",
                    SizeInches = 12,
                    SizePriceMultiplier = 1m,
                },
                new Size
                {
                    SizeId = 4,
                    SizeName = "Large",
                    SizeInches = 14,
                    SizePriceMultiplier = 1.25m,
                }
                );
            modelBuilder.Entity<Crust>().HasData(
                new Crust
                {
                    CrustId = 1,
                    CrustName = "Original Crust",
                    CrustPrice = 0m,
                },
                new Crust
                {
                    CrustId = 2,
                    CrustName = "Pan Crust",
                    CrustPrice = 0m,
                },
                new Crust
                {
                    CrustId = 3,
                    CrustName = "Thin Crust",
                    CrustPrice = 0m,
                },
                new Crust
                {
                    CrustId = 4,
                    CrustName = "Stuffed Crust",
                    CrustPrice = 1.00m,
                },
                new Crust
                {
                    CrustId = 5,
                    CrustName = "Detroit Style",
                    CrustPrice = 2.00m,
                },
                new Crust
                {
                    CrustId = 6,
                    CrustName = "Chicago Style",
                    CrustPrice = 4.00m,
                }
                );
            modelBuilder.Entity<Pizza>().HasData(
                new Pizza
                {
                    PizzaID = 1,
                    PizzaName = "Custom 1",
                    PizzaPrice = 10.00,
                    SizeId = 1,
                    CrustId = 1
                }
                );
        }
    }
}