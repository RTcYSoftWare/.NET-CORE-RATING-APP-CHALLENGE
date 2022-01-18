using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RatingApp.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(100)", nullable: false),
                    Text = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    ListImage = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    BannerImage = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    BlogCategoryId = table.Column<int>(type: "int", nullable: false),
                    Hit = table.Column<int>(type: "int", nullable: false),
                    Slug = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blogs");
        }
    }
}
