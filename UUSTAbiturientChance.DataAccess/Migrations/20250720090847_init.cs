using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UUSTAbiturientChance.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applicants",
                columns: table => new
                {
                    UniqueCode = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PCode = table.Column<int>(type: "integer", nullable: false),
                    HasNoEntranceTests = table.Column<bool>(type: "boolean", nullable: false),
                    TotalCompetitiveScore = table.Column<int>(type: "integer", nullable: false),
                    TotalEntranceTestsScore = table.Column<int>(type: "integer", nullable: false),
                    MathAlgebraGeometryScore = table.Column<int>(type: "integer", nullable: false),
                    InformatcPhysicScore = table.Column<int>(type: "integer", nullable: false),
                    RussianLanguageScore = table.Column<int>(type: "integer", nullable: false),
                    IndividualAchievementsScore = table.Column<int>(type: "integer", nullable: false),
                    HasFirstPriorityRightArticle = table.Column<bool>(type: "boolean", nullable: false),
                    HasSecondPriorityRightArticle = table.Column<bool>(type: "boolean", nullable: false),
                    HasEnrollmentConsent = table.Column<bool>(type: "boolean", nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    AppliedPrograms = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants", x => x.UniqueCode);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applicants_TotalCompetitiveScore",
                table: "Applicants",
                column: "TotalCompetitiveScore");

            migrationBuilder.CreateIndex(
                name: "IX_Applicants_UniqueCode",
                table: "Applicants",
                column: "UniqueCode",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applicants");
        }
    }
}
