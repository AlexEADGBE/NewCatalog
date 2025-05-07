using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewCatalog.Data.Migrations
{
    /// <inheritdoc />
    public partial class letter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_ParentCatagoryId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ParentCatagoryId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ParentCatagoryId",
                table: "Categories");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_ParentCategoryId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "ParentCatagoryId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCatagoryId",
                table: "Categories",
                column: "ParentCatagoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_ParentCatagoryId",
                table: "Categories",
                column: "ParentCatagoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
