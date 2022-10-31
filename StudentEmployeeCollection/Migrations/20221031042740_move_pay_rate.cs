using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentEmployeeCollection.Migrations
{
    public partial class move_pay_rate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PayRate",
                table: "PositionType");

            migrationBuilder.DropColumn(
                name: "PositionTypes",
                table: "PositionType");

            migrationBuilder.AddColumn<string>(
                name: "PositionName",
                table: "PositionType",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PayRate",
                table: "Position",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "PositionType",
                columns: new[] { "PositionTypeID", "PositionName" },
                values: new object[,]
                {
                    { 1, "TA" },
                    { 2, "RA" },
                    { 3, "Office" },
                    { 4, "Student Instructor" },
                    { 5, "Other" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PositionType",
                keyColumn: "PositionTypeID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PositionType",
                keyColumn: "PositionTypeID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PositionType",
                keyColumn: "PositionTypeID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PositionType",
                keyColumn: "PositionTypeID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PositionType",
                keyColumn: "PositionTypeID",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "PositionName",
                table: "PositionType");

            migrationBuilder.DropColumn(
                name: "PayRate",
                table: "Position");

            migrationBuilder.AddColumn<decimal>(
                name: "PayRate",
                table: "PositionType",
                type: "decimal(65,30)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PositionTypes",
                table: "PositionType",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
