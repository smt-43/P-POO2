using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PPOO2.Migrations
{
    /// <inheritdoc />
    public partial class Post1_1_Create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items1");

            migrationBuilder.CreateTable(
                name: "Record_1",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    artist = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    release_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    uploader = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    upload_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    imagePath1 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    imagePath2 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    imagePath3 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    approbation = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Record_1", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Record_1");

            migrationBuilder.CreateTable(
                name: "Items1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    n1 = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items1", x => x.Id);
                });
        }
    }
}
