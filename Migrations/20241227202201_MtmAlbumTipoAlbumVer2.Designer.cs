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
    [Migration("20241227202201_MtmAlbumTipoAlbumVer2")]
    partial class MtmAlbumTipoAlbumVer2
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
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("NombreArtista")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<int?>("TipoAlbumId")
                        .HasColumnType("integer");

                    b.HasKey("AlbumId");

                    b.HasIndex("TipoAlbumId");

                    b.ToTable("Album");
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

                    b.ToTable("TipoAlbum");

                    b.HasData(
                        new
                        {
                            TipoAlbumId = 1,
                            NombreTipoAlbum = "Single"
                        },
                        new
                        {
                            TipoAlbumId = 2,
                            NombreTipoAlbum = "LP"
                        },
                        new
                        {
                            TipoAlbumId = 3,
                            NombreTipoAlbum = "EP"
                        });
                });

            modelBuilder.Entity("MusicHaven.Models.Album", b =>
                {
                    b.HasOne("MusicHaven.Models.TipoAlbum", "TipoAlbum")
                        .WithMany("Albums")
                        .HasForeignKey("TipoAlbumId");

                    b.Navigation("TipoAlbum");
                });

            modelBuilder.Entity("MusicHaven.Models.TipoAlbum", b =>
                {
                    b.Navigation("Albums");
                });
#pragma warning restore 612, 618
        }
    }
}
