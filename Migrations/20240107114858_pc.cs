using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Softst.Migrations
{
    /// <inheritdoc />
    public partial class pc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "profileUrl",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "profileUrl",
                table: "Students");
        }
    }
}
