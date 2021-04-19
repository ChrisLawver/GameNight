﻿// <auto-generated />
using System;
using GameNight;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GameNight.Migrations
{
    [DbContext(typeof(GameNightContext))]
    partial class GameNightContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GameNight.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Owner")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PlayedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = false,
                            GameId = 1,
                            Location = "16-Bit",
                            Name = "Tournament",
                            OwnerId = 0,
                            PlayedOn = new DateTime(2021, 4, 19, 13, 27, 51, 313, DateTimeKind.Local).AddTicks(5567)
                        });
                });

            modelBuilder.Entity("GameNight.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ExternalId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxPlayers")
                        .HasColumnType("int");

                    b.Property<int>("MinPlayers")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MaxPlayers = 0,
                            MinPlayers = 0,
                            Title = "Chess"
                        },
                        new
                        {
                            Id = 2,
                            MaxPlayers = 0,
                            MinPlayers = 0,
                            Title = "Checkers"
                        });
                });

            modelBuilder.Entity("GameNight.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Lose")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Win")
                        .HasColumnType("int");

                    b.Property<double>("WinPercent")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Location = "Mushroom Kingdom",
                            Lose = 0,
                            Password = "password",
                            ProfilePic = "https://cdn.vox-cdn.com/thumbor/QyaLYNjgXHUP4aQjxDsyG_Gw9w0=/0x0:1700x960/1075x1075/filters:focal(714x344:986x616):format(webp)/cdn.vox-cdn.com/uploads/chorus_image/image/57514059/mario.0.jpg",
                            Username = "mario",
                            Win = 0,
                            WinPercent = 0.0
                        },
                        new
                        {
                            Id = 2,
                            Location = "Mushroom Kingdom",
                            Lose = 0,
                            Password = "password2",
                            ProfilePic = "https://play.nintendo.com/images/Masthead_luigi.17345b1513ac044897cfc243542899dce541e8dc.9afde10b.png",
                            Username = "luigi",
                            Win = 0,
                            WinPercent = 0.0
                        });
                });

            modelBuilder.Entity("GameNight.Models.UserEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<bool>("IsWin")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("UserEvents");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = false,
                            EventId = 1,
                            IsWin = true,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Active = false,
                            EventId = 1,
                            IsWin = false,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("GameNight.Models.UserGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("UserId");

                    b.ToTable("UserGames");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GameId = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            GameId = 1,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("GameNight.Models.Event", b =>
                {
                    b.HasOne("GameNight.Models.Game", "Game")
                        .WithMany("Events")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameNight.Models.UserEvent", b =>
                {
                    b.HasOne("GameNight.Models.Event", "Event")
                        .WithMany("Attendees")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameNight.Models.User", "User")
                        .WithMany("Events")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameNight.Models.UserGame", b =>
                {
                    b.HasOne("GameNight.Models.Game", "Game")
                        .WithMany("Players")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameNight.Models.User", "User")
                        .WithMany("Games")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
