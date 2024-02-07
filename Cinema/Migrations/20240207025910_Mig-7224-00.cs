using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinema.Migrations
{
    /// <inheritdoc />
    public partial class Mig722400 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColumnCode",
                table: "MovieHallSeats");

            migrationBuilder.DropColumn(
                name: "RowCode",
                table: "MovieHallSeats");

            migrationBuilder.DropColumn(
                name: "HallNumber",
                table: "MovieHall");

            migrationBuilder.RenameColumn(
                name: "HallCode",
                table: "MovieHallSeats",
                newName: "SeatNumber");

            migrationBuilder.RenameColumn(
                name: "MallCode",
                table: "MovieHall",
                newName: "HallName");

            migrationBuilder.AddColumn<bool>(
                name: "IsOccupied",
                table: "MovieHallSeats",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "RowNumber",
                table: "MovieHallSeats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "MovieHall",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "Movie",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOccupied",
                table: "MovieHallSeats");

            migrationBuilder.DropColumn(
                name: "RowNumber",
                table: "MovieHallSeats");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "MovieHall");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "Movie");

            migrationBuilder.RenameColumn(
                name: "SeatNumber",
                table: "MovieHallSeats",
                newName: "HallCode");

            migrationBuilder.RenameColumn(
                name: "HallName",
                table: "MovieHall",
                newName: "MallCode");

            migrationBuilder.AddColumn<string>(
                name: "ColumnCode",
                table: "MovieHallSeats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RowCode",
                table: "MovieHallSeats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "HallNumber",
                table: "MovieHall",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
