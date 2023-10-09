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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the User entity
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasKey(x => x.Id);
            const string MANAGER_USER_ID = "b4280b6a-0613-4cbd-a9e6-f1701e926e73";
            const string MANAGER_ROLE_ID = MANAGER_USER_ID;
            const string EMPLOYEE_ROLE_ID = "22d6208e-e968-487e-a8f6-59a1c3ce94d7";
            const string EMPLOYEE_USER_ID = EMPLOYEE_ROLE_ID;
            modelBuilder.Entity<IdentityRole>().HasData(
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

            modelBuilder.Entity<User>().HasData(new User
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
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = MANAGER_ROLE_ID,
                UserId = MANAGER_USER_ID
            }, new IdentityUserRole<string>
            {
                RoleId = EMPLOYEE_ROLE_ID,
                UserId = EMPLOYEE_ROLE_ID
            });
        }
    }
}