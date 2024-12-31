using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicHaven.Migrations
{
    /// <inheritdoc />
    public partial class SeedWhitePony : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Album",
                columns: new[] { "AlbumId", "DescripcionAlbum", "Genero", "NombreAlbum", "NombreArtista", "TipoAlbumId" },
                values: new object[] { 1, "Sample text", "Nu Metal", "White Pony", "Deftones", 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Album",
                keyColumn: "AlbumId",
                keyValue: 1);
        }
    }
}
