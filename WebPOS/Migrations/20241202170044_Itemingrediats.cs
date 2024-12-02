using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebPOS.Migrations
{
    /// <inheritdoc />
    public partial class Itemingrediats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemIngrediants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    IngrediantId = table.Column<int>(type: "int", nullable: false),
                    Quentity = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemIngrediants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemIngrediants_ingrediants_IngrediantId",
                        column: x => x.IngrediantId,
                        principalTable: "ingrediants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemIngrediants_items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemIngrediants_IngrediantId",
                table: "ItemIngrediants",
                column: "IngrediantId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemIngrediants_ItemId",
                table: "ItemIngrediants",
                column: "ItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemIngrediants");
        }
    }
}
