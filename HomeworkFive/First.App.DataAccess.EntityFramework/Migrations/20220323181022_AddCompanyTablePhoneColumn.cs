using Microsoft.EntityFrameworkCore.Migrations;

namespace First.App.DataAccess.EntityFramework.Migrations
{
    public partial class AddCompanyTablePhoneColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Companies");
        }
    }
}
