using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Acades.Entities.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Document = table.Column<string>(maxLength: 20, nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: true),
                    InsertDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 10, 14, 7, 45, 14, 393, DateTimeKind.Local).AddTicks(8060)),
                    InsertUser = table.Column<int>(nullable: false, defaultValue: 1),
                    UpdateDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 10, 14, 7, 45, 14, 428, DateTimeKind.Local).AddTicks(6290)),
                    UpdateUser = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
