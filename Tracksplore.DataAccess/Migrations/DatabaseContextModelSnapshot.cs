﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tracksplore.DataAccess.Contexts;

#nullable disable

namespace Tracksplore.DataAccess.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ArtistMusicTaste", b =>
                {
                    b.Property<Guid>("ArtistsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MusicTastesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ArtistsId", "MusicTastesId");

                    b.HasIndex("MusicTastesId");

                    b.ToTable("ArtistMusicTaste");
                });

            modelBuilder.Entity("Tracksplore.DataAccess.Models.Artist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("SpotifyId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasAlternateKey("SpotifyId");

                    b.ToTable("Artist");
                });

            modelBuilder.Entity("Tracksplore.DataAccess.Models.ExternalLogin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProviderKey")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ProviderName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ExternalLogin");
                });

            modelBuilder.Entity("Tracksplore.DataAccess.Models.GenreFeature", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("MusicTasteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Percentage")
                        .HasMaxLength(100)
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("MusicTasteId");

                    b.ToTable("GenreFeature");
                });

            modelBuilder.Entity("Tracksplore.DataAccess.Models.MusicTaste", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDisabled")
                        .HasColumnType("bit");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("MusicTaste");
                });

            modelBuilder.Entity("Tracksplore.DataAccess.Models.RateLimit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LimitedUntil")
                        .HasColumnType("datetime2");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(3000)
                        .HasColumnType("nvarchar(3000)");

                    b.HasKey("Id");

                    b.ToTable("RateLimits");
                });

            modelBuilder.Entity("Tracksplore.DataAccess.Models.SpotifyToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccessToken")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("ExpiresIn")
                        .HasColumnType("int");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Scope")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("TokenType")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("SpotifyToken");
                });

            modelBuilder.Entity("Tracksplore.DataAccess.Models.Swipe", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Result")
                        .HasColumnType("int");

                    b.Property<string>("SpotifyTrackId")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Swipe");
                });

            modelBuilder.Entity("Tracksplore.DataAccess.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpotifyId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("SpotifyTokenId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasAlternateKey("DisplayName");

                    b.HasAlternateKey("Email");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ArtistMusicTaste", b =>
                {
                    b.HasOne("Tracksplore.DataAccess.Models.Artist", null)
                        .WithMany()
                        .HasForeignKey("ArtistsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tracksplore.DataAccess.Models.MusicTaste", null)
                        .WithMany()
                        .HasForeignKey("MusicTastesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tracksplore.DataAccess.Models.ExternalLogin", b =>
                {
                    b.HasOne("Tracksplore.DataAccess.Models.User", "User")
                        .WithMany("ExternalLogins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Tracksplore.DataAccess.Models.GenreFeature", b =>
                {
                    b.HasOne("Tracksplore.DataAccess.Models.MusicTaste", "MusicTaste")
                        .WithMany("GenreFeatures")
                        .HasForeignKey("MusicTasteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MusicTaste");
                });

            modelBuilder.Entity("Tracksplore.DataAccess.Models.MusicTaste", b =>
                {
                    b.HasOne("Tracksplore.DataAccess.Models.User", "User")
                        .WithMany("MusicTastes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Tracksplore.DataAccess.Models.SpotifyToken", b =>
                {
                    b.HasOne("Tracksplore.DataAccess.Models.User", "User")
                        .WithOne("SpotifyToken")
                        .HasForeignKey("Tracksplore.DataAccess.Models.SpotifyToken", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Tracksplore.DataAccess.Models.Swipe", b =>
                {
                    b.HasOne("Tracksplore.DataAccess.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Tracksplore.DataAccess.Models.MusicTaste", b =>
                {
                    b.Navigation("GenreFeatures");
                });

            modelBuilder.Entity("Tracksplore.DataAccess.Models.User", b =>
                {
                    b.Navigation("ExternalLogins");

                    b.Navigation("MusicTastes");

                    b.Navigation("SpotifyToken");
                });
#pragma warning restore 612, 618
        }
    }
}
