using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvukatProjectRepository.Migrations
{
    public partial class h6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnsweredQuestions",
                table: "Lawyers",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Lawyers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 23, 19, 19, 4, 708, DateTimeKind.Local).AddTicks(317));

            migrationBuilder.UpdateData(
                table: "Lawyers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 23, 19, 19, 4, 708, DateTimeKind.Local).AddTicks(327));

            migrationBuilder.UpdateData(
                table: "Lawyers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 23, 19, 19, 4, 708, DateTimeKind.Local).AddTicks(328));

            migrationBuilder.UpdateData(
                table: "Lawyers",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 23, 19, 19, 4, 708, DateTimeKind.Local).AddTicks(329));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnsweredQuestions",
                table: "Lawyers");

            migrationBuilder.UpdateData(
                table: "Lawyers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 23, 19, 15, 11, 679, DateTimeKind.Local).AddTicks(5196));

            migrationBuilder.UpdateData(
                table: "Lawyers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 23, 19, 15, 11, 679, DateTimeKind.Local).AddTicks(5205));

            migrationBuilder.UpdateData(
                table: "Lawyers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 23, 19, 15, 11, 679, DateTimeKind.Local).AddTicks(5206));

            migrationBuilder.UpdateData(
                table: "Lawyers",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 23, 19, 15, 11, 679, DateTimeKind.Local).AddTicks(5207));
        }
    }
}
