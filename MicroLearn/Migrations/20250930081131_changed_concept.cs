using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroLearn.Migrations
{
    /// <inheritdoc />
    public partial class changed_concept : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "Concepts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Recap",
                table: "Concepts",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Details",
                table: "Concepts");

            migrationBuilder.DropColumn(
                name: "Recap",
                table: "Concepts");
        }
    }
}
