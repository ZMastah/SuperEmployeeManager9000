using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SuperEmployeeManager9000.Migrations
{
    public partial class AddingHistoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SalaryHistory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeID = table.Column<int>(nullable: false),
                    SalaryForThePeriod = table.Column<int>(nullable: false),
                    SalaryPeriodBegan = table.Column<DateTime>(nullable: false),
                    SalaryPeriodEnded = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryHistory", x => x.ID);
                });

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employee",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Employee",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCurrentlyHired",
                table: "Employee",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalaryHistory");

            migrationBuilder.DropColumn(
                name: "IsCurrentlyHired",
                table: "Employee");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employee",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Employee",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
