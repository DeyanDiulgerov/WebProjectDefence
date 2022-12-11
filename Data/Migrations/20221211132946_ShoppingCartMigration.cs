using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProject.Data.Migrations
{
    public partial class ShoppingCartMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "HealthProducts",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    ItemId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CartId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_ProductId",
                table: "ShoppingCarts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_UserId",
                table: "ShoppingCarts",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Features_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Administrators",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 33, "0877111111", "TestAdminUserId" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Description", "Developer", "DiscountPrice", "GameName", "Genre", "ImageUrl", "Price", "Publisher", "Rating", "ReleaseDate", "Sales" },
                values: new object[] { 33, "TestDescription", "TestDeveloper", 8.0m, "TestName", "TestGenre", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQE71yLKH6QqyuwnY02KokINKViHp3R2wn2Ng&usqp=CAU", 10.0m, "TestPublisher", 9.9m, new DateTime(2022, 12, 8, 15, 31, 19, 565, DateTimeKind.Local).AddTicks(7828), 100 });

            migrationBuilder.InsertData(
                table: "HealthProducts",
                columns: new[] { "Id", "AvailableFrom", "Description", "DiscountPrice", "ImageUrl", "Name", "Price", "Rating" },
                values: new object[] { 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TestDescription", 8.0m, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQE71yLKH6QqyuwnY02KokINKViHp3R2wn2Ng&usqp=CAU", "TestName", 10.0m, 9.9m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AvailableFrom", "Company", "Description", "DiscountPrice", "ImageUrl", "Name", "Price", "Sales" },
                values: new object[] { 33, new DateTime(2022, 12, 8, 15, 31, 19, 565, DateTimeKind.Local).AddTicks(7828), "TestCompany", "TestDescription", 8.0m, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQE71yLKH6QqyuwnY02KokINKViHp3R2wn2Ng&usqp=CAU", "TestName", 10.0m, 100 });

            migrationBuilder.CreateIndex(
                name: "IX_Features_GameId",
                table: "Features",
                column: "GameId");
        }
    }
}
