using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PictureStore.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueConstraintToPictureName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Pictures",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_Name",
                table: "Pictures",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pictures_Name",
                table: "Pictures");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Pictures",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
