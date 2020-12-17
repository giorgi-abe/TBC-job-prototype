using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationDomainEntity.Migrations
{
    public partial class databasemodelsupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CityTb",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "CityTb");
        }
    }
}
