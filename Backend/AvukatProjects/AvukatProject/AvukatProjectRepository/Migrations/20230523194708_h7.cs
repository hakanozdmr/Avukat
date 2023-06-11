using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvukatProjectRepository.Migrations
{
    public partial class h7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "AverageRating",
                table: "Lawyers",
                type: "float",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Lawyers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 23, 22, 47, 8, 331, DateTimeKind.Local).AddTicks(6528));

            migrationBuilder.UpdateData(
                table: "Lawyers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 23, 22, 47, 8, 331, DateTimeKind.Local).AddTicks(6537));

            migrationBuilder.UpdateData(
                table: "Lawyers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 23, 22, 47, 8, 331, DateTimeKind.Local).AddTicks(6538));

            migrationBuilder.UpdateData(
                table: "Lawyers",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 23, 22, 47, 8, 331, DateTimeKind.Local).AddTicks(6539));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AverageRating",
                table: "Lawyers",
                type: "int",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

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
    }
}
