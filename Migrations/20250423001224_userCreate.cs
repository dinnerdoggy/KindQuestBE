using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KindQuestBE.Migrations
{
    /// <inheritdoc />
    public partial class userCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCompleted", "DatePosted" },
                values: new object[] { new DateTime(2025, 4, 24, 0, 12, 24, 369, DateTimeKind.Utc).AddTicks(3856), new DateTime(2025, 4, 23, 0, 12, 24, 369, DateTimeKind.Utc).AddTicks(3856) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCompleted", "DatePosted" },
                values: new object[] { new DateTime(2025, 4, 28, 0, 12, 24, 369, DateTimeKind.Utc).AddTicks(3831), new DateTime(2025, 4, 23, 0, 12, 24, 369, DateTimeKind.Utc).AddTicks(3826) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
