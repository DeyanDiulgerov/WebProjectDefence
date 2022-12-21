﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebProject.Data;

#nullable disable

namespace WebProject.Data.Migrations
{
    [DbContext(typeof(GameStoreDbContext))]
    [Migration("20221219143158_SeedDatabaseMigration")]
    partial class SeedDatabaseMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
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

            modelBuilder.Entity("WebProject.Data.Models.Administrator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Administrators");

                    b.HasData(
                        new
                        {
                            Id = 98,
                            PhoneNumber = "+359777777777",
                            UserId = "dea12856-c198-4129-b3f3-b893d8395082"
                        });
                });

            modelBuilder.Entity("WebProject.Data.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Developer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("DiscountPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("GameName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<decimal>("Rating")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Sales")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = 51,
                            Description = "In Marvel’s Spider-Man Remastered, the worlds of Peter Parker and Spider-Man collide in an original, action-packed story. Play as an experienced Peter Parker, fighting big crime and iconic villains in Marvel’s New York. Web-swing through vibrant neighborhoods and defeat villains with epic takedowns.",
                            Developer = "Insomniac Games, Nixxes Software",
                            DiscountPrice = 80.0m,
                            GameName = "Marvel's Spider-Man Remastered",
                            Genre = "Action-Adventure",
                            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQkNdE1mKG_ZhqEjCaN2TpX_oDTcirJSooc3Q&usqp=CAU",
                            Price = 120.0m,
                            Publisher = "PlayStation PC LLC",
                            Rating = 9.50m,
                            ReleaseDate = new DateTime(2022, 12, 19, 14, 31, 58, 101, DateTimeKind.Utc).AddTicks(3393),
                            Sales = 570500
                        },
                        new
                        {
                            Id = 52,
                            Description = "Experience the excitement of the biggest tournament in football with EA SPORTS™ FIFA 23 and the men’s FIFA World Cup™ update, available on November 9 at no additional cost*.",
                            Developer = "EA Canada",
                            DiscountPrice = 55.99m,
                            GameName = "FIFA 23",
                            Genre = "Simulation",
                            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSIItQ_gWsM03vMqaQ0QhA5QRXwOl17TK_5HQ&usqp=CAU",
                            Price = 139.0m,
                            Publisher = "Electronic Arts",
                            Rating = 8.50m,
                            ReleaseDate = new DateTime(2022, 12, 19, 14, 31, 58, 101, DateTimeKind.Utc).AddTicks(3399),
                            Sales = 980500
                        },
                        new
                        {
                            Id = 53,
                            Description = "Welcome to Santo Ileso, a vibrant fictional city in the American Southwest. In a world rife with crime, a group of young friends embark on their own criminal venture, as they rise to the top in their bid to become Self Made.",
                            Developer = "Deep Silver Volition",
                            DiscountPrice = 67.99m,
                            GameName = "Saints Row",
                            Genre = "Action-Adventure, Shooter, Open World",
                            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRcEsRkuklD9EGzsDVC_KF1UiQNcVQ3rWt7ww&usqp=CAU",
                            Price = 115.0m,
                            Publisher = "Deep Silver",
                            Rating = 8.00m,
                            ReleaseDate = new DateTime(2022, 12, 19, 14, 31, 58, 101, DateTimeKind.Utc).AddTicks(3402),
                            Sales = 470800
                        });
                });

            modelBuilder.Entity("WebProject.Data.Models.GamingProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("AvailableFrom")
                        .HasColumnType("datetime2");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<decimal>("DiscountPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("Sales")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("GamingProducts");

                    b.HasData(
                        new
                        {
                            Id = 15,
                            AvailableFrom = new DateTime(2022, 12, 19, 14, 31, 58, 101, DateTimeKind.Utc).AddTicks(3488),
                            Company = "Huzaro Force",
                            Description = "Gaming chair Huzaro Force 2.5, Mesh, Black / Carbon RGB.",
                            DiscountPrice = 225.0m,
                            ImageUrl = "https://s13emagst.akamaized.net/products/46245/46244850/images/res_376bec9a17bddc707b0d6ecfc12ef53a.jpg?width=450&height=450&hash=25F4624F460E1BCE5DB13E19A5DB62FD",
                            Name = "Huzaro Force 2.5",
                            Price = 299.0m,
                            Sales = 24
                        },
                        new
                        {
                            Id = 16,
                            AvailableFrom = new DateTime(2022, 12, 19, 14, 31, 58, 101, DateTimeKind.Utc).AddTicks(3493),
                            Company = "G-Fuel",
                            Description = "Blackberry Pear Vanilla",
                            DiscountPrice = 40.0m,
                            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTdKI0RNcIzMw2gNUF7YWA_0xT13xb4LktRNQ&usqp=CAU",
                            Name = "G-Fuel Black Ice",
                            Price = 40.0m,
                            Sales = 80
                        });
                });

            modelBuilder.Entity("WebProject.Data.Models.HealthProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("AvailableFrom")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<decimal>("DiscountPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Rating")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("HealthProducts");

                    b.HasData(
                        new
                        {
                            Id = 15,
                            AvailableFrom = new DateTime(2022, 12, 19, 14, 31, 58, 101, DateTimeKind.Utc).AddTicks(3570),
                            Description = "Yoga Mat Purple",
                            DiscountPrice = 20.0m,
                            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTtN_yNN5YYtDfL0WOpOjjC6VbdWk-yWKQ7gg&usqp=CAU",
                            Name = "Yoga Mat",
                            Price = 20.0m,
                            Rating = 10.0m
                        },
                        new
                        {
                            Id = 16,
                            AvailableFrom = new DateTime(2022, 12, 19, 14, 31, 58, 101, DateTimeKind.Utc).AddTicks(3574),
                            Description = "Grin Health Lumbar Support/Lower Back",
                            DiscountPrice = 24.0m,
                            ImageUrl = "https://m.media-amazon.com/images/W/WEBP_402378-T1/images/I/716jwuY6oJL._AC_SS130_.jpg",
                            Name = "Waist Belt",
                            Price = 24.0m,
                            Rating = 10.0m
                        });
                });

            modelBuilder.Entity("WebProject.Data.Models.PotentialAdmin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("PotentialAdmins");

                    b.HasData(
                        new
                        {
                            Id = 99,
                            PhoneNumber = "+359777777778",
                            UserId = "qwe77756-2745-3754-n8h3-f888h4253082"
                        });
                });

            modelBuilder.Entity("WebProject.Data.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
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
                        .IsRequired()
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
                            Id = "dea12856-c198-4129-b3f3-b893d8395082",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "6730bcf1-869c-4f82-acd6-27e64f1af065",
                            Email = "admin@email.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@EMAIL.COM",
                            NormalizedUserName = "SEEDEDADMINUSER",
                            PasswordHash = "AQAAAAEAACcQAAAAEB804NQ/oaH8vIVosxTRpOGd2cxiP3Rf/11t4N1FCYCFEC7DDXkznDAOzu1Yk8Q4+A==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "554bf4d6-ce45-41e3-b114-229b0af055ec",
                            TwoFactorEnabled = false,
                            UserName = "SeededAdminUser"
                        },
                        new
                        {
                            Id = "eac44456-3215-3124-n5n3-b893h4253082",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "ce15649b-5376-4a6a-9ea4-9936bb5d20a5",
                            Email = "guest@email.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "GUEST@EMAIL.COM",
                            NormalizedUserName = "SEEDEDUSER",
                            PasswordHash = "AQAAAAEAACcQAAAAEN1+JylWC1Jw0TxLPcjmT1TPTz+kII/zEzO2tzTGiULC7v5jnN8FMa7qpNaP1BO2AQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "a0ff25cc-9e1a-4259-98bc-2456674a1a59",
                            TwoFactorEnabled = false,
                            UserName = "SeededUser"
                        },
                        new
                        {
                            Id = "qwe77756-2745-3754-n8h3-f888h4253082",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "93e9b537-71d8-4af2-ab0d-72a933ccf4cb",
                            Email = "potential@email.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "POTENTIAL@EMAIL.COM",
                            NormalizedUserName = "POTENTIALUSER",
                            PasswordHash = "AQAAAAEAACcQAAAAEKFNJ+8f6GKcAGl/vFxjsUFfCsQ3thitPTwk0gvefPXWEHtOro5bb7NGKtm8afl+Gg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "2a3f80bf-a284-4c0a-8c81-48a42fbe732a",
                            TwoFactorEnabled = false,
                            UserName = "PotentialUser"
                        });
                });

            modelBuilder.Entity("WebProject.Data.Models.UserGame", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "GameId");

                    b.HasIndex("GameId");

                    b.ToTable("UserGame");
                });

            modelBuilder.Entity("WebProject.Data.Models.UserGamingProduct", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("UserGamingProduct");
                });

            modelBuilder.Entity("WebProject.Data.Models.UserHealthProduct", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("HealthProductId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "HealthProductId");

                    b.HasIndex("HealthProductId");

                    b.ToTable("UserHealthProduct");
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
                    b.HasOne("WebProject.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("WebProject.Data.Models.User", null)
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

                    b.HasOne("WebProject.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("WebProject.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebProject.Data.Models.Administrator", b =>
                {
                    b.HasOne("WebProject.Data.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebProject.Data.Models.PotentialAdmin", b =>
                {
                    b.HasOne("WebProject.Data.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebProject.Data.Models.UserGame", b =>
                {
                    b.HasOne("WebProject.Data.Models.Game", "Game")
                        .WithMany("UsersGames")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebProject.Data.Models.User", "User")
                        .WithMany("UserGames")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebProject.Data.Models.UserGamingProduct", b =>
                {
                    b.HasOne("WebProject.Data.Models.GamingProduct", "Product")
                        .WithMany("UsersGamingProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebProject.Data.Models.User", "User")
                        .WithMany("UserGamingProducts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebProject.Data.Models.UserHealthProduct", b =>
                {
                    b.HasOne("WebProject.Data.Models.HealthProduct", "HealthProduct")
                        .WithMany("UsersHealthProducts")
                        .HasForeignKey("HealthProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebProject.Data.Models.User", "User")
                        .WithMany("UsersHealthProducts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HealthProduct");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebProject.Data.Models.Game", b =>
                {
                    b.Navigation("UsersGames");
                });

            modelBuilder.Entity("WebProject.Data.Models.GamingProduct", b =>
                {
                    b.Navigation("UsersGamingProducts");
                });

            modelBuilder.Entity("WebProject.Data.Models.HealthProduct", b =>
                {
                    b.Navigation("UsersHealthProducts");
                });

            modelBuilder.Entity("WebProject.Data.Models.User", b =>
                {
                    b.Navigation("UserGames");

                    b.Navigation("UserGamingProducts");

                    b.Navigation("UsersHealthProducts");
                });
#pragma warning restore 612, 618
        }
    }
}