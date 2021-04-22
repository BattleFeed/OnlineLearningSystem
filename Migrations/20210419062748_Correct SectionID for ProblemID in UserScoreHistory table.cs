using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineLearningSystem.Migrations
{
    public partial class CorrectSectionIDforProblemIDinUserScoreHistorytable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserScoreHistories_Problems_ProblemID",
                table: "UserScoreHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserScoreHistories",
                table: "UserScoreHistories");

            migrationBuilder.AlterColumn<int>(
                name: "ProblemID",
                table: "UserScoreHistories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SectionID",
                table: "UserScoreHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserScoreHistories",
                table: "UserScoreHistories",
                columns: new[] { "UserId", "SectionID" });

            migrationBuilder.CreateIndex(
                name: "IX_UserScoreHistories_SectionID",
                table: "UserScoreHistories",
                column: "SectionID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserScoreHistories_Problems_ProblemID",
                table: "UserScoreHistories",
                column: "ProblemID",
                principalTable: "Problems",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserScoreHistories_Sections_SectionID",
                table: "UserScoreHistories",
                column: "SectionID",
                principalTable: "Sections",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserScoreHistories_Problems_ProblemID",
                table: "UserScoreHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_UserScoreHistories_Sections_SectionID",
                table: "UserScoreHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserScoreHistories",
                table: "UserScoreHistories");

            migrationBuilder.DropIndex(
                name: "IX_UserScoreHistories_SectionID",
                table: "UserScoreHistories");

            migrationBuilder.DropColumn(
                name: "SectionID",
                table: "UserScoreHistories");

            migrationBuilder.AlterColumn<int>(
                name: "ProblemID",
                table: "UserScoreHistories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserScoreHistories",
                table: "UserScoreHistories",
                columns: new[] { "UserId", "ProblemID" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserScoreHistories_Problems_ProblemID",
                table: "UserScoreHistories",
                column: "ProblemID",
                principalTable: "Problems",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
