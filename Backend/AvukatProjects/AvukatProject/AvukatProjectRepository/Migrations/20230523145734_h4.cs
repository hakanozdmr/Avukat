using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvukatProjectRepository.Migrations
{
    public partial class h4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AverageRating",
                table: "Lawyers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RatingedQuestions",
                table: "Lawyers",
                type: "int",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AverageRating",
                table: "Lawyers");

            migrationBuilder.DropColumn(
                name: "RatingedQuestions",
                table: "Lawyers");

            migrationBuilder.UpdateData(
                table: "Lawyers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 22, 14, 17, 28, 807, DateTimeKind.Local).AddTicks(5955));

            migrationBuilder.UpdateData(
                table: "Lawyers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 22, 14, 17, 28, 807, DateTimeKind.Local).AddTicks(5966));

            migrationBuilder.UpdateData(
                table: "Lawyers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 22, 14, 17, 28, 807, DateTimeKind.Local).AddTicks(5967));

            migrationBuilder.UpdateData(
                table: "Lawyers",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 22, 14, 17, 28, 807, DateTimeKind.Local).AddTicks(5968));
        }
    }
}
