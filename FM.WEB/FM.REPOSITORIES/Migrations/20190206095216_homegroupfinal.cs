using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FM.REPOSITORIES.Migrations
{
    public partial class homegroupfinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_GroupSessions_GroupSessionId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_HomeGroups_HomeGroupId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_GroupSessionId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "GroupSessionId",
                table: "Persons");

            migrationBuilder.AlterColumn<int>(
                name: "HomeGroupId",
                table: "Persons",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "GroupSesionPerson",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDelete = table.Column<bool>(nullable: false),
                    PersonId = table.Column<int>(nullable: false),
                    GroupSessionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupSesionPerson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupSesionPerson_GroupSessions_GroupSessionId",
                        column: x => x.GroupSessionId,
                        principalTable: "GroupSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupSesionPerson_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupSesionPerson_GroupSessionId",
                table: "GroupSesionPerson",
                column: "GroupSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupSesionPerson_PersonId",
                table: "GroupSesionPerson",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_HomeGroups_HomeGroupId",
                table: "Persons",
                column: "HomeGroupId",
                principalTable: "HomeGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_HomeGroups_HomeGroupId",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "GroupSesionPerson");

            migrationBuilder.AlterColumn<int>(
                name: "HomeGroupId",
                table: "Persons",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "GroupSessionId",
                table: "Persons",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_GroupSessionId",
                table: "Persons",
                column: "GroupSessionId");

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
    }
}
