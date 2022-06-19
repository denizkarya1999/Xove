using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Xove.Domain.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Partners",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    CurrentPosition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Interests = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SexualOrientation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortBiography = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partners", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Partners",
                columns: new[] { "Id", "Age", "CreatedDate", "CurrentPosition", "FullName", "Gender", "Interests", "Location", "ModifiedDate", "SexualOrientation", "ShortBiography" },
                values: new object[] { new Guid("95091c3e-bf12-4c7f-8edf-436c5b9c1f75"), 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Student - University of Michigan-Dearborn", "Deniz K Acikbas", "Cis Male", "Programming, Drawing, Cars, Video Games, Music, Netflix & Chill", "Dearborn, Michigan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bisexual", "Knows English, German and Turkish" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Partners");
        }
    }
}
