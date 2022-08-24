using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetupAPI.Data.Migrations
{
    public partial class CorrectHouse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Hous",
                table: "Addresses",
                newName: "House");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "House",
                table: "Addresses",
                newName: "Hous");
        }
    }
}
