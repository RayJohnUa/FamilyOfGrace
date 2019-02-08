using Microsoft.EntityFrameworkCore.Migrations;

namespace FM.REPOSITORIES.Migrations
{
    public partial class homegroupfinal11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HomeGroupId",
                table: "GroupSessions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GroupSessions_HomeGroupId",
                table: "GroupSessions",
                column: "HomeGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupSessions_HomeGroups_HomeGroupId",
                table: "GroupSessions",
                column: "HomeGroupId",
                principalTable: "HomeGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupSessions_HomeGroups_HomeGroupId",
                table: "GroupSessions");

            migrationBuilder.DropIndex(
                name: "IX_GroupSessions_HomeGroupId",
                table: "GroupSessions");

            migrationBuilder.DropColumn(
                name: "HomeGroupId",
                table: "GroupSessions");
        }
    }
}
