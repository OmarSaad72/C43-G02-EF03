using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.Migrations
{
    /// <inheritdoc />
    public partial class TPH : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FullTimeEmployee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PartTimeEmployee",
                table: "PartTimeEmployee");

            migrationBuilder.RenameTable(
                name: "PartTimeEmployee",
                newName: "Employee");

            migrationBuilder.AlterColumn<decimal>(
                name: "HourRate",
                table: "Employee",
                type: "decimal(18,0)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)");

            migrationBuilder.AlterColumn<int>(
                name: "CountOfHour",
                table: "Employee",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Employee",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Salary",
                table: "Employee",
                type: "decimal(18,0)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Employee",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Employee");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "PartTimeEmployee");

            migrationBuilder.AlterColumn<decimal>(
                name: "HourRate",
                table: "PartTimeEmployee",
                type: "decimal(18,0)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CountOfHour",
                table: "PartTimeEmployee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PartTimeEmployee",
                table: "PartTimeEmployee",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "FullTimeEmployee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FullTimeEmployee", x => x.Id);
                });
        }
    }
}
