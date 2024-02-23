using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinema.Migrations
{
    /// <inheritdoc />
    public partial class _240217testmig93 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieShowTime_MovieShow_MovieShowId",
                table: "MovieShowTime");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieShowTime",
                table: "MovieShowTime");

            migrationBuilder.RenameTable(
                name: "MovieShowTime",
                newName: "MovieShowTimes");

            migrationBuilder.RenameIndex(
                name: "IX_MovieShowTime_MovieShowId",
                table: "MovieShowTimes",
                newName: "IX_MovieShowTimes_MovieShowId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieShowTimes",
                table: "MovieShowTimes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieShowTimes_MovieShow_MovieShowId",
                table: "MovieShowTimes",
                column: "MovieShowId",
                principalTable: "MovieShow",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieShowTimes_MovieShow_MovieShowId",
                table: "MovieShowTimes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieShowTimes",
                table: "MovieShowTimes");

            migrationBuilder.RenameTable(
                name: "MovieShowTimes",
                newName: "MovieShowTime");

            migrationBuilder.RenameIndex(
                name: "IX_MovieShowTimes_MovieShowId",
                table: "MovieShowTime",
                newName: "IX_MovieShowTime_MovieShowId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieShowTime",
                table: "MovieShowTime",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieShowTime_MovieShow_MovieShowId",
                table: "MovieShowTime",
                column: "MovieShowId",
                principalTable: "MovieShow",
                principalColumn: "Id");
        }
    }
}
