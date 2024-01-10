using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MehmetUtkuGunduz.Migrations
{
    /// <inheritdoc />
    public partial class Photoupload : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Estates_ImageId",
                table: "Estates");

            migrationBuilder.DropIndex(
                name: "IX_Estates_VideoId",
                table: "Estates");

            migrationBuilder.AddColumn<string>(
                name: "EstatePhotoUrl",
                table: "Estates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Estates_ImageId",
                table: "Estates",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Estates_VideoId",
                table: "Estates",
                column: "VideoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Estates_ImageId",
                table: "Estates");

            migrationBuilder.DropIndex(
                name: "IX_Estates_VideoId",
                table: "Estates");

            migrationBuilder.DropColumn(
                name: "EstatePhotoUrl",
                table: "Estates");

            migrationBuilder.CreateIndex(
                name: "IX_Estates_ImageId",
                table: "Estates",
                column: "ImageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Estates_VideoId",
                table: "Estates",
                column: "VideoId",
                unique: true);
        }
    }
}
