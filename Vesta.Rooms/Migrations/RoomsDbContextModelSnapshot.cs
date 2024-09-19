﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vesta.Rooms.Storage;

#nullable disable

namespace Vesta.Rooms.Migrations
{
    [DbContext(typeof(RoomsDbContext))]
    partial class RoomsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Vesta.Rooms.Storage.Sets.RoomData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessType")
                        .HasColumnType("int")
                        .HasColumnName("accesstype");

                    b.Property<int>("Category")
                        .HasColumnType("int")
                        .HasColumnName("category");

                    b.Property<string>("Ccts")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("ccts");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("description");

                    b.Property<int>("Floor")
                        .HasColumnType("int")
                        .HasColumnName("floor");

                    b.Property<bool>("IsHidden")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_hidden");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("model");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.Property<string>("OwnerId")
                        .IsRequired()
                        .HasColumnType("varchar(11)")
                        .HasColumnName("owner_id");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("password");

                    b.Property<int>("Rating")
                        .HasColumnType("int")
                        .HasColumnName("rating");

                    b.Property<bool>("ShowName")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("showname");

                    b.Property<bool>("SuperUsers")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("superusers");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.Property<int>("VisitorsMax")
                        .HasColumnType("int")
                        .HasColumnName("visitors_max");

                    b.Property<int>("VisitorsNow")
                        .HasColumnType("int")
                        .HasColumnName("visitors_now");

                    b.Property<int>("Wallpaper")
                        .HasColumnType("int")
                        .HasColumnName("wallpaper");

                    b.HasKey("Id");

                    b.ToTable("room_data");
                });

            modelBuilder.Entity("Vesta.Rooms.Storage.Sets.RoomModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DoorDir")
                        .HasColumnType("int")
                        .HasColumnName("door_dir");

                    b.Property<int>("DoorX")
                        .HasColumnType("int")
                        .HasColumnName("door_x");

                    b.Property<int>("DoorY")
                        .HasColumnType("int")
                        .HasColumnName("door_y");

                    b.Property<int>("DoorZ")
                        .HasColumnType("int")
                        .HasColumnName("door_z");

                    b.Property<string>("Heightmap")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("heightmap");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("model_id");

                    b.Property<string>("TriggerClass")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("trigger_class");

                    b.HasKey("Id");

                    b.ToTable("room_models");
                });
#pragma warning restore 612, 618
        }
    }
}
