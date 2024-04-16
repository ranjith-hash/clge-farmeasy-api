using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyFarm.Api.Migrations.IdentityDb
{
    /// <inheritdoc />
    public partial class update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblOrders_TblUserAccounts_UserId",
                table: "TblOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_TblProbSubCategory_TblProdCategories_CategoryId",
                table: "TblProbSubCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_TblProducts_TblProbSubCategory_ProbSubCategoryId",
                table: "TblProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_TblProducts_TblUserAccounts_SellerUserId",
                table: "TblProducts");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "TblUserAccounts",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "TblUserAccounts",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "TblUserAccounts",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "TblUserAccounts",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "SellerUserId",
                table: "TblProducts",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "TblProducts",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "ProbSubCategoryId",
                table: "TblProducts",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "TblProdCategories",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ProdSubCategory",
                table: "TblProbSubCategory",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "TblProbSubCategory",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "TblOrders",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "TblOrders",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_TblOrders_TblUserAccounts_UserId",
                table: "TblOrders",
                column: "UserId",
                principalTable: "TblUserAccounts",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblProbSubCategory_TblProdCategories_CategoryId",
                table: "TblProbSubCategory",
                column: "CategoryId",
                principalTable: "TblProdCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TblProducts_TblProbSubCategory_ProbSubCategoryId",
                table: "TblProducts",
                column: "ProbSubCategoryId",
                principalTable: "TblProbSubCategory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TblProducts_TblUserAccounts_SellerUserId",
                table: "TblProducts",
                column: "SellerUserId",
                principalTable: "TblUserAccounts",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblOrders_TblUserAccounts_UserId",
                table: "TblOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_TblProbSubCategory_TblProdCategories_CategoryId",
                table: "TblProbSubCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_TblProducts_TblProbSubCategory_ProbSubCategoryId",
                table: "TblProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_TblProducts_TblUserAccounts_SellerUserId",
                table: "TblProducts");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "TblUserAccounts",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "TblUserAccounts",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "TblUserAccounts",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "TblUserAccounts",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "SellerUserId",
                table: "TblProducts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "TblProducts",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProbSubCategoryId",
                table: "TblProducts",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "TblProdCategories",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProdSubCategory",
                table: "TblProbSubCategory",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "TblProbSubCategory",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "TblOrders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "TblOrders",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TblOrders_TblUserAccounts_UserId",
                table: "TblOrders",
                column: "UserId",
                principalTable: "TblUserAccounts",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblProbSubCategory_TblProdCategories_CategoryId",
                table: "TblProbSubCategory",
                column: "CategoryId",
                principalTable: "TblProdCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblProducts_TblProbSubCategory_ProbSubCategoryId",
                table: "TblProducts",
                column: "ProbSubCategoryId",
                principalTable: "TblProbSubCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblProducts_TblUserAccounts_SellerUserId",
                table: "TblProducts",
                column: "SellerUserId",
                principalTable: "TblUserAccounts",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
