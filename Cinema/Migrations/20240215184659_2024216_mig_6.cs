using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinema.Migrations
{
    /// <inheritdoc />
    public partial class _2024216mig6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "MovieShowSeats");

            migrationBuilder.DropColumn(
                name: "ModifedDateTime",
                table: "MovieShowSeats");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "MovieShow");

            migrationBuilder.DropColumn(
                name: "ModifedDateTime",
                table: "MovieShow");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "MovieHallSeats");

            migrationBuilder.DropColumn(
                name: "ModifedDateTime",
                table: "MovieHallSeats");

            migrationBuilder.DropColumn(
                name: "ModifedDateTime",
                table: "MovieHall");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "ModifedDateTime",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "CinemaBranch");

            migrationBuilder.DropColumn(
                name: "ModifedDateTime",
                table: "CinemaBranch");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "ModifedDateTime",
                table: "Account");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                table: "MovieHall",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "MovieShowSeats",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifedDateTime",
                table: "MovieShowSeats",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "MovieShow",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifedDateTime",
                table: "MovieShow",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "MovieHallSeats",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifedDateTime",
                table: "MovieHallSeats",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                table: "MovieHall",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifedDateTime",
                table: "MovieHall",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "Movie",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifedDateTime",
                table: "Movie",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "CinemaBranch",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifedDateTime",
                table: "CinemaBranch",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "Account",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifedDateTime",
                table: "Account",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");
        }
    }
}
