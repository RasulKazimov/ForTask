using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBase.Migrations
{
    public partial class InitialCleanDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Passengers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Passengers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Passengers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Passengers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Flights",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Flights",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Flights",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Flights",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Airports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Airports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Airports",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Airports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Airports",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Airports",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Airports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Aircrafts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Aircrafts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Aircrafts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Aircrafts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Aircrafts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Aircrafts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Aircrafts",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Airports");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Airports");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Airports");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Airports");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Airports");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Airports");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Airports");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Aircrafts");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Aircrafts");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Aircrafts");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Aircrafts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Aircrafts");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Aircrafts");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Aircrafts");
        }
    }
}
