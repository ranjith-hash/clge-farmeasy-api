using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EasyFarm.Api.Migrations.IdentityDb
{
    /// <inheritdoc />
    public partial class w : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "TblProducts",
                newName: "OfferPricePrice");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "TblOrders",
                newName: "Category");

            migrationBuilder.AddColumn<double>(
                name: "ActualPrice",
                table: "TblProducts",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "TblOrders",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductsProductId",
                table: "TblOrders",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TblCart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserAccountsUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    ProductsProductId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblCart_TblProducts_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "TblProducts",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK_TblCart_TblUserAccounts_UserAccountsUserId",
                        column: x => x.UserAccountsUserId,
                        principalTable: "TblUserAccounts",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblOrders_ProductsProductId",
                table: "TblOrders",
                column: "ProductsProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TblCart_ProductsProductId",
                table: "TblCart",
                column: "ProductsProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TblCart_UserAccountsUserId",
                table: "TblCart",
                column: "UserAccountsUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblOrders_TblProducts_ProductsProductId",
                table: "TblOrders",
                column: "ProductsProductId",
                principalTable: "TblProducts",
                principalColumn: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblOrders_TblProducts_ProductsProductId",
                table: "TblOrders");

            migrationBuilder.DropTable(
                name: "TblCart");

            migrationBuilder.DropIndex(
                name: "IX_TblOrders_ProductsProductId",
                table: "TblOrders");

            migrationBuilder.DropColumn(
                name: "ActualPrice",
                table: "TblProducts");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "TblOrders");

            migrationBuilder.DropColumn(
                name: "ProductsProductId",
                table: "TblOrders");

            migrationBuilder.RenameColumn(
                name: "OfferPricePrice",
                table: "TblProducts",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "TblOrders",
                newName: "Type");
        }
    }
}
