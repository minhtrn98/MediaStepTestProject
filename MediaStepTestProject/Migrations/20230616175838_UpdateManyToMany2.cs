using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediaStepTestProject.Migrations
{
    /// <inheritdoc />
    public partial class UpdateManyToMany2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerProduct_Customers_CustomerId",
                table: "CustomerProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerProduct_Products_ProductId",
                table: "CustomerProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerProduct",
                table: "CustomerProduct");

            migrationBuilder.RenameTable(
                name: "CustomerProduct",
                newName: "CustomerProducts");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerProduct_ProductId",
                table: "CustomerProducts",
                newName: "IX_CustomerProducts_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerProducts",
                table: "CustomerProducts",
                columns: new[] { "CustomerId", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerProducts_Customers_CustomerId",
                table: "CustomerProducts",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerProducts_Products_ProductId",
                table: "CustomerProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerProducts_Customers_CustomerId",
                table: "CustomerProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerProducts_Products_ProductId",
                table: "CustomerProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerProducts",
                table: "CustomerProducts");

            migrationBuilder.RenameTable(
                name: "CustomerProducts",
                newName: "CustomerProduct");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerProducts_ProductId",
                table: "CustomerProduct",
                newName: "IX_CustomerProduct_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerProduct",
                table: "CustomerProduct",
                columns: new[] { "CustomerId", "ProductId" });

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
    }
}
