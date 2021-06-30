using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Acades.Entities.Migrations
{
    public partial class Add_Table_PdfServiceRegisters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "User",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 30, 15, 27, 31, 244, DateTimeKind.Local).AddTicks(6940),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 662, DateTimeKind.Local).AddTicks(5600));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "User",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 30, 15, 27, 31, 243, DateTimeKind.Local).AddTicks(8990),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 661, DateTimeKind.Local).AddTicks(8740));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Role",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 30, 15, 27, 31, 252, DateTimeKind.Local).AddTicks(60),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 669, DateTimeKind.Local).AddTicks(9050));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Role",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 30, 15, 27, 31, 251, DateTimeKind.Local).AddTicks(460),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 668, DateTimeKind.Local).AddTicks(9150));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "PersonRole",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 30, 15, 27, 31, 269, DateTimeKind.Local).AddTicks(5260),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 687, DateTimeKind.Local).AddTicks(2530));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "PersonRole",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 30, 15, 27, 31, 268, DateTimeKind.Local).AddTicks(5060),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 686, DateTimeKind.Local).AddTicks(2690));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Person",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 30, 15, 27, 31, 230, DateTimeKind.Local).AddTicks(2490),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 642, DateTimeKind.Local).AddTicks(2150));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Person",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 30, 15, 27, 31, 168, DateTimeKind.Local).AddTicks(8550),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 569, DateTimeKind.Local).AddTicks(7640));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "FileType",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 30, 15, 27, 31, 291, DateTimeKind.Local).AddTicks(4290),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 710, DateTimeKind.Local).AddTicks(1760));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "FileType",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 30, 15, 27, 31, 287, DateTimeKind.Local).AddTicks(7850),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 709, DateTimeKind.Local).AddTicks(3960));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "File",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 30, 15, 27, 31, 280, DateTimeKind.Local).AddTicks(6300),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 700, DateTimeKind.Local).AddTicks(7590));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "File",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 30, 15, 27, 31, 279, DateTimeKind.Local).AddTicks(8750),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 699, DateTimeKind.Local).AddTicks(9500));

            migrationBuilder.CreateTable(
                name: "PdfServiceRegister",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: true),
                    GeneratedDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2021, 6, 30, 15, 27, 31, 299, DateTimeKind.Local).AddTicks(1030)),
                    FileName = table.Column<string>(maxLength: 200, nullable: false),
                    FilePdfUrl = table.Column<string>(maxLength: 200, nullable: true),
                    OwnerName = table.Column<string>(maxLength: 50, nullable: true),
                    OwnerEmail = table.Column<string>(maxLength: 100, nullable: true),
                    OwnerDocument = table.Column<string>(maxLength: 20, nullable: true),
                    PrintCustomerData = table.Column<bool>(nullable: false, defaultValue: false),
                    IPSource = table.Column<string>(maxLength: 15, nullable: true),
                    Error = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    InsertDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2021, 6, 30, 15, 27, 31, 301, DateTimeKind.Local).AddTicks(9650)),
                    InsertUser = table.Column<int>(nullable: false, defaultValue: 1),
                    UpdateDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2021, 6, 30, 15, 27, 31, 302, DateTimeKind.Local).AddTicks(6070)),
                    UpdateUser = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PdfServiceRegister", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PdfServiceRegister");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 662, DateTimeKind.Local).AddTicks(5600),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 6, 30, 15, 27, 31, 244, DateTimeKind.Local).AddTicks(6940));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 661, DateTimeKind.Local).AddTicks(8740),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 6, 30, 15, 27, 31, 243, DateTimeKind.Local).AddTicks(8990));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Role",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 669, DateTimeKind.Local).AddTicks(9050),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 6, 30, 15, 27, 31, 252, DateTimeKind.Local).AddTicks(60));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Role",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 668, DateTimeKind.Local).AddTicks(9150),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 6, 30, 15, 27, 31, 251, DateTimeKind.Local).AddTicks(460));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "PersonRole",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 687, DateTimeKind.Local).AddTicks(2530),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 6, 30, 15, 27, 31, 269, DateTimeKind.Local).AddTicks(5260));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "PersonRole",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 686, DateTimeKind.Local).AddTicks(2690),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 6, 30, 15, 27, 31, 268, DateTimeKind.Local).AddTicks(5060));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Person",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 642, DateTimeKind.Local).AddTicks(2150),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 6, 30, 15, 27, 31, 230, DateTimeKind.Local).AddTicks(2490));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Person",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 569, DateTimeKind.Local).AddTicks(7640),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 6, 30, 15, 27, 31, 168, DateTimeKind.Local).AddTicks(8550));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "FileType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 710, DateTimeKind.Local).AddTicks(1760),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 6, 30, 15, 27, 31, 291, DateTimeKind.Local).AddTicks(4290));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "FileType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 709, DateTimeKind.Local).AddTicks(3960),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 6, 30, 15, 27, 31, 287, DateTimeKind.Local).AddTicks(7850));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "File",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 700, DateTimeKind.Local).AddTicks(7590),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 6, 30, 15, 27, 31, 280, DateTimeKind.Local).AddTicks(6300));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "File",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 699, DateTimeKind.Local).AddTicks(9500),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 6, 30, 15, 27, 31, 279, DateTimeKind.Local).AddTicks(8750));
        }
    }
}
