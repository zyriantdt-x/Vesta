﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vesta.Players.Storage;

#nullable disable

namespace Vesta.Players.Migrations
{
    [DbContext(typeof(PlayersDbContext))]
    [Migration("20240911072946_player_v2")]
    partial class player_v2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Vesta.Players.Storage.Sets.PlayerData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Credits")
                        .HasColumnType("int")
                        .HasColumnName("credits");

                    b.Property<string>("Figure")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("figure");

                    b.Property<int>("Film")
                        .HasColumnType("int")
                        .HasColumnName("film");

                    b.Property<string>("Mission")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("mission");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("password");

                    b.Property<string>("PoolFigure")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("pool_figure");

                    b.Property<bool>("ReceiveNews")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("receive_news");

                    b.Property<bool>("Sex")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("sex");

                    b.Property<int>("Tickets")
                        .HasColumnType("int")
                        .HasColumnName("tickets");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.ToTable("player_data");
                });
#pragma warning restore 612, 618
        }
    }
}
