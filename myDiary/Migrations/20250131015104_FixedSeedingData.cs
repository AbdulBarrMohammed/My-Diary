using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace myDiary.Migrations
{
    /// <inheritdoc />
    public partial class FixedSeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DiaryEntries",
                columns: new[] { "Id", "Content", "Created", "Title" },
                values: new object[,]
                {
                    { 1, "Went hiking with Joe!", new DateTime(2024, 1, 30, 12, 0, 0, 0, DateTimeKind.Unspecified), "Went Hiking" },
                    { 2, "Went shopping with Joe!", new DateTime(2024, 1, 30, 12, 0, 0, 0, DateTimeKind.Unspecified), "Went Shopping" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
