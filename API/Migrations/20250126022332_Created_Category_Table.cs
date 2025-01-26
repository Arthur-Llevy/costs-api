using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace costs_backend.Migrations
{
    /// <inheritdoc />
    public partial class Created_Category_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category_Name",
                table: "Projects");

            migrationBuilder.AddColumn<int>(
                name: "Category_Id",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProjectsCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectsCategory", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_Category_Id",
                table: "Projects",
                column: "Category_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ProjectsCategory_Category_Id",
                table: "Projects",
                column: "Category_Id",
                principalTable: "ProjectsCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ProjectsCategory_Category_Id",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "ProjectsCategory");

            migrationBuilder.DropIndex(
                name: "IX_Projects_Category_Id",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Category_Id",
                table: "Projects");

            migrationBuilder.AddColumn<string>(
                name: "Category_Name",
                table: "Projects",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
