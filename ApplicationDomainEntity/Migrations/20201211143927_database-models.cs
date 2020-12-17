using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationDomainEntity.Migrations
{
    public partial class databasemodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CityTb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityTb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonTb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    IdentityNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonTb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConnectedPersonTb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConnectedPersonTb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConnectedPersonTb_PersonTb_PersonId",
                        column: x => x.PersonId,
                        principalTable: "PersonTb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumberTb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumberTb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneNumberTb_PersonTb_PersonId",
                        column: x => x.PersonId,
                        principalTable: "PersonTb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConnectedPersonTb_PersonId",
                table: "ConnectedPersonTb",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumberTb_PersonId",
                table: "PhoneNumberTb",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CityTb");

            migrationBuilder.DropTable(
                name: "ConnectedPersonTb");

            migrationBuilder.DropTable(
                name: "PhoneNumberTb");

            migrationBuilder.DropTable(
                name: "PersonTb");
        }
    }
}
