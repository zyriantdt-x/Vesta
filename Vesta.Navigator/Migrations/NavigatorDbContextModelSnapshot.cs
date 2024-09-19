﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vesta.Navigator.Storage;

#nullable disable

namespace Vesta.Navigator.Migrations
{
    [DbContext(typeof(NavigatorDbContext))]
    partial class NavigatorDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Vesta.Navigator.Storage.Sets.NavigatorCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsNode")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_node");

                    b.Property<bool>("IsPublicSpace")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_public_space");

                    b.Property<bool>("IsTradingAllowed")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_trading_allowed");

                    b.Property<int>("MinAccess")
                        .HasColumnType("int")
                        .HasColumnName("min_access");

                    b.Property<int>("MinAssign")
                        .HasColumnType("int")
                        .HasColumnName("min_assign");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<int>("ParentId")
                        .HasColumnType("int")
                        .HasColumnName("parent_id");

                    b.HasKey("Id");

                    b.ToTable("navigator_categories");
                });
#pragma warning restore 612, 618
        }
    }
}
