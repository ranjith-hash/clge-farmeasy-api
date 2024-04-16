using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyFarm.Api.Migrations.IdentityDb
{
    /// <inheritdoc />
    public partial class o9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblOrders_TblUserAccounts_UserId",
                table: "TblOrders");

            migrationBuilder.DropIndex(
                name: "IX_TblOrders_UserId",
                table: "TblOrders");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TblOrders");

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "TblOrders",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User",
                table: "TblOrders");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "TblOrders",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblOrders_UserId",
                table: "TblOrders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblOrders_TblUserAccounts_UserId",
                table: "TblOrders",
                column: "UserId",
                principalTable: "TblUserAccounts",
                principalColumn: "UserId");
        }
    }
}
