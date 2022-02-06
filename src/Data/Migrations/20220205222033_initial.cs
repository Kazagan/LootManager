﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InGold = table.Column<double>(type: "float(4)", precision: 4, scale: 4, nullable: false),
                    CoinTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GoodTypeRoller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TreasureLevel = table.Column<int>(type: "int", nullable: false),
                    RollMin = table.Column<int>(type: "int", nullable: false),
                    GoodTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodTypeRoller", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoinRoller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TreasureLevel = table.Column<int>(type: "int", nullable: false),
                    RollMin = table.Column<int>(type: "int", nullable: false),
                    CoinId = table.Column<int>(type: "int", nullable: true),
                    DiceCount = table.Column<int>(type: "int", nullable: false),
                    DiceSides = table.Column<int>(type: "int", nullable: false),
                    Multiplier = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoinRoller", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoinRoller_Coin_CoinId",
                        column: x => x.CoinId,
                        principalTable: "Coin",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CoinType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoinType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoinType_Coin_Id",
                        column: x => x.Id,
                        principalTable: "Coin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Good",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ValueId = table.Column<int>(type: "int", nullable: false),
                    GoodTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Good", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Good_Coin_ValueId",
                        column: x => x.ValueId,
                        principalTable: "Coin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GoodRoller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RollMin = table.Column<int>(type: "int", nullable: false),
                    DiceCount = table.Column<int>(type: "int", nullable: false),
                    DiceSides = table.Column<int>(type: "int", nullable: false),
                    Multiplier = table.Column<int>(type: "int", nullable: false),
                    GoodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodRoller", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoodRoller_Good_GoodId",
                        column: x => x.GoodId,
                        principalTable: "Good",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GoodType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoodType_Good_Id",
                        column: x => x.Id,
                        principalTable: "Good",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GoodType_GoodTypeRoller_Id",
                        column: x => x.Id,
                        principalTable: "GoodTypeRoller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoinRoller_CoinId",
                table: "CoinRoller",
                column: "CoinId");

            migrationBuilder.CreateIndex(
                name: "IX_Good_ValueId",
                table: "Good",
                column: "ValueId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodRoller_GoodId",
                table: "GoodRoller",
                column: "GoodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoinRoller");

            migrationBuilder.DropTable(
                name: "CoinType");

            migrationBuilder.DropTable(
                name: "GoodRoller");

            migrationBuilder.DropTable(
                name: "GoodType");

            migrationBuilder.DropTable(
                name: "Good");

            migrationBuilder.DropTable(
                name: "GoodTypeRoller");

            migrationBuilder.DropTable(
                name: "Coin");
        }
    }
}