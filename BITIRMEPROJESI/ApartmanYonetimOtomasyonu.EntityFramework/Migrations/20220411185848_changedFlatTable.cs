using Microsoft.EntityFrameworkCore.Migrations;

namespace ApartmanYonetimOtomasyonu.EntityFramework.Migrations
{
    public partial class changedFlatTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Block",
                schema: "Apartment",
                table: "Flats");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Block",
                schema: "Apartment",
                table: "Flats",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
