using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicHaven.Migrations
{
    /// <inheritdoc />
    public partial class MtmAlbumTipoAlbum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Album_TipoAlbumId",
                table: "Album");

            migrationBuilder.CreateIndex(
                name: "IX_Album_TipoAlbumId",
                table: "Album",
                column: "TipoAlbumId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Album_TipoAlbumId",
                table: "Album");

            migrationBuilder.CreateIndex(
                name: "IX_Album_TipoAlbumId",
                table: "Album",
                column: "TipoAlbumId",
                unique: true);
        }
    }
}
