using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediaStepTestProject.Migrations
{
    /// <inheritdoc />
    public partial class UpdateManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerProduct_Customers_CustomersId",
                table: "CustomerProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerProduct_Products_ProductsId",
                table: "CustomerProduct");

            migrationBuilder.RenameColumn(
                name: "ProductsId",
                table: "CustomerProduct",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "CustomersId",
                table: "CustomerProduct",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerProduct_ProductsId",
                table: "CustomerProduct",
                newName: "IX_CustomerProduct_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerProduct_Customers_CustomerId",
                table: "CustomerProduct",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerProduct_Products_ProductId",
                table: "CustomerProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerProduct_Customers_CustomerId",
                table: "CustomerProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerProduct_Products_ProductId",
                table: "CustomerProduct");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "CustomerProduct",
                newName: "ProductsId");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "CustomerProduct",
                newName: "CustomersId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerProduct_ProductId",
                table: "CustomerProduct",
                newName: "IX_CustomerProduct_ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerProduct_Customers_CustomersId",
                table: "CustomerProduct",
                column: "CustomersId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerProduct_Products_ProductsId",
                table: "CustomerProduct",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
