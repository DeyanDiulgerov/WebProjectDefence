using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProject.Data.Migrations
{
    public partial class SeedDatabaseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Developers");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "dea12856-c198-4129-b3f3-b893d8395082", 0, "6730bcf1-869c-4f82-acd6-27e64f1af065", "admin@email.com", false, false, null, "ADMIN@EMAIL.COM", "SEEDEDADMINUSER", "AQAAAAEAACcQAAAAEB804NQ/oaH8vIVosxTRpOGd2cxiP3Rf/11t4N1FCYCFEC7DDXkznDAOzu1Yk8Q4+A==", null, false, "554bf4d6-ce45-41e3-b114-229b0af055ec", false, "SeededAdminUser" },
                    { "eac44456-3215-3124-n5n3-b893h4253082", 0, "ce15649b-5376-4a6a-9ea4-9936bb5d20a5", "guest@email.com", false, false, null, "GUEST@EMAIL.COM", "SEEDEDUSER", "AQAAAAEAACcQAAAAEN1+JylWC1Jw0TxLPcjmT1TPTz+kII/zEzO2tzTGiULC7v5jnN8FMa7qpNaP1BO2AQ==", null, false, "a0ff25cc-9e1a-4259-98bc-2456674a1a59", false, "SeededUser" },
                    { "qwe77756-2745-3754-n8h3-f888h4253082", 0, "93e9b537-71d8-4af2-ab0d-72a933ccf4cb", "potential@email.com", false, false, null, "POTENTIAL@EMAIL.COM", "POTENTIALUSER", "AQAAAAEAACcQAAAAEKFNJ+8f6GKcAGl/vFxjsUFfCsQ3thitPTwk0gvefPXWEHtOro5bb7NGKtm8afl+Gg==", null, false, "2a3f80bf-a284-4c0a-8c81-48a42fbe732a", false, "PotentialUser" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Description", "Developer", "DiscountPrice", "GameName", "Genre", "ImageUrl", "Price", "Publisher", "Rating", "ReleaseDate", "Sales" },
                values: new object[,]
                {
                    { 51, "In Marvel’s Spider-Man Remastered, the worlds of Peter Parker and Spider-Man collide in an original, action-packed story. Play as an experienced Peter Parker, fighting big crime and iconic villains in Marvel’s New York. Web-swing through vibrant neighborhoods and defeat villains with epic takedowns.", "Insomniac Games, Nixxes Software", 80.0m, "Marvel's Spider-Man Remastered", "Action-Adventure", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQkNdE1mKG_ZhqEjCaN2TpX_oDTcirJSooc3Q&usqp=CAU", 120.0m, "PlayStation PC LLC", 9.50m, new DateTime(2022, 12, 19, 14, 31, 58, 101, DateTimeKind.Utc).AddTicks(3393), 570500 },
                    { 52, "Experience the excitement of the biggest tournament in football with EA SPORTS™ FIFA 23 and the men’s FIFA World Cup™ update, available on November 9 at no additional cost*.", "EA Canada", 55.99m, "FIFA 23", "Simulation", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSIItQ_gWsM03vMqaQ0QhA5QRXwOl17TK_5HQ&usqp=CAU", 139.0m, "Electronic Arts", 8.50m, new DateTime(2022, 12, 19, 14, 31, 58, 101, DateTimeKind.Utc).AddTicks(3399), 980500 },
                    { 53, "Welcome to Santo Ileso, a vibrant fictional city in the American Southwest. In a world rife with crime, a group of young friends embark on their own criminal venture, as they rise to the top in their bid to become Self Made.", "Deep Silver Volition", 67.99m, "Saints Row", "Action-Adventure, Shooter, Open World", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRcEsRkuklD9EGzsDVC_KF1UiQNcVQ3rWt7ww&usqp=CAU", 115.0m, "Deep Silver", 8.00m, new DateTime(2022, 12, 19, 14, 31, 58, 101, DateTimeKind.Utc).AddTicks(3402), 470800 }
                });

            migrationBuilder.InsertData(
                table: "GamingProducts",
                columns: new[] { "Id", "AvailableFrom", "Company", "Description", "DiscountPrice", "ImageUrl", "Name", "Price", "Sales" },
                values: new object[,]
                {
                    { 15, new DateTime(2022, 12, 19, 14, 31, 58, 101, DateTimeKind.Utc).AddTicks(3488), "Huzaro Force", "Gaming chair Huzaro Force 2.5, Mesh, Black / Carbon RGB.", 225.0m, "https://s13emagst.akamaized.net/products/46245/46244850/images/res_376bec9a17bddc707b0d6ecfc12ef53a.jpg?width=450&height=450&hash=25F4624F460E1BCE5DB13E19A5DB62FD", "Huzaro Force 2.5", 299.0m, 24 },
                    { 16, new DateTime(2022, 12, 19, 14, 31, 58, 101, DateTimeKind.Utc).AddTicks(3493), "G-Fuel", "Blackberry Pear Vanilla", 40.0m, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTdKI0RNcIzMw2gNUF7YWA_0xT13xb4LktRNQ&usqp=CAU", "G-Fuel Black Ice", 40.0m, 80 }
                });

            migrationBuilder.InsertData(
                table: "HealthProducts",
                columns: new[] { "Id", "AvailableFrom", "Description", "DiscountPrice", "ImageUrl", "Name", "Price", "Rating" },
                values: new object[,]
                {
                    { 15, new DateTime(2022, 12, 19, 14, 31, 58, 101, DateTimeKind.Utc).AddTicks(3570), "Yoga Mat Purple", 20.0m, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTtN_yNN5YYtDfL0WOpOjjC6VbdWk-yWKQ7gg&usqp=CAU", "Yoga Mat", 20.0m, 10.0m },
                    { 16, new DateTime(2022, 12, 19, 14, 31, 58, 101, DateTimeKind.Utc).AddTicks(3574), "Grin Health Lumbar Support/Lower Back", 24.0m, "https://m.media-amazon.com/images/W/WEBP_402378-T1/images/I/716jwuY6oJL._AC_SS130_.jpg", "Waist Belt", 24.0m, 10.0m }
                });

            migrationBuilder.InsertData(
                table: "Administrators",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 98, "+359777777777", "dea12856-c198-4129-b3f3-b893d8395082" });

            migrationBuilder.InsertData(
                table: "PotentialAdmins",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 99, "+359777777778", "qwe77756-2745-3754-n8h3-f888h4253082" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eac44456-3215-3124-n5n3-b893h4253082");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "GamingProducts",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "GamingProducts",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "HealthProducts",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "HealthProducts",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "PotentialAdmins",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "qwe77756-2745-3754-n8h3-f888h4253082");

            migrationBuilder.CreateTable(
                name: "Developers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DeveloperLogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeveloperName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developers", x => x.Id);
                });
        }
    }
}
