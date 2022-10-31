using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentEmployeeCollection.Migrations
{
    public partial class student_seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "BYUID", "BYUName", "EmailAddress", "FirstName", "Gender", "International", "LastName", "NameChangeCompleted", "Notes", "PayGradTuition", "Phone", "ProgramYear", "Semester", "SubmissionDate", "SubmittedEForm", "Year" },
                values: new object[] { "64-844-6387", "ajt82097", "alexis.transfiguracion@gmail.com", "Alexis", "Female", false, "Ferolino", true, "Is awesome", true, "8087969783", "MSB Core (IS or other)", "Winter", new DateTime(2022, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2022 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "BYUID",
                keyValue: "64-844-6387");
        }
    }
}
