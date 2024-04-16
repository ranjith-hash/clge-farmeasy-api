using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyFarm.Api.Migrations.IdentityDb
{
    /// <inheritdoc />
    public partial class q1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblOrders_TblUserAccounts_SellerUserId",
                table: "TblOrders");

            migrationBuilder.DropIndex(
                name: "IX_TblOrders_SellerUserId",
                table: "TblOrders");

            migrationBuilder.DropColumn(
                name: "SellerUserId",
                table: "TblOrders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
