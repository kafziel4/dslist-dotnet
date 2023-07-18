﻿// <auto-generated />
using DSList.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PostgresMigrations.Migrations
{
    [DbContext(typeof(GameDbContext))]
    partial class GameDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DSList.Data.Entities.Game", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("LongDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Platforms")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<double>("Score")
                        .HasColumnType("double precision");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<int>("Year")
                        .HasColumnType("integer")
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
#pragma warning restore 612, 618
        }
    }
}