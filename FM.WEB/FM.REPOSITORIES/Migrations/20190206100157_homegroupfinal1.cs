using Microsoft.EntityFrameworkCore.Migrations;

namespace FM.REPOSITORIES.Migrations
{
    public partial class homegroupfinal1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_HomeGroups_HomeGroupId",
                table: "Persons");

            migrationBuilder.AlterColumn<int>(
                name: "HomeGroupId",
                table: "Persons",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_HomeGroups_HomeGroupId",
                table: "Persons",
                column: "HomeGroupId",
                principalTable: "HomeGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_HomeGroups_HomeGroupId",
                table: "Persons");

            migrationBuilder.AlterColumn<int>(
                name: "HomeGroupId",
                table: "Persons",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_HomeGroups_HomeGroupId",
                table: "Persons",
                column: "HomeGroupId",
                principalTable: "HomeGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
