using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KindQuestBE.Migrations
{
    /// <inheritdoc />
    public partial class RemovedUnecessaryProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProjectImg",
                table: "Projects",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Projects",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCompleted", "DatePosted" },
                values: new object[] { new DateTime(2025, 4, 23, 23, 39, 36, 310, DateTimeKind.Utc).AddTicks(9751), new DateTime(2025, 4, 22, 23, 39, 36, 310, DateTimeKind.Utc).AddTicks(9751) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCompleted", "DatePosted" },
                values: new object[] { new DateTime(2025, 4, 27, 23, 39, 36, 310, DateTimeKind.Utc).AddTicks(9715), new DateTime(2025, 4, 22, 23, 39, 36, 310, DateTimeKind.Utc).AddTicks(9711) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProjectImg",
                table: "Projects",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Projects",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "TaskList",
                table: "Projects",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCompleted", "DatePosted" },
                values: new object[] { new DateTime(2025, 4, 20, 15, 1, 53, 417, DateTimeKind.Utc).AddTicks(3171), new DateTime(2025, 4, 19, 15, 1, 53, 417, DateTimeKind.Utc).AddTicks(3170) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCompleted", "DatePosted", "TaskList" },
                values: new object[] { new DateTime(2025, 4, 24, 15, 1, 53, 417, DateTimeKind.Utc).AddTicks(3139), new DateTime(2025, 4, 19, 15, 1, 53, 417, DateTimeKind.Utc).AddTicks(3138), null });
        }
    }
}
