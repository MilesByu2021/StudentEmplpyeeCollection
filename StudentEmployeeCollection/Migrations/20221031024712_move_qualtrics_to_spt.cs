using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentEmployeeCollection.Migrations
{
    public partial class move_qualtrics_to_spt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QualtricsSent");

            migrationBuilder.AddColumn<string>(
                name: "QualtricsURL",
                table: "StudentPositionType",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QualtricsURL",
                table: "StudentPositionType");

            migrationBuilder.CreateTable(
                name: "QualtricsSent",
                columns: table => new
                {
                    QualtricsSentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BYUID = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true),
                    QualtricsURL = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_QualtricsSent_BYUID",
                table: "QualtricsSent",
                column: "BYUID");
        }
    }
}
