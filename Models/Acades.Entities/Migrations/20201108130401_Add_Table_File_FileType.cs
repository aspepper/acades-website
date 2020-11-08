using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Acades.Entities.Migrations
{
    public partial class Add_Table_File_FileType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "User",
                nullable: false,
                defaultValue: new DateTime(2020, 11, 8, 10, 4, 0, 636, DateTimeKind.Local).AddTicks(4290),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 10, 27, 20, 32, 24, 224, DateTimeKind.Local).AddTicks(2560));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "User",
                nullable: false,
                defaultValue: new DateTime(2020, 11, 8, 10, 4, 0, 635, DateTimeKind.Local).AddTicks(7030),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 10, 27, 20, 32, 24, 223, DateTimeKind.Local).AddTicks(7130));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Role",
                nullable: false,
                defaultValue: new DateTime(2020, 11, 8, 10, 4, 0, 640, DateTimeKind.Local).AddTicks(8080),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 10, 27, 20, 32, 24, 229, DateTimeKind.Local).AddTicks(2070));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Role",
                nullable: false,
                defaultValue: new DateTime(2020, 11, 8, 10, 4, 0, 640, DateTimeKind.Local).AddTicks(1950),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 10, 27, 20, 32, 24, 228, DateTimeKind.Local).AddTicks(6430));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "PersonRole",
                nullable: false,
                defaultValue: new DateTime(2020, 11, 8, 10, 4, 0, 647, DateTimeKind.Local).AddTicks(8940),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 10, 27, 20, 32, 24, 235, DateTimeKind.Local).AddTicks(5760));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "PersonRole",
                nullable: false,
                defaultValue: new DateTime(2020, 11, 8, 10, 4, 0, 647, DateTimeKind.Local).AddTicks(3330),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 10, 27, 20, 32, 24, 234, DateTimeKind.Local).AddTicks(7210));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Person",
                nullable: false,
                defaultValue: new DateTime(2020, 11, 8, 10, 4, 0, 627, DateTimeKind.Local).AddTicks(4020),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 10, 27, 20, 32, 24, 216, DateTimeKind.Local).AddTicks(2520));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Person",
                nullable: false,
                defaultValue: new DateTime(2020, 11, 8, 10, 4, 0, 592, DateTimeKind.Local).AddTicks(3840),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 10, 27, 20, 32, 24, 181, DateTimeKind.Local).AddTicks(1170));

            migrationBuilder.CreateTable(
                name: "FileType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: true),
                    InsertDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 11, 8, 10, 4, 0, 661, DateTimeKind.Local).AddTicks(5960)),
                    InsertUser = table.Column<int>(nullable: false, defaultValue: 1),
                    UpdateDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 11, 8, 10, 4, 0, 662, DateTimeKind.Local).AddTicks(2410)),
                    UpdateUser = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileType", x => x.Id);
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
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: true),
                    InsertDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 11, 8, 10, 4, 0, 656, DateTimeKind.Local).AddTicks(7920)),
                    InsertUser = table.Column<int>(nullable: false, defaultValue: 1),
                    UpdateDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 11, 8, 10, 4, 0, 657, DateTimeKind.Local).AddTicks(4430)),
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

            migrationBuilder.CreateIndex(
                name: "IX_File_FileTypeId",
                table: "File",
                column: "FileTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_File_PersonId",
                table: "File",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.DropTable(
                name: "FileType");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 27, 20, 32, 24, 224, DateTimeKind.Local).AddTicks(2560),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 11, 8, 10, 4, 0, 636, DateTimeKind.Local).AddTicks(4290));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 27, 20, 32, 24, 223, DateTimeKind.Local).AddTicks(7130),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 11, 8, 10, 4, 0, 635, DateTimeKind.Local).AddTicks(7030));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Role",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 27, 20, 32, 24, 229, DateTimeKind.Local).AddTicks(2070),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 11, 8, 10, 4, 0, 640, DateTimeKind.Local).AddTicks(8080));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Role",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 27, 20, 32, 24, 228, DateTimeKind.Local).AddTicks(6430),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 11, 8, 10, 4, 0, 640, DateTimeKind.Local).AddTicks(1950));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "PersonRole",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 27, 20, 32, 24, 235, DateTimeKind.Local).AddTicks(5760),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 11, 8, 10, 4, 0, 647, DateTimeKind.Local).AddTicks(8940));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "PersonRole",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 27, 20, 32, 24, 234, DateTimeKind.Local).AddTicks(7210),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 11, 8, 10, 4, 0, 647, DateTimeKind.Local).AddTicks(3330));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Person",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 27, 20, 32, 24, 216, DateTimeKind.Local).AddTicks(2520),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 11, 8, 10, 4, 0, 627, DateTimeKind.Local).AddTicks(4020));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Person",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 27, 20, 32, 24, 181, DateTimeKind.Local).AddTicks(1170),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 11, 8, 10, 4, 0, 592, DateTimeKind.Local).AddTicks(3840));
        }
    }
}
