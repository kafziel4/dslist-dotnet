﻿// <auto-generated />
using DSList.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace SqliteMigrations.Migrations
{
    [DbContext(typeof(GameDbContext))]
    [Migration("20230719012001_CreateBelonging")]
    partial class CreateBelonging
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.9");

            modelBuilder.Entity("DSList.Data.Entities.Belonging", b =>
                {
                    b.Property<long>("GameId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("GameListId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Position")
                        .HasColumnType("INTEGER");

                    b.HasKey("GameId", "GameListId");

                    b.HasIndex("GameListId");

                    b.ToTable("Belongings");

                    b.HasData(
                        new
                        {
                            GameId = 1L,
                            GameListId = 1L,
                            Position = 0
                        },
                        new
                        {
                            GameId = 2L,
                            GameListId = 1L,
                            Position = 1
                        },
                        new
                        {
                            GameId = 3L,
                            GameListId = 1L,
                            Position = 2
                        },
                        new
                        {
                            GameId = 4L,
                            GameListId = 1L,
                            Position = 3
                        },
                        new
                        {
                            GameId = 5L,
                            GameListId = 1L,
                            Position = 4
                        },
                        new
                        {
                            GameId = 6L,
                            GameListId = 2L,
                            Position = 0
                        },
                        new
                        {
                            GameId = 7L,
                            GameListId = 2L,
                            Position = 1
                        },
                        new
                        {
                            GameId = 8L,
                            GameListId = 2L,
                            Position = 2
                        },
                        new
                        {
                            GameId = 9L,
                            GameListId = 2L,
                            Position = 3
                        },
                        new
                        {
                            GameId = 10L,
                            GameListId = 2L,
                            Position = 4
                        });
                });

            modelBuilder.Entity("DSList.Data.Entities.Game", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<string>("LongDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Platforms")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<double>("Score")
                        .HasColumnType("REAL");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER")
                        .HasColumnName("game_year");

                    b.HasKey("Id");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Genre = "Role-playing (RPG), Shooter",
                            ImgUrl = "https://raw.githubusercontent.com/devsuperior/java-spring-dslist/main/resources/1.png",
                            LongDescription = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Delectus dolorum illum placeat eligendi, quis maiores veniam. Incidunt dolorum, nisi deleniti dicta odit voluptatem nam provident temporibus reprehenderit blanditiis consectetur tenetur. Dignissimos blanditiis quod corporis iste, aliquid perspiciatis architecto quasi tempore ipsam voluptates ea ad distinctio, sapiente qui, amet quidem culpa.",
                            Platforms = "XBox, Playstation, PC",
                            Score = 4.7999999999999998,
                            ShortDescription = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Odit esse officiis corrupti unde repellat non quibusdam! Id nihil itaque ipsum!",
                            Title = "Mass Effect Trilogy",
                            Year = 2012
                        },
                        new
                        {
                            Id = 2L,
                            Genre = "Role-playing (RPG), Adventure",
                            ImgUrl = "https://raw.githubusercontent.com/devsuperior/java-spring-dslist/main/resources/2.png",
                            LongDescription = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Delectus dolorum illum placeat eligendi, quis maiores veniam. Incidunt dolorum, nisi deleniti dicta odit voluptatem nam provident temporibus reprehenderit blanditiis consectetur tenetur. Dignissimos blanditiis quod corporis iste, aliquid perspiciatis architecto quasi tempore ipsam voluptates ea ad distinctio, sapiente qui, amet quidem culpa.",
                            Platforms = "XBox, Playstation, PC",
                            Score = 4.7000000000000002,
                            ShortDescription = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Odit esse officiis corrupti unde repellat non quibusdam! Id nihil itaque ipsum!",
                            Title = "Red Dead Redemption 2",
                            Year = 2018
                        },
                        new
                        {
                            Id = 3L,
                            Genre = "Role-playing (RPG), Adventure",
                            ImgUrl = "https://raw.githubusercontent.com/devsuperior/java-spring-dslist/main/resources/3.png",
                            LongDescription = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Delectus dolorum illum placeat eligendi, quis maiores veniam. Incidunt dolorum, nisi deleniti dicta odit voluptatem nam provident temporibus reprehenderit blanditiis consectetur tenetur. Dignissimos blanditiis quod corporis iste, aliquid perspiciatis architecto quasi tempore ipsam voluptates ea ad distinctio, sapiente qui, amet quidem culpa.",
                            Platforms = "XBox, Playstation, PC",
                            Score = 4.7000000000000002,
                            ShortDescription = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Odit esse officiis corrupti unde repellat non quibusdam! Id nihil itaque ipsum!",
                            Title = "The Witcher 3: Wild Hunt",
                            Year = 2015
                        },
                        new
                        {
                            Id = 4L,
                            Genre = "Role-playing (RPG), Adventure",
                            ImgUrl = "https://raw.githubusercontent.com/devsuperior/java-spring-dslist/main/resources/4.png",
                            LongDescription = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Delectus dolorum illum placeat eligendi, quis maiores veniam. Incidunt dolorum, nisi deleniti dicta odit voluptatem nam provident temporibus reprehenderit blanditiis consectetur tenetur. Dignissimos blanditiis quod corporis iste, aliquid perspiciatis architecto quasi tempore ipsam voluptates ea ad distinctio, sapiente qui, amet quidem culpa.",
                            Platforms = "XBox, Playstation, PC",
                            Score = 3.7999999999999998,
                            ShortDescription = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Odit esse officiis corrupti unde repellat non quibusdam! Id nihil itaque ipsum!",
                            Title = "Sekiro: Shadows Die Twice",
                            Year = 2019
                        },
                        new
                        {
                            Id = 5L,
                            Genre = "Role-playing (RPG), Adventure",
                            ImgUrl = "https://raw.githubusercontent.com/devsuperior/java-spring-dslist/main/resources/5.png",
                            LongDescription = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Delectus dolorum illum placeat eligendi, quis maiores veniam. Incidunt dolorum, nisi deleniti dicta odit voluptatem nam provident temporibus reprehenderit blanditiis consectetur tenetur. Dignissimos blanditiis quod corporis iste, aliquid perspiciatis architecto quasi tempore ipsam voluptates ea ad distinctio, sapiente qui, amet quidem culpa.",
                            Platforms = "XBox, Playstation, PC",
                            Score = 4.5999999999999996,
                            ShortDescription = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Odit esse officiis corrupti unde repellat non quibusdam! Id nihil itaque ipsum!",
                            Title = "Ghost of Tsushima",
                            Year = 2020
                        },
                        new
                        {
                            Id = 6L,
                            Genre = "Platform",
                            ImgUrl = "https://raw.githubusercontent.com/devsuperior/java-spring-dslist/main/resources/6.png",
                            LongDescription = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Delectus dolorum illum placeat eligendi, quis maiores veniam. Incidunt dolorum, nisi deleniti dicta odit voluptatem nam provident temporibus reprehenderit blanditiis consectetur tenetur. Dignissimos blanditiis quod corporis iste, aliquid perspiciatis architecto quasi tempore ipsam voluptates ea ad distinctio, sapiente qui, amet quidem culpa.",
                            Platforms = "Super Nes, PC",
                            Score = 4.7000000000000002,
                            ShortDescription = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Odit esse officiis corrupti unde repellat non quibusdam! Id nihil itaque ipsum!",
                            Title = "Super Mario World",
                            Year = 1990
                        },
                        new
                        {
                            Id = 7L,
                            Genre = "Platform",
                            ImgUrl = "https://raw.githubusercontent.com/devsuperior/java-spring-dslist/main/resources/7.png",
                            LongDescription = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Delectus dolorum illum placeat eligendi, quis maiores veniam. Incidunt dolorum, nisi deleniti dicta odit voluptatem nam provident temporibus reprehenderit blanditiis consectetur tenetur. Dignissimos blanditiis quod corporis iste, aliquid perspiciatis architecto quasi tempore ipsam voluptates ea ad distinctio, sapiente qui, amet quidem culpa.",
                            Platforms = "XBox, Playstation, PC",
                            Score = 4.5999999999999996,
                            ShortDescription = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Odit esse officiis corrupti unde repellat non quibusdam! Id nihil itaque ipsum!",
                            Title = "Hollow Knight",
                            Year = 2017
                        },
                        new
                        {
                            Id = 8L,
                            Genre = "Platform",
                            ImgUrl = "https://raw.githubusercontent.com/devsuperior/java-spring-dslist/main/resources/8.png",
                            LongDescription = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Delectus dolorum illum placeat eligendi, quis maiores veniam. Incidunt dolorum, nisi deleniti dicta odit voluptatem nam provident temporibus reprehenderit blanditiis consectetur tenetur. Dignissimos blanditiis quod corporis iste, aliquid perspiciatis architecto quasi tempore ipsam voluptates ea ad distinctio, sapiente qui, amet quidem culpa.",
                            Platforms = "XBox, Playstation, PC",
                            Score = 4.0,
                            ShortDescription = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Odit esse officiis corrupti unde repellat non quibusdam! Id nihil itaque ipsum!",
                            Title = "Ori and the Blind Forest",
                            Year = 2015
                        },
                        new
                        {
                            Id = 9L,
                            Genre = "Platform",
                            ImgUrl = "https://raw.githubusercontent.com/devsuperior/java-spring-dslist/main/resources/9.png",
                            LongDescription = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Delectus dolorum illum placeat eligendi, quis maiores veniam. Incidunt dolorum, nisi deleniti dicta odit voluptatem nam provident temporibus reprehenderit blanditiis consectetur tenetur. Dignissimos blanditiis quod corporis iste, aliquid perspiciatis architecto quasi tempore ipsam voluptates ea ad distinctio, sapiente qui, amet quidem culpa.",
                            Platforms = "XBox, Playstation, PC",
                            Score = 4.5999999999999996,
                            ShortDescription = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Odit esse officiis corrupti unde repellat non quibusdam! Id nihil itaque ipsum!",
                            Title = "Cuphead",
                            Year = 2017
                        },
                        new
                        {
                            Id = 10L,
                            Genre = "Platform",
                            ImgUrl = "https://raw.githubusercontent.com/devsuperior/java-spring-dslist/main/resources/10.png",
                            LongDescription = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Delectus dolorum illum placeat eligendi, quis maiores veniam. Incidunt dolorum, nisi deleniti dicta odit voluptatem nam provident temporibus reprehenderit blanditiis consectetur tenetur. Dignissimos blanditiis quod corporis iste, aliquid perspiciatis architecto quasi tempore ipsam voluptates ea ad distinctio, sapiente qui, amet quidem culpa.",
                            Platforms = "Sega CD, PC",
                            Score = 4.0,
                            ShortDescription = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Odit esse officiis corrupti unde repellat non quibusdam! Id nihil itaque ipsum!",
                            Title = "Sonic CD",
                            Year = 1993
                        });
                });

            modelBuilder.Entity("DSList.Data.Entities.GameList", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("GameLists");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Aventura e RPG"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Jogos de plataforma"
                        });
                });

            modelBuilder.Entity("DSList.Data.Entities.Belonging", b =>
                {
                    b.HasOne("DSList.Data.Entities.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DSList.Data.Entities.GameList", "GameList")
                        .WithMany()
                        .HasForeignKey("GameListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("GameList");
                });
#pragma warning restore 612, 618
        }
    }
}
