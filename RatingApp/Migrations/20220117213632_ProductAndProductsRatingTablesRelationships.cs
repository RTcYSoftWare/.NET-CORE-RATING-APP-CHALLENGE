using Microsoft.EntityFrameworkCore.Migrations;

namespace RatingApp.Migrations
{
    public partial class ProductAndProductsRatingTablesRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ProductsRatings_ProductId",
                table: "ProductsRatings",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsRatings_UserId",
                table: "ProductsRatings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsRatings_Products_ProductId",
                table: "ProductsRatings",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsRatings_Users_UserId",
                table: "ProductsRatings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsRatings_Products_ProductId",
                table: "ProductsRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsRatings_Users_UserId",
                table: "ProductsRatings");

            migrationBuilder.DropIndex(
                name: "IX_ProductsRatings_ProductId",
                table: "ProductsRatings");

            migrationBuilder.DropIndex(
                name: "IX_ProductsRatings_UserId",
                table: "ProductsRatings");
        }
    }
}
