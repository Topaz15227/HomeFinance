using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeFinance.Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CardName = table.Column<string>(maxLength: 15, nullable: false),
                    CardDescription = table.Column<string>(maxLength: 25, nullable: false),
                    CardNumber = table.Column<string>(maxLength: 20, nullable: false),
                    ClosingName = table.Column<string>(maxLength: 3, nullable: false),
                    Active = table.Column<bool>(nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StoreName = table.Column<string>(maxLength: 30, nullable: false),
                    Active = table.Column<bool>(nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Closings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClosingDate = table.Column<DateTime>(type: "date", nullable: false),
                    CardId = table.Column<int>(nullable: false),
                    ClosingName = table.Column<string>(maxLength: 15, nullable: false),
                    ClosingAmount = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Closings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Closings_Cards",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StorePays",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PayDate = table.Column<DateTime>(type: "date", nullable: false),
                    CardId = table.Column<int>(nullable: false),
                    StoreId = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0))"),
                    Note = table.Column<string>(maxLength: 45, nullable: true),
                    ClosingId = table.Column<int>(nullable: true),
                    Active = table.Column<bool>(nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorePays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StorePays_Cards",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StorePays_Closings",
                        column: x => x.ClosingId,
                        principalTable: "Closings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StorePays_Stores",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });


            migrationBuilder.CreateIndex(
                name: "IX_Closings_CardId",
                table: "Closings",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_StorePays_CardId",
                table: "StorePays",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_StorePays_ClosingId",
                table: "StorePays",
                column: "ClosingId");

            migrationBuilder.CreateIndex(
                name: "IX_StorePays_StoreId",
                table: "StorePays",
                column: "StoreId");
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StorePays");

            migrationBuilder.DropTable(
                name: "Closings");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "Cards");
        }
    }
}
