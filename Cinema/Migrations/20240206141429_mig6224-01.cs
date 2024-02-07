using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinema.Migrations
{
    /// <inheritdoc />
    public partial class mig622401 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MallCode",
                table: "CinemaBranch",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "MovieHall",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MallName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MallCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HallCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HallNumber = table.Column<int>(type: "int", nullable: false),
                    NumOfRows = table.Column<int>(name: "Num_Of_Rows", type: "int", nullable: false),
                    NumOfSeats = table.Column<int>(name: "Num_Of_Seats", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieHall", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieHallSeats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HallCode = table.Column<int>(type: "int", nullable: false),
                    RowCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColumnCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieHallSeats", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieHall");

            migrationBuilder.DropTable(
                name: "MovieHallSeats");

            migrationBuilder.DropColumn(
                name: "MallCode",
                table: "CinemaBranch");
        }
    }
}
