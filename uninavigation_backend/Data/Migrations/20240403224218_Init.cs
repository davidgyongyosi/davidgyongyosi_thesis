using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace uninavigation_backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserEvents",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEvents", x => new { x.UserId, x.EventId });
                    table.ForeignKey(
                        name: "FK_UserEvents_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserEvents_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", null, "Admin", "ADMIN" },
                    { "2", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Picture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "150d82a9-4f09-4f3a-9e4a-d16d515fc30d", 0, "dcffb207-caa0-436a-9b0b-0d493ce50a01", "admin@admin.adm", true, "Super", "User", false, null, null, "SUPERUSER", "AQAAAAIAAYagAAAAEDfdpy+PZWBGkIMrzOqY/NEcUUzfIitRxz+oyQlGoDoSve8upiZTbKlCgDl9InTQsA==", null, false, null, "88d5ee59-a62c-45f4-9eff-14e371fb55ce", false, "superuser" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Description", "EndTime", "Location", "Name", "StartTime" },
                values: new object[,]
                {
                    { 1, "Description for Event 1", new DateTime(2024, 10, 4, 22, 17, 15, 0, DateTimeKind.Unspecified), "Office 109", "Event 1", new DateTime(2024, 10, 4, 18, 17, 15, 0, DateTimeKind.Unspecified) },
                    { 2, "Description for Event 2", new DateTime(2025, 1, 22, 21, 6, 2, 0, DateTimeKind.Unspecified), "Office 204", "Event 2", new DateTime(2025, 1, 22, 17, 6, 2, 0, DateTimeKind.Unspecified) },
                    { 3, "Description for Event 3", new DateTime(2024, 6, 28, 6, 10, 38, 0, DateTimeKind.Unspecified), "Focus Room 203", "Event 3", new DateTime(2024, 6, 28, 3, 10, 38, 0, DateTimeKind.Unspecified) },
                    { 4, "Description for Event 4", new DateTime(2025, 3, 18, 11, 1, 50, 0, DateTimeKind.Unspecified), "Office 103", "Event 4", new DateTime(2025, 3, 18, 9, 1, 50, 0, DateTimeKind.Unspecified) },
                    { 5, "Description for Event 5", new DateTime(2024, 7, 15, 19, 31, 5, 0, DateTimeKind.Unspecified), "Washroom", "Event 5", new DateTime(2024, 7, 15, 15, 31, 5, 0, DateTimeKind.Unspecified) },
                    { 6, "Description for Event 6", new DateTime(2024, 5, 3, 16, 1, 40, 0, DateTimeKind.Unspecified), "Office 110", "Event 6", new DateTime(2024, 5, 3, 13, 1, 40, 0, DateTimeKind.Unspecified) },
                    { 7, "Description for Event 7", new DateTime(2024, 9, 27, 20, 25, 15, 0, DateTimeKind.Unspecified), "Maple Meeting Room", "Event 7", new DateTime(2024, 9, 27, 15, 25, 15, 0, DateTimeKind.Unspecified) },
                    { 8, "Description for Event 8", new DateTime(2024, 4, 1, 10, 27, 47, 0, DateTimeKind.Unspecified), "Oak Meeting Room", "Event 8", new DateTime(2024, 4, 1, 5, 27, 47, 0, DateTimeKind.Unspecified) },
                    { 9, "Description for Event 9", new DateTime(2024, 10, 3, 5, 36, 20, 0, DateTimeKind.Unspecified), "Focus Room 101", "Event 9", new DateTime(2024, 10, 3, 4, 36, 20, 0, DateTimeKind.Unspecified) },
                    { 10, "Description for Event 10", new DateTime(2024, 7, 27, 14, 0, 26, 0, DateTimeKind.Unspecified), "Focus Room 201", "Event 10", new DateTime(2024, 7, 27, 13, 0, 26, 0, DateTimeKind.Unspecified) },
                    { 11, "Description for Event 11", new DateTime(2024, 10, 12, 6, 2, 5, 0, DateTimeKind.Unspecified), "Huddle 201", "Event 11", new DateTime(2024, 10, 12, 3, 2, 5, 0, DateTimeKind.Unspecified) },
                    { 12, "Description for Event 12", new DateTime(2024, 6, 6, 3, 41, 53, 0, DateTimeKind.Unspecified), "Cedar Meeting Room", "Event 12", new DateTime(2024, 6, 5, 23, 41, 53, 0, DateTimeKind.Unspecified) },
                    { 13, "Description for Event 13", new DateTime(2024, 10, 11, 3, 48, 19, 0, DateTimeKind.Unspecified), "Focus Room 104", "Event 13", new DateTime(2024, 10, 11, 1, 48, 19, 0, DateTimeKind.Unspecified) },
                    { 14, "Description for Event 14", new DateTime(2024, 7, 19, 14, 2, 21, 0, DateTimeKind.Unspecified), "Print Point 100", "Event 14", new DateTime(2024, 7, 19, 12, 2, 21, 0, DateTimeKind.Unspecified) },
                    { 15, "Description for Event 15", new DateTime(2025, 2, 21, 4, 24, 6, 0, DateTimeKind.Unspecified), "Print Point 200", "Event 15", new DateTime(2025, 2, 20, 23, 24, 6, 0, DateTimeKind.Unspecified) },
                    { 16, "Description for Event 16", new DateTime(2024, 4, 26, 17, 45, 12, 0, DateTimeKind.Unspecified), "Elm Meeting Room", "Event 16", new DateTime(2024, 4, 26, 14, 45, 12, 0, DateTimeKind.Unspecified) },
                    { 17, "Description for Event 17", new DateTime(2024, 4, 14, 13, 53, 33, 0, DateTimeKind.Unspecified), "Juniper Meeting Room", "Event 17", new DateTime(2024, 4, 14, 8, 53, 33, 0, DateTimeKind.Unspecified) },
                    { 18, "Description for Event 18", new DateTime(2024, 12, 11, 15, 36, 25, 0, DateTimeKind.Unspecified), "Office 112", "Event 18", new DateTime(2024, 12, 11, 14, 36, 25, 0, DateTimeKind.Unspecified) },
                    { 19, "Description for Event 19", new DateTime(2024, 11, 7, 6, 20, 14, 0, DateTimeKind.Unspecified), "Kitchen", "Event 19", new DateTime(2024, 11, 7, 4, 20, 14, 0, DateTimeKind.Unspecified) },
                    { 20, "Description for Event 20", new DateTime(2024, 6, 7, 8, 31, 9, 0, DateTimeKind.Unspecified), "Spruce Meeting Room", "Event 20", new DateTime(2024, 6, 7, 5, 31, 9, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "150d82a9-4f09-4f3a-9e4a-d16d515fc30d" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserEvents_EventId",
                table: "UserEvents",
                column: "EventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "UserEvents");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
