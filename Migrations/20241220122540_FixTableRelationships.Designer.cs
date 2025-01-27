﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicHaven;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MusicHaven.Migrations
{
    [DbContext(typeof(MusicContext))]
    [Migration("20241220122540_FixTableRelationships")]
    partial class FixTableRelationships
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MusicHaven.Models.Album", b =>
                {
                    b.Property<int>("AlbumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AlbumId"));

                    b.Property<string>("DescripcionAlbum")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NombreAlbum")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NombreArtista")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ReviewId")
                        .HasColumnType("integer");

                    b.Property<int>("TipoAlbumId")
                        .HasColumnType("integer");

                    b.Property<int>("TrackId")
                        .HasColumnType("integer");

                    b.HasKey("AlbumId");

                    b.HasIndex("ReviewId");

                    b.HasIndex("TipoAlbumId")
                        .IsUnique();

                    b.HasIndex("TrackId");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("MusicHaven.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ReviewId"));

                    b.Property<string>("CuerpoReview")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<string>("TituloReview")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ReviewId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("MusicHaven.Models.TipoAlbum", b =>
                {
                    b.Property<int>("TipoAlbumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TipoAlbumId"));

                    b.Property<string>("NombreTipoAlbum")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("TipoAlbumId");

                    b.ToTable("TiposAlbum");
                });

            modelBuilder.Entity("MusicHaven.Models.Track", b =>
                {
                    b.Property<int>("TrackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TrackId"));

                    b.Property<string>("NombreTrack")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("NumeroTrack")
                        .HasColumnType("integer");

                    b.HasKey("TrackId");

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("MusicHaven.Models.Album", b =>
                {
                    b.HasOne("MusicHaven.Models.Review", "Review")
                        .WithMany("Albums")
                        .HasForeignKey("ReviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicHaven.Models.TipoAlbum", "TipoAlbum")
                        .WithOne("Album")
                        .HasForeignKey("MusicHaven.Models.Album", "TipoAlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicHaven.Models.Track", "Track")
                        .WithMany("Albums")
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Review");

                    b.Navigation("TipoAlbum");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("MusicHaven.Models.Review", b =>
                {
                    b.Navigation("Albums");
                });

            modelBuilder.Entity("MusicHaven.Models.TipoAlbum", b =>
                {
                    b.Navigation("Album")
                        .IsRequired();
                });

            modelBuilder.Entity("MusicHaven.Models.Track", b =>
                {
                    b.Navigation("Albums");
                });
#pragma warning restore 612, 618
        }
    }
}
