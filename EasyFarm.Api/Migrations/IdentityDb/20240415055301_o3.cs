using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyFarm.Api.Migrations.IdentityDb
{
    /// <inheritdoc />
    public partial class o3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "TblOrders",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "SellerUserId",
                table: "TblOrders",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblOrders_SellerUserId",
                table: "TblOrders",
                column: "SellerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblOrders_TblUserAccounts_SellerUserId",
                table: "TblOrders",
                column: "SellerUserId",
                principalTable: "TblUserAccounts",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblOrders_TblUserAccounts_SellerUserId",
                table: "TblOrders");

            migrationBuilder.DropIndex(
                name: "IX_TblOrders_SellerUserId",
                table: "TblOrders");

            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "TblOrders");

            migrationBuilder.DropColumn(
                name: "SellerUserId",
                table: "TblOrders");
        }
    }
}
