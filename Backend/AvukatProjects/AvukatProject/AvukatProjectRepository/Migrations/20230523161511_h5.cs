using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvukatProjectRepository.Migrations
{
    public partial class h5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalQuestions",
                table: "Lawyers",
                type: "int",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalQuestions",
                table: "Lawyers");

            migrationBuilder.UpdateData(
                table: "Lawyers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 23, 17, 57, 34, 616, DateTimeKind.Local).AddTicks(8821));

            migrationBuilder.UpdateData(
                table: "Lawyers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 23, 17, 57, 34, 616, DateTimeKind.Local).AddTicks(8832));

            migrationBuilder.UpdateData(
                table: "Lawyers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 23, 17, 57, 34, 616, DateTimeKind.Local).AddTicks(8833));

            migrationBuilder.UpdateData(
                table: "Lawyers",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 23, 17, 57, 34, 616, DateTimeKind.Local).AddTicks(8834));
        }
    }
}
