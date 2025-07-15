using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductSaleApi.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OnSale = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    SaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.SaleId);
                    table.ForeignKey(
                        name: "FK_Sales_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "OnSale", "Picture", "Price", "ProductName", "Size" },
                values: new object[,]
                {
                    { 1, false, "1.jpg", 1064m, "Product1", 3 },
                    { 2, true, "2.jpg", 1727m, "Product2", 1 },
                    { 3, false, "3.jpg", 1304m, "Product3", 2 },
                    { 4, true, "4.jpg", 1160m, "Product4", 1 }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "SaleId", "Date", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 5, new DateTime(2019, 4, 13, 16, 41, 16, 568, DateTimeKind.Local).AddTicks(5200), 1, 111 },
                    { 1, new DateTime(2024, 3, 30, 16, 41, 16, 568, DateTimeKind.Local).AddTicks(5082), 1, 197 },
                    { 2, new DateTime(2022, 9, 30, 16, 41, 16, 568, DateTimeKind.Local).AddTicks(5146), 1, 132 },
                    { 3, new DateTime(2021, 12, 27, 16, 41, 16, 568, DateTimeKind.Local).AddTicks(5165), 1, 199 },
                    { 4, new DateTime(2020, 8, 1, 16, 41, 16, 568, DateTimeKind.Local).AddTicks(5182), 1, 173 },
                    { 6, new DateTime(2018, 5, 8, 16, 41, 16, 568, DateTimeKind.Local).AddTicks(5223), 1, 184 },
                    { 7, new DateTime(2016, 9, 3, 16, 41, 16, 568, DateTimeKind.Local).AddTicks(5242), 1, 156 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ProductId",
                table: "Sales",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
