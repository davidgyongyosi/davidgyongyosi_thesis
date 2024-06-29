using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace uninavigation_backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class EventPicture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "150d82a9-4f09-4f3a-9e4a-d16d515fc30d" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "150d82a9-4f09-4f3a-9e4a-d16d515fc30d");

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                table: "Events",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Picture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "684f6126-7ab3-471b-8f6a-01ef2e5c07ff", 0, "fd97547e-6bac-423c-adf4-da837a87b6db", "admin@admin.adm", true, "Super", "User", false, null, null, "SUPERUSER", "AQAAAAIAAYagAAAAEMtR4FVGV6MNtPufyDLWodaSfmbNaS7bJX/A3EkixY3+RJSNZyNjDoew7SqMgb6mKQ==", null, false, null, "1aff3eef-9d41-465a-9439-27e5c3d6a707", false, "superuser" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 1,
                columns: new[] { "ContentType", "Data" },
                values: new object[] { "", new byte[] { 0 } });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 2,
                columns: new[] { "ContentType", "Data" },
                values: new object[] { "", new byte[] { 0 } });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 3,
                columns: new[] { "ContentType", "Data" },
                values: new object[] { "", new byte[] { 0 } });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 4,
                columns: new[] { "ContentType", "Data" },
                values: new object[] { "", new byte[] { 0 } });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 5,
                columns: new[] { "ContentType", "Data" },
                values: new object[] { "", new byte[] { 0 } });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 6,
                columns: new[] { "ContentType", "Data" },
                values: new object[] { "", new byte[] { 0 } });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 7,
                columns: new[] { "ContentType", "Data" },
                values: new object[] { "", new byte[] { 0 } });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 8,
                columns: new[] { "ContentType", "Data" },
                values: new object[] { "", new byte[] { 0 } });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 9,
                columns: new[] { "ContentType", "Data" },
                values: new object[] { "", new byte[] { 0 } });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 10,
                columns: new[] { "ContentType", "Data" },
                values: new object[] { "", new byte[] { 0 } });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 11,
                columns: new[] { "ContentType", "Data" },
                values: new object[] { "", new byte[] { 0 } });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 12,
                columns: new[] { "ContentType", "Data" },
                values: new object[] { "", new byte[] { 0 } });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 13,
                columns: new[] { "ContentType", "Data" },
                values: new object[] { "", new byte[] { 0 } });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 14,
                columns: new[] { "ContentType", "Data" },
                values: new object[] { "", new byte[] { 0 } });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 15,
                columns: new[] { "ContentType", "Data" },
                values: new object[] { "", new byte[] { 0 } });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 16,
                columns: new[] { "ContentType", "Data" },
                values: new object[] { "", new byte[] { 0 } });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 17,
                columns: new[] { "ContentType", "Data" },
                values: new object[] { "", new byte[] { 0 } });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 18,
                columns: new[] { "ContentType", "Data" },
                values: new object[] { "", new byte[] { 0 } });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 19,
                columns: new[] { "ContentType", "Data" },
                values: new object[] { "", new byte[] { 0 } });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 20,
                columns: new[] { "ContentType", "Data" },
                values: new object[] { "", new byte[] { 0 } });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "684f6126-7ab3-471b-8f6a-01ef2e5c07ff" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "684f6126-7ab3-471b-8f6a-01ef2e5c07ff" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "684f6126-7ab3-471b-8f6a-01ef2e5c07ff");

            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "Events");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Picture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "150d82a9-4f09-4f3a-9e4a-d16d515fc30d", 0, "dcffb207-caa0-436a-9b0b-0d493ce50a01", "admin@admin.adm", true, "Super", "User", false, null, null, "SUPERUSER", "AQAAAAIAAYagAAAAEDfdpy+PZWBGkIMrzOqY/NEcUUzfIitRxz+oyQlGoDoSve8upiZTbKlCgDl9InTQsA==", null, false, null, "88d5ee59-a62c-45f4-9eff-14e371fb55ce", false, "superuser" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "150d82a9-4f09-4f3a-9e4a-d16d515fc30d" });
        }
    }
}
