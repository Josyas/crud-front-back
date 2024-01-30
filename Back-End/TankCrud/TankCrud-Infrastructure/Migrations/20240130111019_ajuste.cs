using Microsoft.EntityFrameworkCore.Migrations;

namespace TankCrud_Infrastructure.Migrations
{
    public partial class ajuste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Tank");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "ProductType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Tank",
                type: "BIT",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "ProductType",
                type: "BIT",
                maxLength: 2,
                nullable: false,
                defaultValue: false);
        }
    }
}
