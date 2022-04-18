using Microsoft.EntityFrameworkCore.Migrations;

namespace ApartmanYonetimOtomasyonu.EntityFramework.Migrations
{
    public partial class MessageTableChangedMigrationTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                schema: "Apartment",
                table: "Messages",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRead",
                schema: "Apartment",
                table: "Messages");
        }
    }
}
