﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicAPI.Models;

#nullable disable

namespace MusicAPI.Migrations
{
    [DbContext(typeof(MusicDbContext))]
    [Migration("20230219172935_creatDb")]
    partial class creatDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MusicAPI.Models.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AlbumName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateReleased")
                        .HasColumnType("datetime2");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.HasIndex("GenreId");

                    b.ToTable("Albums");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AlbumName = "Album 1",
                            ArtistId = 1,
                            DateReleased = new DateTime(2022, 9, 22, 19, 29, 34, 553, DateTimeKind.Local).AddTicks(6572),
                            GenreId = 2
                        },
                        new
                        {
                            Id = 2,
                            AlbumName = "Album 2",
                            ArtistId = 2,
                            DateReleased = new DateTime(2021, 8, 18, 19, 29, 34, 553, DateTimeKind.Local).AddTicks(6624),
                            GenreId = 2
                        },
                        new
                        {
                            Id = 3,
                            AlbumName = "Album 3",
                            ArtistId = 1,
                            DateReleased = new DateTime(2033, 2, 19, 19, 29, 34, 553, DateTimeKind.Local).AddTicks(6633),
                            GenreId = 3
                        },
                        new
                        {
                            Id = 4,
                            AlbumName = "Album 4",
                            ArtistId = 3,
                            DateReleased = new DateTime(2015, 8, 19, 19, 29, 34, 553, DateTimeKind.Local).AddTicks(6638),
                            GenreId = 1
                        });
                });

            modelBuilder.Entity("MusicAPI.Models.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ArtistName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Artists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArtistName = "Amr Diab"
                        },
                        new
                        {
                            Id = 2,
                            ArtistName = "Tamer Hosny"
                        },
                        new
                        {
                            Id = 3,
                            ArtistName = "Bahaa Sultan"
                        },
                        new
                        {
                            Id = 4,
                            ArtistName = "Tamer Ashour"
                        });
                });

            modelBuilder.Entity("MusicAPI.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("GenreName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GenreName = "Romance"
                        },
                        new
                        {
                            Id = 2,
                            GenreName = "Hip Hop"
                        },
                        new
                        {
                            Id = 3,
                            GenreName = "Classic"
                        },
                        new
                        {
                            Id = 4,
                            GenreName = "Rock"
                        });
                });

            modelBuilder.Entity("MusicAPI.Models.Album", b =>
                {
                    b.HasOne("MusicAPI.Models.Artist", "Artist")
                        .WithMany("Albums")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicAPI.Models.Genre", "Genre")
                        .WithMany("Albums")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("MusicAPI.Models.Artist", b =>
                {
                    b.Navigation("Albums");
                });

            modelBuilder.Entity("MusicAPI.Models.Genre", b =>
                {
                    b.Navigation("Albums");
                });
#pragma warning restore 612, 618
        }
    }
}
