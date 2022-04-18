using Microsoft.EntityFrameworkCore.Migrations;

namespace ApartmanYonetimOtomasyonu.EntityFramework.Migrations
{
    public partial class messageTableChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReceiverId",
                schema: "Apartment",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderId",
                schema: "Apartment",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceiverId",
                schema: "Apartment",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "SenderId",
                schema: "Apartment",
                table: "Messages");
        }
    }
}
