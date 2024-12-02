using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebPOS.Migrations
{
    /// <inheritdoc />
    public partial class shifts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "shifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Shift = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ShiftID = table.Column<string>(type: "nvarchar(max)", nullable: false, computedColumnSql: "CONCAT(SUBSTRING(CAST(YEAR(CreatedAt) AS CHAR(10)), 3, 2), SUBSTRING(CAST(MONTH(CreatedAt) AS CHAR(2)), 1, 2), SUBSTRING(CAST(DAY(CreatedAt) AS CHAR(2)), 1, 2), Location, User)"),
                    Status = table.Column<string>(type: "varchar(50)", nullable: false),
                    ClosingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Location = table.Column<int>(type: "int", nullable: true),
                    CreatorsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shifts", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "shifts");
        }
    }
}
