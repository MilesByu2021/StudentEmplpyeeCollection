using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentEmployeeCollection.Migrations
{
    public partial class supervisors_seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Supervisor",
                columns: new[] { "SupervisorID", "FirstName", "LastName" },
                values: new object[] { 1, "Greg", "Anderson" });

            migrationBuilder.InsertData(
                table: "Supervisor",
                columns: new[] { "SupervisorID", "FirstName", "LastName" },
                values: new object[] { 2, "Spencer", "Hilton" });

            migrationBuilder.InsertData(
                table: "Supervisor",
                columns: new[] { "SupervisorID", "FirstName", "LastName" },
                values: new object[] { 3, "Katy", "Reese" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Supervisor",
                keyColumn: "SupervisorID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Supervisor",
                keyColumn: "SupervisorID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Supervisor",
                keyColumn: "SupervisorID",
                keyValue: 3);
        }
    }
}
