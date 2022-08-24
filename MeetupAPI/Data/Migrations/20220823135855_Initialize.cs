using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetupAPI.Data.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meetups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hous = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Meetups_Id",
                        column: x => x.Id,
                        principalTable: "Meetups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Organizers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Organization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeetupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organizers_Meetups_MeetupId",
                        column: x => x.MeetupId,
                        principalTable: "Meetups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeetupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plans_Meetups_MeetupId",
                        column: x => x.MeetupId,
                        principalTable: "Meetups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Speakers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeetupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speakers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Speakers_Meetups_MeetupId",
                        column: x => x.MeetupId,
                        principalTable: "Meetups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Meetups",
                columns: new[] { "Id", "DateTime", "Description", "Title", "Topic" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Описание первого мероприятия", "Первое мероприятие", "Тема первого мероприятия" });

            migrationBuilder.InsertData(
                table: "Meetups",
                columns: new[] { "Id", "DateTime", "Description", "Title", "Topic" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Описание второго мероприятия", "Второе мероприятие", "Тема второго мероприятия" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Hous", "Street" },
                values: new object[,]
                {
                    { 1, "Первый", 11, "Первая" },
                    { 2, "Второй", 22, "Вторая" }
                });

            migrationBuilder.InsertData(
                table: "Organizers",
                columns: new[] { "Id", "FirstName", "LastName", "MeetupId", "Organization" },
                values: new object[,]
                {
                    { 1, "Первый", "First", 1, "Первая" },
                    { 2, "Второй", "Second", 1, "Вторая" },
                    { 3, "Третий", "Third", 2, "Третья" },
                    { 4, "Четвёртый", "Fourth", 2, "Четвёртая" }
                });

            migrationBuilder.InsertData(
                table: "Plans",
                columns: new[] { "Id", "Item", "MeetupId" },
                values: new object[,]
                {
                    { 1, "Первый", 1 },
                    { 2, "Второй", 1 },
                    { 3, "Первый", 2 },
                    { 4, "Второй", 2 }
                });

            migrationBuilder.InsertData(
                table: "Speakers",
                columns: new[] { "Id", "FirstName", "LastName", "MeetupId", "Topic" },
                values: new object[,]
                {
                    { 1, "Первый", "First", 1, "Первая" },
                    { 2, "Второй", "Second", 1, "Вторая" },
                    { 3, "Третий", "Third", 2, "Третья" },
                    { 4, "Четвёртый", "Fourth", 2, "Четвёртая" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Organizers_MeetupId",
                table: "Organizers",
                column: "MeetupId");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_MeetupId",
                table: "Plans",
                column: "MeetupId");

            migrationBuilder.CreateIndex(
                name: "IX_Speakers_MeetupId",
                table: "Speakers",
                column: "MeetupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Organizers");

            migrationBuilder.DropTable(
                name: "Plans");

            migrationBuilder.DropTable(
                name: "Speakers");

            migrationBuilder.DropTable(
                name: "Meetups");
        }
    }
}
