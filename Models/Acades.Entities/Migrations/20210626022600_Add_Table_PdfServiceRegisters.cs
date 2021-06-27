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
                defaultValue: new DateTime(2021, 6, 25, 23, 25, 59, 108, DateTimeKind.Local).AddTicks(8300),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 662, DateTimeKind.Local).AddTicks(5600));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "User",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 25, 23, 25, 59, 108, DateTimeKind.Local).AddTicks(950),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 661, DateTimeKind.Local).AddTicks(8740));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Role",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 25, 23, 25, 59, 116, DateTimeKind.Local).AddTicks(3670),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 669, DateTimeKind.Local).AddTicks(9050));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Role",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 25, 23, 25, 59, 115, DateTimeKind.Local).AddTicks(5060),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 668, DateTimeKind.Local).AddTicks(9150));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "PersonRole",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 25, 23, 25, 59, 133, DateTimeKind.Local).AddTicks(6140),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 687, DateTimeKind.Local).AddTicks(2530));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "PersonRole",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 25, 23, 25, 59, 132, DateTimeKind.Local).AddTicks(8980),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 686, DateTimeKind.Local).AddTicks(2690));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Person",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 25, 23, 25, 59, 95, DateTimeKind.Local).AddTicks(3860),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 642, DateTimeKind.Local).AddTicks(2150));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Person",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 25, 23, 25, 59, 33, DateTimeKind.Local).AddTicks(8520),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 569, DateTimeKind.Local).AddTicks(7640));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "FileType",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 25, 23, 25, 59, 147, DateTimeKind.Local).AddTicks(1370),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 710, DateTimeKind.Local).AddTicks(1760));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "FileType",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 25, 23, 25, 59, 146, DateTimeKind.Local).AddTicks(3910),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 709, DateTimeKind.Local).AddTicks(3960));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "File",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 25, 23, 25, 59, 142, DateTimeKind.Local).AddTicks(4690),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 700, DateTimeKind.Local).AddTicks(7590));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "File",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 25, 23, 25, 59, 141, DateTimeKind.Local).AddTicks(8020),
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
                    GeneratedDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2021, 6, 25, 23, 25, 59, 154, DateTimeKind.Local).AddTicks(5990)),
                    FileName = table.Column<string>(maxLength: 200, nullable: false),
                    FilePdfUrl = table.Column<string>(maxLength: 200, nullable: true),
                    OwnerName = table.Column<string>(maxLength: 50, nullable: true),
                    OwnerEmail = table.Column<string>(maxLength: 100, nullable: true),
                    OwnerDocument = table.Column<string>(maxLength: 20, nullable: true),
                    PrintCustomerData = table.Column<bool>(nullable: false, defaultValue: false),
                    Error = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    InsertDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2021, 6, 25, 23, 25, 59, 156, DateTimeKind.Local).AddTicks(5240)),
                    InsertUser = table.Column<int>(nullable: false, defaultValue: 1),
                    UpdateDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2021, 6, 25, 23, 25, 59, 157, DateTimeKind.Local).AddTicks(3410)),
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
                oldDefaultValue: new DateTime(2021, 6, 25, 23, 25, 59, 108, DateTimeKind.Local).AddTicks(8300));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 661, DateTimeKind.Local).AddTicks(8740),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 6, 25, 23, 25, 59, 108, DateTimeKind.Local).AddTicks(950));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Role",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 669, DateTimeKind.Local).AddTicks(9050),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 6, 25, 23, 25, 59, 116, DateTimeKind.Local).AddTicks(3670));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Role",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 668, DateTimeKind.Local).AddTicks(9150),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 6, 25, 23, 25, 59, 115, DateTimeKind.Local).AddTicks(5060));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "PersonRole",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 687, DateTimeKind.Local).AddTicks(2530),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 6, 25, 23, 25, 59, 133, DateTimeKind.Local).AddTicks(6140));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "PersonRole",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 686, DateTimeKind.Local).AddTicks(2690),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 6, 25, 23, 25, 59, 132, DateTimeKind.Local).AddTicks(8980));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Person",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 642, DateTimeKind.Local).AddTicks(2150),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 6, 25, 23, 25, 59, 95, DateTimeKind.Local).AddTicks(3860));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Person",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 569, DateTimeKind.Local).AddTicks(7640),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 6, 25, 23, 25, 59, 33, DateTimeKind.Local).AddTicks(8520));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "FileType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 710, DateTimeKind.Local).AddTicks(1760),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 6, 25, 23, 25, 59, 147, DateTimeKind.Local).AddTicks(1370));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "FileType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 709, DateTimeKind.Local).AddTicks(3960),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 6, 25, 23, 25, 59, 146, DateTimeKind.Local).AddTicks(3910));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "File",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 700, DateTimeKind.Local).AddTicks(7590),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 6, 25, 23, 25, 59, 142, DateTimeKind.Local).AddTicks(4690));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "File",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 25, 15, 4, 1, 699, DateTimeKind.Local).AddTicks(9500),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 6, 25, 23, 25, 59, 141, DateTimeKind.Local).AddTicks(8020));
        }
    }
}
