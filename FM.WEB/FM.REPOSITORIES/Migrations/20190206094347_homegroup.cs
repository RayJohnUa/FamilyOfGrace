using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FM.REPOSITORIES.Migrations
{
    public partial class homegroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupSessionId",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HomeGroupId",
                table: "Persons",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GroupSessions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDelete = table.Column<bool>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupSessions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomeGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeGroups", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_GroupSessionId",
                table: "Persons",
                column: "GroupSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_HomeGroupId",
                table: "Persons",
                column: "HomeGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_GroupSessions_GroupSessionId",
                table: "Persons",
                column: "GroupSessionId",
                principalTable: "GroupSessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Persons_GroupSessions_GroupSessionId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_HomeGroups_HomeGroupId",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "GroupSessions");

            migrationBuilder.DropTable(
                name: "HomeGroups");

            migrationBuilder.DropIndex(
                name: "IX_Persons_GroupSessionId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_HomeGroupId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "GroupSessionId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "HomeGroupId",
                table: "Persons");
        }
    }
}
