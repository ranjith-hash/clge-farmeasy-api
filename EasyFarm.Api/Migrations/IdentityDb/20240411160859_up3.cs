using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyFarm.Api.Migrations.IdentityDb
{
    /// <inheritdoc />
    public partial class up3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblOrders_UserAccounts_UserId",
                table: "TblOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_TblProducts_UserAccounts_SellerUserId",
                table: "TblProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAccounts",
                table: "UserAccounts");

            migrationBuilder.RenameTable(
                name: "UserAccounts",
                newName: "TblUserAccounts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblUserAccounts",
                table: "TblUserAccounts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblOrders_TblUserAccounts_UserId",
                table: "TblOrders",
                column: "UserId",
                principalTable: "TblUserAccounts",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblProducts_TblUserAccounts_SellerUserId",
                table: "TblProducts",
                column: "SellerUserId",
                principalTable: "TblUserAccounts",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblOrders_TblUserAccounts_UserId",
                table: "TblOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_TblProducts_TblUserAccounts_SellerUserId",
                table: "TblProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblUserAccounts",
                table: "TblUserAccounts");

            migrationBuilder.RenameTable(
                name: "TblUserAccounts",
                newName: "UserAccounts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAccounts",
                table: "UserAccounts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblOrders_UserAccounts_UserId",
                table: "TblOrders",
                column: "UserId",
                principalTable: "UserAccounts",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblProducts_UserAccounts_SellerUserId",
                table: "TblProducts",
                column: "SellerUserId",
                principalTable: "UserAccounts",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
