using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NipSearchApp.Migrations
{
    /// <inheritdoc />
    public partial class CreateInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    statusVat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    regon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pesel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    krs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    residenceAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    workingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    registrationLegalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    registrationDenialDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    registrationDenialBasis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    restorationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    restorationBasis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    removalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    removalBasis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hasVirtualAccounts = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AccountNumbers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    subjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountNumbers", x => x.id);
                    table.ForeignKey(
                        name: "FK_AccountNumbers_Subject_subjectId",
                        column: x => x.subjectId,
                        principalTable: "Subject",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntityPerson",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    companyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pesel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    subjectId = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityPerson", x => x.id);
                    table.ForeignKey(
                        name: "FK_EntityPerson_Subject_subjectId",
                        column: x => x.subjectId,
                        principalTable: "Subject",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountNumbers_subjectId",
                table: "AccountNumbers",
                column: "subjectId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityPerson_subjectId",
                table: "EntityPerson",
                column: "subjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountNumbers");

            migrationBuilder.DropTable(
                name: "EntityPerson");

            migrationBuilder.DropTable(
                name: "Subject");
        }
    }
}
