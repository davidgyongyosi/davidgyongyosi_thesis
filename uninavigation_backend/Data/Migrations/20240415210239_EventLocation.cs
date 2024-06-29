using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace uninavigation_backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class EventLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "684f6126-7ab3-471b-8f6a-01ef2e5c07ff" });

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "684f6126-7ab3-471b-8f6a-01ef2e5c07ff");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Events");

            migrationBuilder.AddColumn<string>(
                name: "LocationId",
                table: "Events",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Picture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7921070a-0641-48ad-bedc-04a7d3f86f64", 0, "b6505d6e-6403-41a1-81b8-064caee0e1aa", "admin@admin.adm", true, "Super", "User", false, null, null, "SUPERUSER", "AQAAAAIAAYagAAAAEM2eN1YNXLsEAER1d5UTLvmZahOtp+2MVJ0GsRYjyX305FIpLqID3tOOqhEiV+btQg==", null, false, null, "0db7ec6b-0942-4f1a-bd4c-46f1b375891c", false, "superuser" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "7921070a-0641-48ad-bedc-04a7d3f86f64" });

            migrationBuilder.CreateIndex(
                name: "IX_Events_LocationId",
                table: "Events",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Locations_LocationId",
                table: "Events",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Locations_LocationId",
                table: "Events");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Events_LocationId",
                table: "Events");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "7921070a-0641-48ad-bedc-04a7d3f86f64" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7921070a-0641-48ad-bedc-04a7d3f86f64");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Events");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Picture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "684f6126-7ab3-471b-8f6a-01ef2e5c07ff", 0, "fd97547e-6bac-423c-adf4-da837a87b6db", "admin@admin.adm", true, "Super", "User", false, null, null, "SUPERUSER", "AQAAAAIAAYagAAAAEMtR4FVGV6MNtPufyDLWodaSfmbNaS7bJX/A3EkixY3+RJSNZyNjDoew7SqMgb6mKQ==", null, false, null, "1aff3eef-9d41-465a-9439-27e5c3d6a707", false, "superuser" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "ContentType", "Data", "Description", "EndTime", "Location", "Name", "StartTime" },
                values: new object[,]
                {
                    { 1, "", new byte[] { 0 }, "Description for Event 1", new DateTime(2024, 10, 4, 22, 17, 15, 0, DateTimeKind.Unspecified), "Office 109", "Event 1", new DateTime(2024, 10, 4, 18, 17, 15, 0, DateTimeKind.Unspecified) },
                    { 2, "", new byte[] { 0 }, "Description for Event 2", new DateTime(2025, 1, 22, 21, 6, 2, 0, DateTimeKind.Unspecified), "Office 204", "Event 2", new DateTime(2025, 1, 22, 17, 6, 2, 0, DateTimeKind.Unspecified) },
                    { 3, "", new byte[] { 0 }, "Description for Event 3", new DateTime(2024, 6, 28, 6, 10, 38, 0, DateTimeKind.Unspecified), "Focus Room 203", "Event 3", new DateTime(2024, 6, 28, 3, 10, 38, 0, DateTimeKind.Unspecified) },
                    { 4, "", new byte[] { 0 }, "Description for Event 4", new DateTime(2025, 3, 18, 11, 1, 50, 0, DateTimeKind.Unspecified), "Office 103", "Event 4", new DateTime(2025, 3, 18, 9, 1, 50, 0, DateTimeKind.Unspecified) },
                    { 5, "", new byte[] { 0 }, "Description for Event 5", new DateTime(2024, 7, 15, 19, 31, 5, 0, DateTimeKind.Unspecified), "Washroom", "Event 5", new DateTime(2024, 7, 15, 15, 31, 5, 0, DateTimeKind.Unspecified) },
                    { 6, "", new byte[] { 0 }, "Description for Event 6", new DateTime(2024, 5, 3, 16, 1, 40, 0, DateTimeKind.Unspecified), "Office 110", "Event 6", new DateTime(2024, 5, 3, 13, 1, 40, 0, DateTimeKind.Unspecified) },
                    { 7, "", new byte[] { 0 }, "Description for Event 7", new DateTime(2024, 9, 27, 20, 25, 15, 0, DateTimeKind.Unspecified), "Maple Meeting Room", "Event 7", new DateTime(2024, 9, 27, 15, 25, 15, 0, DateTimeKind.Unspecified) },
                    { 8, "", new byte[] { 0 }, "Description for Event 8", new DateTime(2024, 4, 1, 10, 27, 47, 0, DateTimeKind.Unspecified), "Oak Meeting Room", "Event 8", new DateTime(2024, 4, 1, 5, 27, 47, 0, DateTimeKind.Unspecified) },
                    { 9, "", new byte[] { 0 }, "Description for Event 9", new DateTime(2024, 10, 3, 5, 36, 20, 0, DateTimeKind.Unspecified), "Focus Room 101", "Event 9", new DateTime(2024, 10, 3, 4, 36, 20, 0, DateTimeKind.Unspecified) },
                    { 10, "", new byte[] { 0 }, "Description for Event 10", new DateTime(2024, 7, 27, 14, 0, 26, 0, DateTimeKind.Unspecified), "Focus Room 201", "Event 10", new DateTime(2024, 7, 27, 13, 0, 26, 0, DateTimeKind.Unspecified) },
                    { 11, "", new byte[] { 0 }, "Description for Event 11", new DateTime(2024, 10, 12, 6, 2, 5, 0, DateTimeKind.Unspecified), "Huddle 201", "Event 11", new DateTime(2024, 10, 12, 3, 2, 5, 0, DateTimeKind.Unspecified) },
                    { 12, "", new byte[] { 0 }, "Description for Event 12", new DateTime(2024, 6, 6, 3, 41, 53, 0, DateTimeKind.Unspecified), "Cedar Meeting Room", "Event 12", new DateTime(2024, 6, 5, 23, 41, 53, 0, DateTimeKind.Unspecified) },
                    { 13, "", new byte[] { 0 }, "Description for Event 13", new DateTime(2024, 10, 11, 3, 48, 19, 0, DateTimeKind.Unspecified), "Focus Room 104", "Event 13", new DateTime(2024, 10, 11, 1, 48, 19, 0, DateTimeKind.Unspecified) },
                    { 14, "", new byte[] { 0 }, "Description for Event 14", new DateTime(2024, 7, 19, 14, 2, 21, 0, DateTimeKind.Unspecified), "Print Point 100", "Event 14", new DateTime(2024, 7, 19, 12, 2, 21, 0, DateTimeKind.Unspecified) },
                    { 15, "", new byte[] { 0 }, "Description for Event 15", new DateTime(2025, 2, 21, 4, 24, 6, 0, DateTimeKind.Unspecified), "Print Point 200", "Event 15", new DateTime(2025, 2, 20, 23, 24, 6, 0, DateTimeKind.Unspecified) },
                    { 16, "", new byte[] { 0 }, "Description for Event 16", new DateTime(2024, 4, 26, 17, 45, 12, 0, DateTimeKind.Unspecified), "Elm Meeting Room", "Event 16", new DateTime(2024, 4, 26, 14, 45, 12, 0, DateTimeKind.Unspecified) },
                    { 17, "", new byte[] { 0 }, "Description for Event 17", new DateTime(2024, 4, 14, 13, 53, 33, 0, DateTimeKind.Unspecified), "Juniper Meeting Room", "Event 17", new DateTime(2024, 4, 14, 8, 53, 33, 0, DateTimeKind.Unspecified) },
                    { 18, "", new byte[] { 0 }, "Description for Event 18", new DateTime(2024, 12, 11, 15, 36, 25, 0, DateTimeKind.Unspecified), "Office 112", "Event 18", new DateTime(2024, 12, 11, 14, 36, 25, 0, DateTimeKind.Unspecified) },
                    { 19, "", new byte[] { 0 }, "Description for Event 19", new DateTime(2024, 11, 7, 6, 20, 14, 0, DateTimeKind.Unspecified), "Kitchen", "Event 19", new DateTime(2024, 11, 7, 4, 20, 14, 0, DateTimeKind.Unspecified) },
                    { 20, "", new byte[] { 0 }, "Description for Event 20", new DateTime(2024, 6, 7, 8, 31, 9, 0, DateTimeKind.Unspecified), "Spruce Meeting Room", "Event 20", new DateTime(2024, 6, 7, 5, 31, 9, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "684f6126-7ab3-471b-8f6a-01ef2e5c07ff" });
        }
    }
}
