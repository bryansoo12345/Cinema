using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinema.Migrations
{
    /// <inheritdoc />
    public partial class _2222401 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MovieShowTimeCode",
                table: "MovieHall",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieShowTimeCode",
                table: "MovieHall");
        }
    }
}
