using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineLearningSystem.Migrations
{
    public partial class AddedNamepropertytosection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Sections",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Sections");
        }
    }
}
