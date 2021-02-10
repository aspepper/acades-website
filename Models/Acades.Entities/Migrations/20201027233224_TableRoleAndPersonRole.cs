using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Acades.Entities.Migrations
{
    public partial class TableRoleAndPersonRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Person",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 27, 20, 32, 24, 216, DateTimeKind.Local).AddTicks(2520),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 10, 14, 7, 45, 14, 428, DateTimeKind.Local).AddTicks(6290));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Person",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 27, 20, 32, 24, 181, DateTimeKind.Local).AddTicks(1170),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 10, 14, 7, 45, 14, 393, DateTimeKind.Local).AddTicks(8060));

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: true),
                    InsertDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 10, 27, 20, 32, 24, 228, DateTimeKind.Local).AddTicks(6430)),
                    InsertUser = table.Column<int>(nullable: false, defaultValue: 1),
                    UpdateDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 10, 27, 20, 32, 24, 229, DateTimeKind.Local).AddTicks(2070)),
                    UpdateUser = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true),
                    PersonId = table.Column<int>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: true),
                    InsertDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 10, 27, 20, 32, 24, 223, DateTimeKind.Local).AddTicks(7130)),
                    InsertUser = table.Column<int>(nullable: false, defaultValue: 1),
                    UpdateDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 10, 27, 20, 32, 24, 224, DateTimeKind.Local).AddTicks(2560)),
                    UpdateUser = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonRole",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: true),
                    InsertDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 10, 27, 20, 32, 24, 234, DateTimeKind.Local).AddTicks(7210)),
                    InsertUser = table.Column<int>(nullable: false, defaultValue: 1),
                    UpdateDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 10, 27, 20, 32, 24, 235, DateTimeKind.Local).AddTicks(5760)),
                    UpdateUser = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonRole_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonRole_PersonId",
                table: "PersonRole",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonRole_RoleId",
                table: "PersonRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_User_PersonId",
                table: "User",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonRole");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Person",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 14, 7, 45, 14, 428, DateTimeKind.Local).AddTicks(6290),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 10, 27, 20, 32, 24, 216, DateTimeKind.Local).AddTicks(2520));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Person",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 14, 7, 45, 14, 393, DateTimeKind.Local).AddTicks(8060),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 10, 27, 20, 32, 24, 181, DateTimeKind.Local).AddTicks(1170));
        }
    }
}
