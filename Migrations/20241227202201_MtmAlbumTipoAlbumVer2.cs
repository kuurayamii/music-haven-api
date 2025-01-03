using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicHaven.Migrations
{
    /// <inheritdoc />
    public partial class MtmAlbumTipoAlbumVer2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_TipoAlbum_TipoAlbumId",
                table: "Album");

            migrationBuilder.AlterColumn<int>(
                name: "TipoAlbumId",
                table: "Album",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Album_TipoAlbum_TipoAlbumId",
                table: "Album",
                column: "TipoAlbumId",
                principalTable: "TipoAlbum",
                principalColumn: "TipoAlbumId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_TipoAlbum_TipoAlbumId",
                table: "Album");

            migrationBuilder.AlterColumn<int>(
                name: "TipoAlbumId",
                table: "Album",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Album_TipoAlbum_TipoAlbumId",
                table: "Album",
                column: "TipoAlbumId",
                principalTable: "TipoAlbum",
                principalColumn: "TipoAlbumId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
