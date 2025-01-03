using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicHaven.Migrations
{
    /// <inheritdoc />
    public partial class FixTableRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Albums_AlbumId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Albums_AlbumId",
                table: "Tracks");

            migrationBuilder.DropIndex(
                name: "IX_Tracks_AlbumId",
                table: "Tracks");

            migrationBuilder.DropIndex(
                name: "IX_Review_AlbumId",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Albums_TipoAlbumId",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "AlbumId",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "AlbumId",
                table: "Review");

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

            migrationBuilder.CreateIndex(
                name: "IX_Albums_ReviewId",
                table: "Albums",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Albums_TipoAlbumId",
                table: "Albums",
                column: "TipoAlbumId",
                unique: true);

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
                name: "FK_Albums_Tracks_TrackId",
                table: "Albums",
                column: "TrackId",
                principalTable: "Tracks",
                principalColumn: "TrackId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Review_ReviewId",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Tracks_TrackId",
                table: "Albums");

            migrationBuilder.DropIndex(
                name: "IX_Albums_ReviewId",
                table: "Albums");

            migrationBuilder.DropIndex(
                name: "IX_Albums_TipoAlbumId",
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

            migrationBuilder.AddColumn<int>(
                name: "AlbumId",
                table: "Tracks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AlbumId",
                table: "Review",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_AlbumId",
                table: "Tracks",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_AlbumId",
                table: "Review",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Albums_TipoAlbumId",
                table: "Albums",
                column: "TipoAlbumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Albums_AlbumId",
                table: "Review",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "AlbumId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Albums_AlbumId",
                table: "Tracks",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "AlbumId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
