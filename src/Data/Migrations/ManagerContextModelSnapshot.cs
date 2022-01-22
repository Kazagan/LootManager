﻿// <auto-generated />
using System;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(ManagerContext))]
    partial class ManagerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Data.Models.Coin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CoinType")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<double>("InGold")
                        .HasPrecision(4, 4)
                        .HasColumnType("float(4)");

                    b.HasKey("Id");

                    b.ToTable("Coin");
                });

            modelBuilder.Entity("Data.Models.CoinRoller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CoinId")
                        .HasColumnType("int");

                    b.Property<int>("DiceCount")
                        .HasColumnType("int");

                    b.Property<int>("DiceSides")
                        .HasColumnType("int");

                    b.Property<int>("Multiplier")
                        .HasColumnType("int");

                    b.Property<int>("RollMax")
                        .HasColumnType("int");

                    b.Property<int>("RollMin")
                        .HasColumnType("int");

                    b.Property<int>("TreasureLevel")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CoinId");

                    b.ToTable("CoinRoller");
                });

            modelBuilder.Entity("Data.Models.Good", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<int>("ValueId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ValueId");

                    b.ToTable("Good");
                });

            modelBuilder.Entity("Data.Models.GoodRoller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DiceCount")
                        .HasColumnType("int");

                    b.Property<int>("DiceSides")
                        .HasColumnType("int");

                    b.Property<int>("GoodId")
                        .HasColumnType("int");

                    b.Property<int>("Multiplier")
                        .HasColumnType("int");

                    b.Property<int>("RollMax")
                        .HasColumnType("int");

                    b.Property<int>("RollMin")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GoodId");

                    b.ToTable("GoodRoller");
                });

            modelBuilder.Entity("Data.Models.GoodTypeRoller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("RollMax")
                        .HasColumnType("int");

                    b.Property<int>("RollMin")
                        .HasColumnType("int");

                    b.Property<int>("TreasureLevel")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.HasKey("Id");

                    b.ToTable("GoodTypeRoller");
                });

            modelBuilder.Entity("Data.Models.CoinRoller", b =>
                {
                    b.HasOne("Data.Models.Coin", "Coin")
                        .WithMany()
                        .HasForeignKey("CoinId");

                    b.Navigation("Coin");
                });

            modelBuilder.Entity("Data.Models.Good", b =>
                {
                    b.HasOne("Data.Models.Coin", "Value")
                        .WithMany()
                        .HasForeignKey("ValueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Value");
                });

            modelBuilder.Entity("Data.Models.GoodRoller", b =>
                {
                    b.HasOne("Data.Models.Good", "Good")
                        .WithMany()
                        .HasForeignKey("GoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Good");
                });
#pragma warning restore 612, 618
        }
    }
}
