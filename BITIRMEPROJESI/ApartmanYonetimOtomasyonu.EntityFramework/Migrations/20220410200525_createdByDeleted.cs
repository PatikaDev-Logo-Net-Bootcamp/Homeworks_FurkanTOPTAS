using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApartmanYonetimOtomasyonu.EntityFramework.Migrations
{
    public partial class createdByDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "Apartment",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "Apartment",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "LastUpdatedAt",
                schema: "Apartment",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "LastUpdatedBy",
                schema: "Apartment",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "Apartment",
                table: "Flats");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "Apartment",
                table: "Flats");

            migrationBuilder.DropColumn(
                name: "LastUpdatedAt",
                schema: "Apartment",
                table: "Flats");

            migrationBuilder.DropColumn(
                name: "LastUpdatedBy",
                schema: "Apartment",
                table: "Flats");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "Apartment",
                table: "ExpenseTypes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "Apartment",
                table: "ExpenseTypes");

            migrationBuilder.DropColumn(
                name: "LastUpdatedAt",
                schema: "Apartment",
                table: "ExpenseTypes");

            migrationBuilder.DropColumn(
                name: "LastUpdatedBy",
                schema: "Apartment",
                table: "ExpenseTypes");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "Apartment",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "Apartment",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "LastUpdatedAt",
                schema: "Apartment",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "LastUpdatedBy",
                schema: "Apartment",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "Apartment",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "Apartment",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "LastUpdatedAt",
                schema: "Apartment",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "LastUpdatedBy",
                schema: "Apartment",
                table: "Buildings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "Apartment",
                table: "Messages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "Apartment",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAt",
                schema: "Apartment",
                table: "Messages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedBy",
                schema: "Apartment",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "Apartment",
                table: "Flats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "Apartment",
                table: "Flats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAt",
                schema: "Apartment",
                table: "Flats",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedBy",
                schema: "Apartment",
                table: "Flats",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "Apartment",
                table: "ExpenseTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "Apartment",
                table: "ExpenseTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAt",
                schema: "Apartment",
                table: "ExpenseTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedBy",
                schema: "Apartment",
                table: "ExpenseTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "Apartment",
                table: "Expenses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "Apartment",
                table: "Expenses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAt",
                schema: "Apartment",
                table: "Expenses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedBy",
                schema: "Apartment",
                table: "Expenses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "Apartment",
                table: "Buildings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "Apartment",
                table: "Buildings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAt",
                schema: "Apartment",
                table: "Buildings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedBy",
                schema: "Apartment",
                table: "Buildings",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
