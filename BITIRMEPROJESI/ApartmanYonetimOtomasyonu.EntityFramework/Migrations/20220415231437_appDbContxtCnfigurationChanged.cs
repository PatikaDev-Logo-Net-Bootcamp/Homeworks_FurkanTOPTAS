using Microsoft.EntityFrameworkCore.Migrations;

namespace ApartmanYonetimOtomasyonu.EntityFramework.Migrations
{
    public partial class appDbContxtCnfigurationChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flats_User_UserId",
                schema: "Apartment",
                table: "Flats");

            migrationBuilder.AddForeignKey(
                name: "FK_Flats_User_UserId",
                schema: "Apartment",
                table: "Flats",
                column: "UserId",
                principalSchema: "Apartment",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flats_User_UserId",
                schema: "Apartment",
                table: "Flats");

            migrationBuilder.AddForeignKey(
                name: "FK_Flats_User_UserId",
                schema: "Apartment",
                table: "Flats",
                column: "UserId",
                principalSchema: "Apartment",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
