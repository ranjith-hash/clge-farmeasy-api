using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EasyFarm.Api.Migrations.IdentityDb
{
    /// <inheritdoc />
    public partial class _3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblProducts_TblProbSubCategory_ProbSubCategoryId",
                table: "TblProducts");

            migrationBuilder.DropTable(
                name: "TblProbSubCategory");

            migrationBuilder.RenameColumn(
                name: "ProbSubCategoryId",
                table: "TblProducts",
                newName: "ProdCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_TblProducts_ProbSubCategoryId",
                table: "TblProducts",
                newName: "IX_TblProducts_ProdCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblProducts_TblProdCategories_ProdCategoryId",
                table: "TblProducts",
                column: "ProdCategoryId",
                principalTable: "TblProdCategories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblProducts_TblProdCategories_ProdCategoryId",
                table: "TblProducts");

            migrationBuilder.RenameColumn(
                name: "ProdCategoryId",
                table: "TblProducts",
                newName: "ProbSubCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_TblProducts_ProdCategoryId",
                table: "TblProducts",
                newName: "IX_TblProducts_ProbSubCategoryId");

            migrationBuilder.CreateTable(
                name: "TblProbSubCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryId = table.Column<int>(type: "integer", nullable: true),
                    ProdSubCategory = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblProbSubCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblProbSubCategory_TblProdCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "TblProdCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblProbSubCategory_CategoryId",
                table: "TblProbSubCategory",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblProducts_TblProbSubCategory_ProbSubCategoryId",
                table: "TblProducts",
                column: "ProbSubCategoryId",
                principalTable: "TblProbSubCategory",
                principalColumn: "Id");
        }
    }
}
