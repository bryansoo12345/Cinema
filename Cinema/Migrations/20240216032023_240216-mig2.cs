using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinema.Migrations
{
    /// <inheritdoc />
    public partial class _240216mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CoverPhoto",
                table: "Movie",
                newName: "PhotoFile");

            migrationBuilder.RenameColumn(
                name: "CinemaPhoto",
                table: "CinemaBranch",
                newName: "PhotoFile");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhotoFile",
                table: "Movie",
                newName: "CoverPhoto");

            migrationBuilder.RenameColumn(
                name: "PhotoFile",
                table: "CinemaBranch",
                newName: "CinemaPhoto");
        }
    }
}
