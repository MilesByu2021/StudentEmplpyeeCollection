using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentEmployeeCollection.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PositionType",
                columns: table => new
                {
                    PositionTypeID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PositionTypes = table.Column<string>(nullable: true),
                    PayRate = table.Column<decimal>(nullable: true),
                    NameChangeComp = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionType", x => x.PositionTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    BYUID = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    International = table.Column<bool>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    Semester = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    ProgramYear = table.Column<string>(nullable: true),
                    PayGradTuition = table.Column<bool>(nullable: false),
                    SubmittedEForm = table.Column<bool>(nullable: false),
                    SubmissionDate = table.Column<DateTime>(nullable: true),
                    BYUName = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.BYUID);
                });

            migrationBuilder.CreateTable(
                name: "Supervisor",
                columns: table => new
                {
                    SupervisorID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supervisor", x => x.SupervisorID);
                });

            migrationBuilder.CreateTable(
                name: "QualtricsSent",
                columns: table => new
                {
                    QualtricsSentID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    QualtricsURL = table.Column<string>(nullable: true),
                    BYUID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualtricsSent", x => x.QualtricsSentID);
                    table.ForeignKey(
                        name: "FK_QualtricsSent_Student_BYUID",
                        column: x => x.BYUID,
                        principalTable: "Student",
                        principalColumn: "BYUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentPositionType",
                columns: table => new
                {
                    StudentPositionTypeID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BYUID = table.Column<string>(nullable: true),
                    EmplRec = table.Column<int>(nullable: false),
                    HireDate = table.Column<DateTime>(nullable: true),
                    ExpectedHours = table.Column<int>(nullable: false),
                    LastPayIncrease = table.Column<DateTime>(nullable: true),
                    PayIncreaseAmt = table.Column<decimal>(nullable: true),
                    IncreaseDate = table.Column<DateTime>(nullable: true),
                    Terminated = table.Column<bool>(nullable: false),
                    TerminationDate = table.Column<DateTime>(nullable: true),
                    AuthToWorkReceive = table.Column<bool>(nullable: false),
                    AuthToWorkMailSentDate = table.Column<DateTime>(nullable: true),
                    ClassCode = table.Column<string>(nullable: true),
                    PositionTypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentPositionType", x => x.StudentPositionTypeID);
                    table.ForeignKey(
                        name: "FK_StudentPositionType_Student_BYUID",
                        column: x => x.BYUID,
                        principalTable: "Student",
                        principalColumn: "BYUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentPositionType_PositionType_PositionTypeID",
                        column: x => x.PositionTypeID,
                        principalTable: "PositionType",
                        principalColumn: "PositionTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student_Supervisor",
                columns: table => new
                {
                    Student_SupervisorID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BYUID = table.Column<string>(nullable: true),
                    SupervisorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student_Supervisor", x => x.Student_SupervisorID);
                    table.ForeignKey(
                        name: "FK_Student_Supervisor_Student_BYUID",
                        column: x => x.BYUID,
                        principalTable: "Student",
                        principalColumn: "BYUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_Supervisor_Supervisor_SupervisorID",
                        column: x => x.SupervisorID,
                        principalTable: "Supervisor",
                        principalColumn: "SupervisorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QualtricsSent_BYUID",
                table: "QualtricsSent",
                column: "BYUID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Supervisor_BYUID",
                table: "Student_Supervisor",
                column: "BYUID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Supervisor_SupervisorID",
                table: "Student_Supervisor",
                column: "SupervisorID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPositionType_BYUID",
                table: "StudentPositionType",
                column: "BYUID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPositionType_PositionTypeID",
                table: "StudentPositionType",
                column: "PositionTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QualtricsSent");

            migrationBuilder.DropTable(
                name: "Student_Supervisor");

            migrationBuilder.DropTable(
                name: "StudentPositionType");

            migrationBuilder.DropTable(
                name: "Supervisor");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "PositionType");
        }
    }
}
