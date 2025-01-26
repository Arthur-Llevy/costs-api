using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace costs_backend.Migrations
{
    /// <inheritdoc />
    public partial class Changed_Category_Type : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Projects");

            migrationBuilder.AddColumn<string>(
                name: "Category_Name",
                table: "Projects",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category_Name",
                table: "Projects");

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
