using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebPOS.Migrations
{
    /// <inheritdoc />
    public partial class branchSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "Address", "ArabicTitle", "BranchSettings", "DispatcherAcceptRequired", "HasSeats", "Title" },
                values: new object[,]
                {
                    { 1, "6th of october", null, null, (byte)1, (byte)1, "Cirnckle1" },
                    { 2, "Faiyum", null, null, (byte)1, (byte)1, "Cirnckle2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
