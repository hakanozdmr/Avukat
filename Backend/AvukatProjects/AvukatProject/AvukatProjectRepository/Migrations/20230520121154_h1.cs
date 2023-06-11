using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvukatProjectRepository.Migrations
{
    public partial class h1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "state",
                table: "Questions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Lawyers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 20, 15, 11, 53, 794, DateTimeKind.Local).AddTicks(6868));

            migrationBuilder.UpdateData(
                table: "Lawyers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 20, 15, 11, 53, 794, DateTimeKind.Local).AddTicks(6878));

            migrationBuilder.UpdateData(
                table: "Lawyers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 20, 15, 11, 53, 794, DateTimeKind.Local).AddTicks(6879));

            migrationBuilder.InsertData(
                table: "Lawyers",
                columns: new[] { "Id", "About", "CategoryId", "CreatedDate", "Mail", "Name", "Password", "Photograph", "UpdatedDate" },
                values: new object[] { 9, "Borçlar Hukukçusu", 3, new DateTime(2023, 5, 20, 15, 11, 53, 794, DateTimeKind.Local).AddTicks(6881), "hakanozdemır@gmail.com", "Hakan Özdemir", "123444", "asd", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lawyers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DropColumn(
                name: "state",
                table: "Questions");

            migrationBuilder.UpdateData(
                table: "Lawyers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 20, 15, 12, 20, 964, DateTimeKind.Local).AddTicks(5412));

            migrationBuilder.UpdateData(
                table: "Lawyers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 20, 15, 12, 20, 964, DateTimeKind.Local).AddTicks(5424));

            migrationBuilder.UpdateData(
                table: "Lawyers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 20, 15, 12, 20, 964, DateTimeKind.Local).AddTicks(5426));
        }
    }
}
