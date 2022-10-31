using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentEmployeeCollection.Migrations
{
    public partial class tons_of_stuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student_Supervisor");

            migrationBuilder.DropTable(
                name: "StudentPositionType");

            migrationBuilder.DropColumn(
                name: "NameChangeComp",
                table: "PositionType");

            migrationBuilder.AddColumn<bool>(
                name: "NameChangeCompleted",
                table: "Student",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    PositionID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmplRec = table.Column<int>(nullable: false),
                    HireDate = table.Column<DateTime>(nullable: true),
                    ExpectedHours = table.Column<int>(nullable: false),
                    TerminationDate = table.Column<DateTime>(nullable: true),
                    AuthToWorkReceive = table.Column<bool>(nullable: false),
                    AuthToWorkMailSentDate = table.Column<DateTime>(nullable: true),
                    ClassCode = table.Column<string>(nullable: true),
                    QualtricsURL = table.Column<string>(nullable: true),
                    PositionTypeID = table.Column<int>(nullable: false),
                    SupervisorID = table.Column<int>(nullable: false),
                    BYUID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.PositionID);
                    table.ForeignKey(
                        name: "FK_Position_Student_BYUID",
                        column: x => x.BYUID,
                        principalTable: "Student",
                        principalColumn: "BYUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Position_PositionType_PositionTypeID",
                        column: x => x.PositionTypeID,
                        principalTable: "PositionType",
                        principalColumn: "PositionTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Position_Supervisor_SupervisorID",
                        column: x => x.SupervisorID,
                        principalTable: "Supervisor",
                        principalColumn: "SupervisorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PayIncrease",
                columns: table => new
                {
                    PayIncreaseID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    PositionID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayIncrease", x => x.PayIncreaseID);
                    table.ForeignKey(
                        name: "FK_PayIncrease_Position_PositionID",
                        column: x => x.PositionID,
                        principalTable: "Position",
                        principalColumn: "PositionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PayIncrease_PositionID",
                table: "PayIncrease",
                column: "PositionID");

            migrationBuilder.CreateIndex(
                name: "IX_Position_BYUID",
                table: "Position",
                column: "BYUID");

            migrationBuilder.CreateIndex(
                name: "IX_Position_PositionTypeID",
                table: "Position",
                column: "PositionTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Position_SupervisorID",
                table: "Position",
                column: "SupervisorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PayIncrease");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropColumn(
                name: "NameChangeCompleted",
                table: "Student");

            migrationBuilder.AddColumn<bool>(
                name: "NameChangeComp",
                table: "PositionType",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Student_Supervisor",
                columns: table => new
                {
                    Student_SupervisorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BYUID = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true),
                    SupervisorID = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "StudentPositionType",
                columns: table => new
                {
                    StudentPositionTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AuthToWorkMailSentDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    AuthToWorkReceive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    BYUID = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true),
                    ClassCode = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    EmplRec = table.Column<int>(type: "int", nullable: false),
                    ExpectedHours = table.Column<int>(type: "int", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IncreaseDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastPayIncrease = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    PayIncreaseAmt = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    PositionTypeID = table.Column<int>(type: "int", nullable: false),
                    QualtricsURL = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Terminated = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TerminationDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
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
    }
}
