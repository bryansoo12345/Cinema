using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinema.Migrations
{
    /// <inheritdoc />
    public partial class mig622403 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Num_Of_Seats",
                table: "MovieHall",
                newName: "NumberOfSeats");

            migrationBuilder.RenameColumn(
                name: "Num_Of_Rows",
                table: "MovieHall",
                newName: "NumberOfRows");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumberOfSeats",
                table: "MovieHall",
                newName: "Num_Of_Seats");

            migrationBuilder.RenameColumn(
                name: "NumberOfRows",
                table: "MovieHall",
                newName: "Num_Of_Rows");
        }
    }
}
