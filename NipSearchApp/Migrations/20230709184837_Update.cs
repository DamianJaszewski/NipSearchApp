using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NipSearchApp.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntityPerson_Subject_subjectId",
                table: "EntityPerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EntityPerson",
                table: "EntityPerson");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "EntityPerson");

            migrationBuilder.RenameTable(
                name: "EntityPerson",
                newName: "Representatives");

            migrationBuilder.RenameIndex(
                name: "IX_EntityPerson_subjectId",
                table: "Representatives",
                newName: "IX_Representatives_subjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Representatives",
                table: "Representatives",
                column: "id");

            migrationBuilder.CreateTable(
                name: "AuthorizedClerks",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    companyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pesel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    subjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorizedClerks", x => x.id);
                    table.ForeignKey(
                        name: "FK_AuthorizedClerks_Subject_subjectId",
                        column: x => x.subjectId,
                        principalTable: "Subject",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Partners",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    companyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pesel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    subjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partners", x => x.id);
                    table.ForeignKey(
                        name: "FK_Partners_Subject_subjectId",
                        column: x => x.subjectId,
                        principalTable: "Subject",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorizedClerks_subjectId",
                table: "AuthorizedClerks",
                column: "subjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Partners_subjectId",
                table: "Partners",
                column: "subjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Representatives_Subject_subjectId",
                table: "Representatives",
                column: "subjectId",
                principalTable: "Subject",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Representatives_Subject_subjectId",
                table: "Representatives");

            migrationBuilder.DropTable(
                name: "AuthorizedClerks");

            migrationBuilder.DropTable(
                name: "Partners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Representatives",
                table: "Representatives");

            migrationBuilder.RenameTable(
                name: "Representatives",
                newName: "EntityPerson");

            migrationBuilder.RenameIndex(
                name: "IX_Representatives_subjectId",
                table: "EntityPerson",
                newName: "IX_EntityPerson_subjectId");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "EntityPerson",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EntityPerson",
                table: "EntityPerson",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_EntityPerson_Subject_subjectId",
                table: "EntityPerson",
                column: "subjectId",
                principalTable: "Subject",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
