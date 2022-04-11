using Microsoft.EntityFrameworkCore.Migrations;

namespace ApartmanYonetimOtomasyonu.EntityFramework.Migrations
{
    public partial class changedUserAndFlatTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeOfUser",
                schema: "Apartment",
                table: "Flats");

            migrationBuilder.AddColumn<string>(
                name: "TypeOfUser",
                schema: "Apartment",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeOfUser",
                schema: "Apartment",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "TypeOfUser",
                schema: "Apartment",
                table: "Flats",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
