using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinema.Migrations
{
    /// <inheritdoc />
    public partial class _240217testmig91 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HallCode",
                table: "MovieShow");

            migrationBuilder.AddColumn<string>(
                name: "HallCode",
                table: "MovieShowTime",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HallCode",
                table: "MovieShowTime");

            migrationBuilder.AddColumn<string>(
                name: "HallCode",
                table: "MovieShow",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
