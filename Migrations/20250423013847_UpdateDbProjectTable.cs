using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KindQuestBE.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDbProjectTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCompleted", "DatePosted" },
                values: new object[] { new DateTime(2025, 4, 24, 1, 38, 47, 646, DateTimeKind.Utc).AddTicks(6512), new DateTime(2025, 4, 23, 1, 38, 47, 646, DateTimeKind.Utc).AddTicks(6511) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCompleted", "DatePosted" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 38, 47, 646, DateTimeKind.Utc).AddTicks(6485), new DateTime(2025, 4, 23, 1, 38, 47, 646, DateTimeKind.Utc).AddTicks(6482) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCompleted", "DatePosted" },
                values: new object[] { new DateTime(2025, 4, 23, 23, 34, 48, 157, DateTimeKind.Utc).AddTicks(8295), new DateTime(2025, 4, 22, 23, 34, 48, 157, DateTimeKind.Utc).AddTicks(8294) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCompleted", "DatePosted" },
                values: new object[] { new DateTime(2025, 4, 27, 23, 34, 48, 157, DateTimeKind.Utc).AddTicks(8268), new DateTime(2025, 4, 22, 23, 34, 48, 157, DateTimeKind.Utc).AddTicks(8265) });
        }
    }
}
