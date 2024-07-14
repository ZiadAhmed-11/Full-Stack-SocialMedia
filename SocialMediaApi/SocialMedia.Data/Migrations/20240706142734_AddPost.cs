using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMedia.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("47b857e8-3a0e-422f-a560-99b4a0fcf61b"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Age", "Bio", "BirthDay", "City", "ConcurrencyStamp", "Country", "CoverImageUrl", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageUrl", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("9784f712-85af-4dec-97f0-e0f202fa131d"), 0, 25, "This is a default user.", new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Default City", "7bb8ffcb-e560-42ba-befb-9706b2b58ae7", "Default Country", null, "defaultuser@example.com", true, "Default", 0, "User", false, null, "DEFAULTUSER@EXAMPLE.COM", "DEFAULTUSER", "AQAAAAIAAYagAAAAEGZeUSW19QMgbpYVarXwGzErR7jOOO7HEj9Ef88JJSzSDFLQZXlR8teDCCOQhoCBrQ==", null, false, null, "", false, "defaultuser" });*/
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9784f712-85af-4dec-97f0-e0f202fa131d"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Age", "Bio", "BirthDay", "City", "ConcurrencyStamp", "Country", "CoverImageUrl", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageUrl", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("47b857e8-3a0e-422f-a560-99b4a0fcf61b"), 0, 25, "This is a default user.", new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Default City", "e6f59bf6-9508-49e6-b277-7f0a97cb554e", "Default Country", null, "defaultuser@example.com", true, "Default", 0, "User", false, null, "DEFAULTUSER@EXAMPLE.COM", "DEFAULTUSER", "AQAAAAIAAYagAAAAEBERXEKyjfvuDSlax6/+rAv0poFCaQloOSJsc4SUlmILbM4x4aWrdE0726q6l1anfg==", null, false, null, "", false, "defaultuser" });
        }
    }
}
