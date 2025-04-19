using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace KindQuestBE.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    EmergencyContact = table.Column<long>(type: "bigint", nullable: false),
                    ProfilePic = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ProjectName = table.Column<string>(type: "text", nullable: true),
                    ProjectDescription = table.Column<string>(type: "text", nullable: true),
                    DatePosted = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateCompleted = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: true),
                    ProjectImg = table.Column<string>(type: "text", nullable: true),
                    TaskList = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProjectId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    JobName = table.Column<string>(type: "text", nullable: true),
                    JobDescription = table.Column<string>(type: "text", nullable: true),
                    DatePosted = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateCompleted = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    ProjectId1 = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jobs_Projects_ProjectId1",
                        column: x => x.ProjectId1,
                        principalTable: "Projects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Jobs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProjects",
                columns: table => new
                {
                    VolunteeredProjectsId = table.Column<int>(type: "integer", nullable: false),
                    VolunteersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProjects", x => new { x.VolunteeredProjectsId, x.VolunteersId });
                    table.ForeignKey(
                        name: "FK_UserProjects_Projects_VolunteeredProjectsId",
                        column: x => x.VolunteeredProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProjects_Users_VolunteersId",
                        column: x => x.VolunteersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "EmergencyContact", "FirstName", "LastName", "ProfilePic", "Uid" },
                values: new object[] { 1, "alex@example.com", 1234567890L, "Alex", "Smith", "https://example.com/alex.jpg", "abc123" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "DateCompleted", "DatePosted", "IsCompleted", "Location", "ProjectDescription", "ProjectImg", "ProjectName", "TaskList", "UserId" },
                values: new object[] { 1, new DateTime(2025, 4, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Local), false, "Central Park", "Help clean up the local park.", "https://example.com/cleanup.jpg", "Neighborhood Cleanup", null, 1 });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "DateCompleted", "DatePosted", "IsCompleted", "JobDescription", "JobName", "ProjectId", "ProjectId1", "UserId" },
                values: new object[] { 1, new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Local), false, "Collect litter from the ground.", "Pick up trash", 1, null, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_ProjectId",
                table: "Jobs",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_ProjectId1",
                table: "Jobs",
                column: "ProjectId1");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_UserId",
                table: "Jobs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UserId",
                table: "Projects",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProjects_VolunteersId",
                table: "UserProjects",
                column: "VolunteersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "UserProjects");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
