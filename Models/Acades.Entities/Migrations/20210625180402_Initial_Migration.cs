using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Acades.Entities.Migrations
{
    public partial class Initial_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FileType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    InsertDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 709, DateTimeKind.Local).AddTicks(3960)),
                    InsertUser = table.Column<int>(nullable: false, defaultValue: 1),
                    UpdateDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 710, DateTimeKind.Local).AddTicks(1760)),
                    UpdateUser = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Document = table.Column<string>(maxLength: 20, nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    InsertDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 569, DateTimeKind.Local).AddTicks(7640)),
                    InsertUser = table.Column<int>(nullable: false, defaultValue: 1),
                    UpdateDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 642, DateTimeKind.Local).AddTicks(2150)),
                    UpdateUser = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    NormalizedName = table.Column<string>(maxLength: 50, nullable: false),
                    Area = table.Column<string>(maxLength: 30, nullable: false),
                    IsVisible = table.Column<bool>(nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    IsAdm = table.Column<bool>(nullable: false, defaultValue: false),
                    InsertDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 668, DateTimeKind.Local).AddTicks(9150)),
                    InsertUser = table.Column<int>(nullable: false, defaultValue: 1),
                    UpdateDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 669, DateTimeKind.Local).AddTicks(9050)),
                    UpdateUser = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileTypeId = table.Column<int>(nullable: false),
                    FileName = table.Column<string>(nullable: true),
                    FileNameOriginal = table.Column<string>(nullable: true),
                    FileExtension = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    PersonId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    InsertDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 699, DateTimeKind.Local).AddTicks(9500)),
                    InsertUser = table.Column<int>(nullable: false, defaultValue: 1),
                    UpdateDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 700, DateTimeKind.Local).AddTicks(7590)),
                    UpdateUser = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_FileType_FileTypeId",
                        column: x => x.FileTypeId,
                        principalTable: "FileType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_File_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 30, nullable: false),
                    Email = table.Column<string>(nullable: true),
                    PersonId = table.Column<int>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    InsertDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 661, DateTimeKind.Local).AddTicks(8740)),
                    InsertUser = table.Column<int>(nullable: false, defaultValue: 1),
                    UpdateDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 662, DateTimeKind.Local).AddTicks(5600)),
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
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    InsertDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 686, DateTimeKind.Local).AddTicks(2690)),
                    InsertUser = table.Column<int>(nullable: false, defaultValue: 1),
                    UpdateDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 687, DateTimeKind.Local).AddTicks(2530)),
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
                name: "IX_File_FileTypeId",
                table: "File",
                column: "FileTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_File_PersonId",
                table: "File",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonRole_PersonId",
                table: "PersonRole",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonRole_RoleId",
                table: "PersonRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_NormalizedName",
                table: "Role",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_PersonId",
                table: "User",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.DropTable(
                name: "PersonRole");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "FileType");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
