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

            modelBuilder.Entity("Data.Entities.Coin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal?>("InGold")
                        .IsRequired()
                        .HasPrecision(10, 4)
                        .HasColumnType("decimal(10,4)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Coin");
                });

            modelBuilder.Entity("Data.Entities.CoinRoller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CoinId")
                        .HasColumnType("int");

                    b.Property<int?>("DiceCount")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("DiceSides")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("Multiplier")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("RollMin")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("TreasureLevel")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CoinId");

                    b.HasIndex("TreasureLevel", "RollMin");

                    b.ToTable("CoinRoller");
                });

            modelBuilder.Entity("Data.Entities.Good", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("GoodTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("ValueId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GoodTypeId");

                    b.HasIndex("ValueId");

                    b.ToTable("Good");
                });

            modelBuilder.Entity("Data.Entities.GoodRoller", b =>
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

                    b.Property<int>("RollMin")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GoodId");

                    b.ToTable("GoodRoller");
                });

            modelBuilder.Entity("Data.Entities.GoodType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("GoodType");
                });

            modelBuilder.Entity("Data.Entities.GoodTypeRoller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("GoodTypeId")
                        .HasColumnType("int");

                    b.Property<int>("RollMin")
                        .HasColumnType("int");

                    b.Property<int>("TreasureLevel")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GoodTypeId");

                    b.ToTable("GoodTypeRoller");
                });

            modelBuilder.Entity("Data.Entities.CoinRoller", b =>
                {
                    b.HasOne("Data.Entities.Coin", "Coin")
                        .WithMany()
                        .HasForeignKey("CoinId");

                    b.Navigation("Coin");
                });

            modelBuilder.Entity("Data.Entities.Good", b =>
                {
                    b.HasOne("Data.Entities.GoodType", "GoodType")
                        .WithMany()
                        .HasForeignKey("GoodTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.Coin", "Value")
                        .WithMany()
                        .HasForeignKey("ValueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GoodType");

                    b.Navigation("Value");
                });

            modelBuilder.Entity("Data.Entities.GoodRoller", b =>
                {
                    b.HasOne("Data.Entities.Good", "Good")
                        .WithMany()
                        .HasForeignKey("GoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Good");
                });

            modelBuilder.Entity("Data.Entities.GoodTypeRoller", b =>
                {
                    b.HasOne("Data.Entities.GoodType", "GoodType")
                        .WithMany()
                        .HasForeignKey("GoodTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GoodType");
                });
#pragma warning restore 612, 618
        }
    }
}
