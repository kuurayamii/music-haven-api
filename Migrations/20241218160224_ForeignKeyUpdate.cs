using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MusicHaven.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeyUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoAlbumId",
                table: "Albums",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AlbumId = table.Column<int>(type: "integer", nullable: false),
                    TituloReview = table.Column<string>(type: "text", nullable: false),
                    CuerpoReview = table.Column<string>(type: "text", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Review_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "AlbumId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_AlbumId",
                table: "Tracks",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Albums_TipoAlbumId",
                table: "Albums",
                column: "TipoAlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_AlbumId",
                table: "Review",
                column: "AlbumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_TiposAlbum_TipoAlbumId",
                table: "Albums",
                column: "TipoAlbumId",
                principalTable: "TiposAlbum",
                principalColumn: "TipoAlbumId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Albums_AlbumId",
                table: "Tracks",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "AlbumId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_TiposAlbum_TipoAlbumId",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Albums_AlbumId",
                table: "Tracks");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Tracks_AlbumId",
                table: "Tracks");

            migrationBuilder.DropIndex(
                name: "IX_Albums_TipoAlbumId",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "TipoAlbumId",
                table: "Albums");
        }
    }
}
