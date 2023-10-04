using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GetItDone",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GetItDone", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "GetItDone",
                columns: new[] { "ID", "CreatedDate", "Description" },
                values: new object[] { 1, new DateTime(2023, 9, 29, 0, 0, 0, 0, DateTimeKind.Local), "Do CIT218 Homework" });

            migrationBuilder.InsertData(
                table: "GetItDone",
                columns: new[] { "ID", "CreatedDate", "Description" },
                values: new object[] { 2, new DateTime(2023, 9, 29, 0, 0, 0, 0, DateTimeKind.Local), "Take a nap" });

            migrationBuilder.InsertData(
                table: "GetItDone",
                columns: new[] { "ID", "CreatedDate", "Description" },
                values: new object[] { 3, new DateTime(2023, 9, 29, 0, 0, 0, 0, DateTimeKind.Local), "Work Out" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GetItDone");
        }
    }
}
