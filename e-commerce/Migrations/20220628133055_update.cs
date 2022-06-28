using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_commerce.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Sellers_SellerID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Sellers_Products_ProductID",
                table: "Sellers");

            migrationBuilder.DropIndex(
                name: "IX_Sellers_ProductID",
                table: "Sellers");

            migrationBuilder.DropIndex(
                name: "IX_Products_SellerID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "SellerID",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "Sellers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SellerID",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sellers_ProductID",
                table: "Sellers",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SellerID",
                table: "Products",
                column: "SellerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Sellers_SellerID",
                table: "Products",
                column: "SellerID",
                principalTable: "Sellers",
                principalColumn: "SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sellers_Products_ProductID",
                table: "Sellers",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID");
        }
    }
}
