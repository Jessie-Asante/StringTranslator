using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StringConverter.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblConvertStrings",
                columns: table => new
                {
                    UserIDpk = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataField = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblConvertStrings", x => x.UserIDpk);
                });

            migrationBuilder.CreateTable(
                name: "TblFetchStringDtos",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataField = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblConvertStrings");

            migrationBuilder.DropTable(
                name: "TblFetchStringDtos");
        }
    }
}
