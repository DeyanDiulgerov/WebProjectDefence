using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProject.Data.Migrations
{
    public partial class HealthProductsMappingTable2ndMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProduct_HealthProducts_HealthProductId",
                table: "UserProduct");

            migrationBuilder.DropIndex(
                name: "IX_UserProduct_HealthProductId",
                table: "UserProduct");

            migrationBuilder.DropColumn(
                name: "HealthProductId",
                table: "UserProduct");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HealthProductId",
                table: "UserProduct",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserProduct_HealthProductId",
                table: "UserProduct",
                column: "HealthProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProduct_HealthProducts_HealthProductId",
                table: "UserProduct",
                column: "HealthProductId",
                principalTable: "HealthProducts",
                principalColumn: "Id");
        }
    }
}
