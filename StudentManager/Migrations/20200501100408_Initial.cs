using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManager.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "nvarchar(40)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(40)", nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(60)", nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(16)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
