using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class migs1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    BlogID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlogContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlogThumbnailImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlogImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlogCreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BlogStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.BlogID);
                });

            migrationBuilder.CreateTable(
                name: "Personels",
                columns: table => new
                {
                    PersonelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonelDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonelSektor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonelMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonelPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonelAdress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personels", x => x.PersonelID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Personels");
        }
    }
}
