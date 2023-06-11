using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvukatProjectRepository.Migrations
{
    public partial class mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Oppressions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Oppression = table.Column<double>(type: "float", nullable: false),
                    OppressionQuestionId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oppressions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Oppressions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Lawyers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 20, 15, 11, 30, 344, DateTimeKind.Local).AddTicks(2761));

            migrationBuilder.UpdateData(
                table: "Lawyers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 20, 15, 11, 30, 344, DateTimeKind.Local).AddTicks(2776));

            migrationBuilder.UpdateData(
                table: "Lawyers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 20, 15, 11, 30, 344, DateTimeKind.Local).AddTicks(2778));

            migrationBuilder.CreateIndex(
                name: "IX_Oppressions_QuestionId",
                table: "Oppressions",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Oppressions");

            migrationBuilder.UpdateData(
                table: "Lawyers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 20, 14, 24, 19, 969, DateTimeKind.Local).AddTicks(1637));

            migrationBuilder.UpdateData(
                table: "Lawyers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 20, 14, 24, 19, 969, DateTimeKind.Local).AddTicks(1649));

            migrationBuilder.UpdateData(
                table: "Lawyers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 20, 14, 24, 19, 969, DateTimeKind.Local).AddTicks(1651));
        }
    }
}
