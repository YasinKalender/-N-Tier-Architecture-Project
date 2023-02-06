using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NTierArchitecture.DAL.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductFeatureId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductFeature",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdcutDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFeature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductFeature_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CategoryName", "CreatedDate", "Status", "UpdateDate" },
                values: new object[,]
                {
                    { 1, "Category", new DateTime(2022, 11, 30, 13, 44, 12, 243, DateTimeKind.Local).AddTicks(9083), 0, null },
                    { 2, "Category2", new DateTime(2022, 11, 30, 13, 44, 12, 243, DateTimeKind.Local).AddTicks(9091), 0, null }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Price", "ProductFeatureId", "ProductName", "Status", "Stock", "UpdateDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 11, 30, 13, 44, 12, 243, DateTimeKind.Local).AddTicks(9219), 1000m, 0, "Product1", 0, 100, null },
                    { 2, 1, new DateTime(2022, 11, 30, 13, 44, 12, 243, DateTimeKind.Local).AddTicks(9221), 1000m, 0, "Product2", 0, 100, null },
                    { 3, 1, new DateTime(2022, 11, 30, 13, 44, 12, 243, DateTimeKind.Local).AddTicks(9222), 1000m, 0, "Product3", 0, 100, null },
                    { 4, 1, new DateTime(2022, 11, 30, 13, 44, 12, 243, DateTimeKind.Local).AddTicks(9223), 1000m, 0, "Product4", 0, 100, null },
                    { 5, 2, new DateTime(2022, 11, 30, 13, 44, 12, 243, DateTimeKind.Local).AddTicks(9224), 1000m, 0, "Product5", 0, 100, null },
                    { 6, 2, new DateTime(2022, 11, 30, 13, 44, 12, 243, DateTimeKind.Local).AddTicks(9225), 1000m, 0, "Product6", 0, 100, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFeature_ProductId",
                table: "ProductFeature",
                column: "ProductId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductFeature");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
