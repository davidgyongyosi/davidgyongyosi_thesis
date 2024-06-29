using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace uninavigation_backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class ArContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "7921070a-0641-48ad-bedc-04a7d3f86f64" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7921070a-0641-48ad-bedc-04a7d3f86f64");

            migrationBuilder.AddColumn<int>(
                name: "ar_ContentId",
                table: "Locations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Ar_Contents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Elevation = table.Column<int>(type: "int", nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ar_Contents", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3", null, "Student", "STUDENT" },
                    { "4", null, "Visitor", "VISITOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Picture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d0663958-0022-4a9c-9b5a-7d745842eb7b", 0, "9cd1068b-3f9e-4890-b15a-4a0651b8b10f", "admin@admin.adm", true, "Super", "User", false, null, null, "SUPERUSER", "AQAAAAIAAYagAAAAEBro+5HGyQl3pPPljkK9BX7wmsdotDgIp5rLrO4pCXBxCcmZaSw221MH+H/19n7y7g==", null, false, null, "4469cb15-e266-4ccf-9b9f-63f2787d854f", false, "superuser" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "d0663958-0022-4a9c-9b5a-7d745842eb7b" });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_ar_ContentId",
                table: "Locations",
                column: "ar_ContentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Ar_Contents_ar_ContentId",
                table: "Locations",
                column: "ar_ContentId",
                principalTable: "Ar_Contents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Ar_Contents_ar_ContentId",
                table: "Locations");

            migrationBuilder.DropTable(
                name: "Ar_Contents");

            migrationBuilder.DropIndex(
                name: "IX_Locations_ar_ContentId",
                table: "Locations");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "d0663958-0022-4a9c-9b5a-7d745842eb7b" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d0663958-0022-4a9c-9b5a-7d745842eb7b");

            migrationBuilder.DropColumn(
                name: "ar_ContentId",
                table: "Locations");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Picture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7921070a-0641-48ad-bedc-04a7d3f86f64", 0, "b6505d6e-6403-41a1-81b8-064caee0e1aa", "admin@admin.adm", true, "Super", "User", false, null, null, "SUPERUSER", "AQAAAAIAAYagAAAAEM2eN1YNXLsEAER1d5UTLvmZahOtp+2MVJ0GsRYjyX305FIpLqID3tOOqhEiV+btQg==", null, false, null, "0db7ec6b-0942-4f1a-bd4c-46f1b375891c", false, "superuser" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "7921070a-0641-48ad-bedc-04a7d3f86f64" });
        }
    }
}
