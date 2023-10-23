﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaGroup.Data;

#nullable disable

namespace PizzaGroup.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231023184111_pizzaUserId")]
    partial class pizzaUserId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "5cb99a62-bceb-4b4a-98d7-b250d8d7ae11",
                            ConcurrencyStamp = "9e503fb7-f413-4973-b776-a35e3420a7a5",
                            Name = "Owner",
                            NormalizedName = "OWNER"
                        },
                        new
                        {
                            Id = "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                            ConcurrencyStamp = "fc9080b9-1912-4451-8e8e-61b3bc4cd5fd",
                            Name = "Manager",
                            NormalizedName = "MANAGER"
                        },
                        new
                        {
                            Id = "22d6208e-e968-487e-a8f6-59a1c3ce94d7",
                            ConcurrencyStamp = "aebdd5f7-1dfd-4ec8-8527-c9b5ce85eb43",
                            Name = "Employee",
                            NormalizedName = "EMPLOYEE"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "5cb99a62-bceb-4b4a-98d7-b250d8d7ae11",
                            RoleId = "5cb99a62-bceb-4b4a-98d7-b250d8d7ae11"
                        },
                        new
                        {
                            UserId = "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                            RoleId = "b4280b6a-0613-4cbd-a9e6-f1701e926e73"
                        },
                        new
                        {
                            UserId = "22d6208e-e968-487e-a8f6-59a1c3ce94d7",
                            RoleId = "22d6208e-e968-487e-a8f6-59a1c3ce94d7"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("PizzaGroup.Models.Crust", b =>
                {
                    b.Property<int>("CrustId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CrustId"), 1L, 1);

                    b.Property<string>("CrustName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("CrustPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CrustId");

                    b.ToTable("Crusts");

                    b.HasData(
                        new
                        {
                            CrustId = 1,
                            CrustName = "Original Crust",
                            CrustPrice = 0m
                        },
                        new
                        {
                            CrustId = 2,
                            CrustName = "Pan Crust",
                            CrustPrice = 0m
                        },
                        new
                        {
                            CrustId = 3,
                            CrustName = "Thin Crust",
                            CrustPrice = 0m
                        },
                        new
                        {
                            CrustId = 4,
                            CrustName = "Stuffed Crust",
                            CrustPrice = 1.00m
                        },
                        new
                        {
                            CrustId = 5,
                            CrustName = "Detroit Style",
                            CrustPrice = 2.00m
                        },
                        new
                        {
                            CrustId = 6,
                            CrustName = "Chicago Style",
                            CrustPrice = 4.00m
                        });
                });

            modelBuilder.Entity("PizzaGroup.Models.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderID"), 1L, 1);

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.HasKey("OrderID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("PizzaGroup.Models.OrderPizza", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("PizzaId")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "PizzaId");

                    b.HasIndex("PizzaId");

                    b.ToTable("OrderPizzas");
                });

            modelBuilder.Entity("PizzaGroup.Models.Pizza", b =>
                {
                    b.Property<int>("PizzaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PizzaID"), 1L, 1);

                    b.Property<int>("CrustId")
                        .HasColumnType("int");

                    b.Property<string>("PizzaName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("PizzaPrice")
                        .HasColumnType("float");

                    b.Property<int>("SizeId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("PizzaID");

                    b.HasIndex("CrustId");

                    b.HasIndex("SizeId");

                    b.HasIndex("UserId");

                    b.ToTable("Pizzas");

                    b.HasData(
                        new
                        {
                            PizzaID = 1,
                            CrustId = 1,
                            PizzaName = "Custom 1",
                            PizzaPrice = 10.0,
                            SizeId = 1
                        });
                });

            modelBuilder.Entity("PizzaGroup.Models.PizzaTopping", b =>
                {
                    b.Property<int>("PizzaId")
                        .HasColumnType("int");

                    b.Property<int>("ToppingId")
                        .HasColumnType("int");

                    b.HasKey("PizzaId", "ToppingId");

                    b.HasIndex("ToppingId");

                    b.ToTable("PizzaToppings");
                });

            modelBuilder.Entity("PizzaGroup.Models.Size", b =>
                {
                    b.Property<int>("SizeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SizeId"), 1L, 1);

                    b.Property<int>("SizeInches")
                        .HasColumnType("int");

                    b.Property<string>("SizeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("SizePriceMultiplier")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("SizeId");

                    b.ToTable("Sizes");

                    b.HasData(
                        new
                        {
                            SizeId = 1,
                            SizeInches = 8,
                            SizeName = "Mini",
                            SizePriceMultiplier = 0.50m
                        },
                        new
                        {
                            SizeId = 2,
                            SizeInches = 10,
                            SizeName = "Small",
                            SizePriceMultiplier = 0.75m
                        },
                        new
                        {
                            SizeId = 3,
                            SizeInches = 12,
                            SizeName = "Medium",
                            SizePriceMultiplier = 1m
                        },
                        new
                        {
                            SizeId = 4,
                            SizeInches = 14,
                            SizeName = "Large",
                            SizePriceMultiplier = 1.25m
                        });
                });

            modelBuilder.Entity("PizzaGroup.Models.Topping", b =>
                {
                    b.Property<int>("ToppingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ToppingID"), 1L, 1);

                    b.Property<string>("ToppingName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ToppingPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ToppingType")
                        .HasColumnType("int");

                    b.HasKey("ToppingID");

                    b.ToTable("Toppings");

                    b.HasData(
                        new
                        {
                            ToppingID = 1,
                            ToppingName = "Pepperoni",
                            ToppingPrice = 0.29m,
                            ToppingType = 0
                        },
                        new
                        {
                            ToppingID = 2,
                            ToppingName = "Beef",
                            ToppingPrice = 0.29m,
                            ToppingType = 0
                        },
                        new
                        {
                            ToppingID = 3,
                            ToppingName = "Bacon",
                            ToppingPrice = 0.29m,
                            ToppingType = 0
                        },
                        new
                        {
                            ToppingID = 4,
                            ToppingName = "Chicken",
                            ToppingPrice = 0.29m,
                            ToppingType = 0
                        },
                        new
                        {
                            ToppingID = 5,
                            ToppingName = "Sausage",
                            ToppingPrice = 0.29m,
                            ToppingType = 0
                        },
                        new
                        {
                            ToppingID = 6,
                            ToppingName = "Canadian Bacon",
                            ToppingPrice = 0.29m,
                            ToppingType = 0
                        },
                        new
                        {
                            ToppingID = 7,
                            ToppingName = "Anchovies",
                            ToppingPrice = 0.29m,
                            ToppingType = 0
                        },
                        new
                        {
                            ToppingID = 8,
                            ToppingName = "Mozzarella",
                            ToppingPrice = 0m,
                            ToppingType = 1
                        },
                        new
                        {
                            ToppingID = 9,
                            ToppingName = "Parmesan",
                            ToppingPrice = 0m,
                            ToppingType = 1
                        },
                        new
                        {
                            ToppingID = 10,
                            ToppingName = "Green Pepper",
                            ToppingPrice = 0.19m,
                            ToppingType = 2
                        },
                        new
                        {
                            ToppingID = 11,
                            ToppingName = "Red Pepper",
                            ToppingPrice = 0.19m,
                            ToppingType = 2
                        },
                        new
                        {
                            ToppingID = 12,
                            ToppingName = "Onion",
                            ToppingPrice = 0.19m,
                            ToppingType = 2
                        },
                        new
                        {
                            ToppingID = 13,
                            ToppingName = "Red Onion",
                            ToppingPrice = 0.19m,
                            ToppingType = 2
                        },
                        new
                        {
                            ToppingID = 14,
                            ToppingName = "Mushroom",
                            ToppingPrice = 0.19m,
                            ToppingType = 2
                        },
                        new
                        {
                            ToppingID = 15,
                            ToppingName = "Olive",
                            ToppingPrice = 0.19m,
                            ToppingType = 2
                        },
                        new
                        {
                            ToppingID = 16,
                            ToppingName = "Pineapple",
                            ToppingPrice = 0.19m,
                            ToppingType = 2
                        },
                        new
                        {
                            ToppingID = 17,
                            ToppingName = "Tomato Sauce",
                            ToppingPrice = 0m,
                            ToppingType = 3
                        },
                        new
                        {
                            ToppingID = 18,
                            ToppingName = "Barbeque",
                            ToppingPrice = 0.09m,
                            ToppingType = 3
                        },
                        new
                        {
                            ToppingID = 19,
                            ToppingName = "Alfredo",
                            ToppingPrice = 0.19m,
                            ToppingType = 3
                        },
                        new
                        {
                            ToppingID = 20,
                            ToppingName = "Buffalo",
                            ToppingPrice = 0.19m,
                            ToppingType = 3
                        },
                        new
                        {
                            ToppingID = 21,
                            ToppingName = "Seasoned Crust",
                            ToppingPrice = 0.49m,
                            ToppingType = 4
                        });
                });

            modelBuilder.Entity("PizzaGroup.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "5cb99a62-bceb-4b4a-98d7-b250d8d7ae11",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "c8554266-b401-4519-9aeb-a9283053fc58",
                            Email = "owner@hizza.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "OWNER@HIZZA.COM",
                            NormalizedUserName = "OWNER@HIZZA.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEALfXOO0MYDpnaWi+2TO6u67hE3xzrew03QVb8Vb3wTOdiKZzWGSm42SscHBRPRT0g==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINA",
                            TwoFactorEnabled = false,
                            UserName = "owner@hizza.com"
                        },
                        new
                        {
                            Id = "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "c8554266-b401-4519-9aeb-a9283053fc58",
                            Email = "manager@hizza.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "MANAGER@HIZZA.COM",
                            NormalizedUserName = "MANAGER@HIZZA.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEALfXOO0MYDpnaWi+2TO6u67hE3xzrew03QVb8Vb3wTOdiKZzWGSm42SscHBRPRT0g==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINA",
                            TwoFactorEnabled = false,
                            UserName = "manager@hizza.com"
                        },
                        new
                        {
                            Id = "22d6208e-e968-487e-a8f6-59a1c3ce94d7",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "1",
                            Email = "employee@hizza.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "EMPLOYEE@HIZZA.COM",
                            NormalizedUserName = "EMPLOYEE@HIZZA.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEALfXOO0MYDpnaWi+2TO6u67hE3xzrew03QVb8Vb3wTOdiKZzWGSm42SscHBRPRT0g==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "1",
                            TwoFactorEnabled = false,
                            UserName = "employee@hizza.com"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("PizzaGroup.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("PizzaGroup.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaGroup.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("PizzaGroup.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PizzaGroup.Models.OrderPizza", b =>
                {
                    b.HasOne("PizzaGroup.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaGroup.Models.Pizza", "Pizza")
                        .WithMany()
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Pizza");
                });

            modelBuilder.Entity("PizzaGroup.Models.Pizza", b =>
                {
                    b.HasOne("PizzaGroup.Models.Crust", "PizzaCrust")
                        .WithMany("Pizzas")
                        .HasForeignKey("CrustId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaGroup.Models.Size", "PizzaSize")
                        .WithMany("Pizzas")
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaGroup.Models.User", "User")
                        .WithMany("Pizzas")
                        .HasForeignKey("UserId");

                    b.Navigation("PizzaCrust");

                    b.Navigation("PizzaSize");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PizzaGroup.Models.PizzaTopping", b =>
                {
                    b.HasOne("PizzaGroup.Models.Pizza", "Pizza")
                        .WithMany("PizzaToppings")
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaGroup.Models.Topping", "Topping")
                        .WithMany()
                        .HasForeignKey("ToppingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pizza");

                    b.Navigation("Topping");
                });

            modelBuilder.Entity("PizzaGroup.Models.Crust", b =>
                {
                    b.Navigation("Pizzas");
                });

            modelBuilder.Entity("PizzaGroup.Models.Pizza", b =>
                {
                    b.Navigation("PizzaToppings");
                });

            modelBuilder.Entity("PizzaGroup.Models.Size", b =>
                {
                    b.Navigation("Pizzas");
                });

            modelBuilder.Entity("PizzaGroup.Models.User", b =>
                {
                    b.Navigation("Pizzas");
                });
#pragma warning restore 612, 618
        }
    }
}
