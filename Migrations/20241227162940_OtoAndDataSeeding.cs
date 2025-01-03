using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MusicHaven.Migrations
{
    /// <inheritdoc />
    public partial class OtoAndDataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Review_ReviewId",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Albums_TiposAlbum_TipoAlbumId",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Tracks_TrackId",
                table: "Albums");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TiposAlbum",
                table: "TiposAlbum");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Albums",
                table: "Albums");

            migrationBuilder.DropIndex(
                name: "IX_Albums_ReviewId",
                table: "Albums");

            migrationBuilder.DropIndex(
                name: "IX_Albums_TrackId",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "ReviewId",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "TrackId",
                table: "Albums");

            migrationBuilder.RenameTable(
                name: "TiposAlbum",
                newName: "TipoAlbum");

            migrationBuilder.RenameTable(
                name: "Albums",
                newName: "Album");

            migrationBuilder.RenameIndex(
                name: "IX_Albums_TipoAlbumId",
                table: "Album",
                newName: "IX_Album_TipoAlbumId");

            migrationBuilder.AlterColumn<string>(
                name: "NombreArtista",
                table: "Album",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "NombreAlbum",
                table: "Album",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoAlbum",
                table: "TipoAlbum",
                column: "TipoAlbumId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Album",
                table: "Album",
                column: "AlbumId");

            migrationBuilder.InsertData(
                table: "TipoAlbum",
                columns: new[] { "TipoAlbumId", "NombreTipoAlbum" },
                values: new object[,]
                {
                    { 1, "Single" },
                    { 2, "LP" },
                    { 3, "EP" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Album_TipoAlbum_TipoAlbumId",
                table: "Album",
                column: "TipoAlbumId",
                principalTable: "TipoAlbum",
                principalColumn: "TipoAlbumId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_TipoAlbum_TipoAlbumId",
                table: "Album");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoAlbum",
                table: "TipoAlbum");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Album",
                table: "Album");

            migrationBuilder.DeleteData(
                table: "TipoAlbum",
                keyColumn: "TipoAlbumId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TipoAlbum",
                keyColumn: "TipoAlbumId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TipoAlbum",
                keyColumn: "TipoAlbumId",
                keyValue: 3);

            migrationBuilder.RenameTable(
                name: "TipoAlbum",
                newName: "TiposAlbum");

            migrationBuilder.RenameTable(
                name: "Album",
                newName: "Albums");

            migrationBuilder.RenameIndex(
                name: "IX_Album_TipoAlbumId",
                table: "Albums",
                newName: "IX_Albums_TipoAlbumId");

            migrationBuilder.AlterColumn<string>(
                name: "NombreArtista",
                table: "Albums",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "NombreAlbum",
                table: "Albums",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AddColumn<int>(
                name: "ReviewId",
                table: "Albums",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TrackId",
                table: "Albums",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TiposAlbum",
                table: "TiposAlbum",
                column: "TipoAlbumId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Albums",
                table: "Albums",
                column: "AlbumId");

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CuerpoReview = table.Column<string>(type: "text", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    TituloReview = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ReviewId);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    TrackId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NombreTrack = table.Column<string>(type: "text", nullable: false),
                    NumeroTrack = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.TrackId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_ReviewId",
                table: "Albums",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Albums_TrackId",
                table: "Albums",
                column: "TrackId");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Review_ReviewId",
                table: "Albums",
                column: "ReviewId",
                principalTable: "Review",
                principalColumn: "ReviewId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_TiposAlbum_TipoAlbumId",
                table: "Albums",
                column: "TipoAlbumId",
                principalTable: "TiposAlbum",
                principalColumn: "TipoAlbumId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Tracks_TrackId",
                table: "Albums",
                column: "TrackId",
                principalTable: "Tracks",
                principalColumn: "TrackId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
