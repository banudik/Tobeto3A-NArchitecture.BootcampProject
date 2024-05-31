using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class may312 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("ee4dd42d-f956-46bf-af09-598db59382e7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("02762284-435f-41b7-a3d3-c00216a11a71"));

            migrationBuilder.UpdateData(
                table: "ApplicationStateInformations",
                keyColumn: "Id",
                keyValue: (short)1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 31, 17, 46, 45, 218, DateTimeKind.Utc).AddTicks(3738));

            migrationBuilder.UpdateData(
                table: "ApplicationStateInformations",
                keyColumn: "Id",
                keyValue: (short)2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 31, 17, 46, 45, 218, DateTimeKind.Utc).AddTicks(3749));

            migrationBuilder.UpdateData(
                table: "ApplicationStateInformations",
                keyColumn: "Id",
                keyValue: (short)3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 31, 17, 46, 45, 218, DateTimeKind.Utc).AddTicks(3750));

            migrationBuilder.UpdateData(
                table: "ApplicationStateInformations",
                keyColumn: "Id",
                keyValue: (short)4,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 31, 17, 46, 45, 218, DateTimeKind.Utc).AddTicks(3751));

            migrationBuilder.InsertData(
                table: "BootcampStates",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { (short)1, new DateTime(2024, 5, 31, 17, 46, 45, 221, DateTimeKind.Utc).AddTicks(6467), null, "Not Started", null },
                    { (short)2, new DateTime(2024, 5, 31, 17, 46, 45, 221, DateTimeKind.Utc).AddTicks(6470), null, "Started", null },
                    { (short)3, new DateTime(2024, 5, 31, 17, 46, 45, 221, DateTimeKind.Utc).AddTicks(6471), null, "On Hold", null },
                    { (short)4, new DateTime(2024, 5, 31, 17, 46, 45, 221, DateTimeKind.Utc).AddTicks(6472), null, "Finished", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("dbed80c8-ddf5-47b4-af05-52066abec1e0"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 31, 20, 46, 45, 224, DateTimeKind.Local).AddTicks(6655), null, "pair6@pair6.com", "Banu", "Dik", "TC1246", new byte[] { 0, 22, 79, 123, 97, 245, 184, 72, 24, 146, 86, 57, 58, 34, 237, 255, 252, 3, 195, 237, 154, 11, 162, 123, 223, 1, 142, 236, 88, 92, 107, 167, 181, 95, 116, 5, 123, 224, 166, 29, 209, 123, 59, 93, 89, 40, 47, 199, 25, 14, 251, 145, 173, 155, 152, 54, 30, 65, 32, 175, 186, 213, 205, 208 }, new byte[] { 105, 99, 138, 62, 40, 5, 194, 128, 241, 244, 246, 218, 151, 120, 141, 108, 138, 192, 162, 147, 231, 125, 14, 194, 236, 82, 151, 53, 157, 5, 220, 165, 209, 161, 190, 111, 110, 159, 69, 215, 52, 61, 112, 171, 126, 0, 129, 5, 182, 51, 147, 154, 144, 237, 146, 78, 217, 133, 238, 32, 123, 137, 94, 22, 201, 18, 128, 5, 16, 16, 228, 166, 213, 230, 37, 129, 164, 171, 143, 158, 223, 220, 240, 163, 221, 190, 248, 49, 166, 61, 245, 74, 235, 127, 239, 215, 162, 138, 142, 254, 14, 59, 209, 36, 29, 131, 106, 144, 17, 198, 214, 93, 156, 18, 48, 192, 154, 188, 195, 69, 247, 77, 12, 219, 202, 11, 40, 203 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("7f244fa0-d67b-4406-8af7-2897878098dd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("dbed80c8-ddf5-47b4-af05-52066abec1e0") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BootcampStates",
                keyColumn: "Id",
                keyValue: (short)1);

            migrationBuilder.DeleteData(
                table: "BootcampStates",
                keyColumn: "Id",
                keyValue: (short)2);

            migrationBuilder.DeleteData(
                table: "BootcampStates",
                keyColumn: "Id",
                keyValue: (short)3);

            migrationBuilder.DeleteData(
                table: "BootcampStates",
                keyColumn: "Id",
                keyValue: (short)4);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("7f244fa0-d67b-4406-8af7-2897878098dd"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("dbed80c8-ddf5-47b4-af05-52066abec1e0"));

            migrationBuilder.UpdateData(
                table: "ApplicationStateInformations",
                keyColumn: "Id",
                keyValue: (short)1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 31, 17, 41, 30, 111, DateTimeKind.Utc).AddTicks(510));

            migrationBuilder.UpdateData(
                table: "ApplicationStateInformations",
                keyColumn: "Id",
                keyValue: (short)2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 31, 17, 41, 30, 111, DateTimeKind.Utc).AddTicks(513));

            migrationBuilder.UpdateData(
                table: "ApplicationStateInformations",
                keyColumn: "Id",
                keyValue: (short)3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 31, 17, 41, 30, 111, DateTimeKind.Utc).AddTicks(514));

            migrationBuilder.UpdateData(
                table: "ApplicationStateInformations",
                keyColumn: "Id",
                keyValue: (short)4,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 31, 17, 41, 30, 111, DateTimeKind.Utc).AddTicks(515));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("02762284-435f-41b7-a3d3-c00216a11a71"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 31, 20, 41, 30, 115, DateTimeKind.Local).AddTicks(8589), null, "pair6@pair6.com", "Banu", "Dik", "TC1246", new byte[] { 215, 174, 252, 109, 215, 226, 247, 53, 39, 53, 248, 53, 240, 233, 154, 227, 228, 39, 49, 246, 135, 61, 2, 137, 205, 17, 226, 190, 98, 50, 191, 30, 119, 103, 121, 69, 14, 39, 127, 195, 18, 125, 169, 145, 116, 232, 7, 38, 116, 61, 180, 228, 138, 189, 12, 101, 59, 24, 92, 85, 55, 187, 156, 175 }, new byte[] { 228, 229, 101, 231, 156, 156, 220, 99, 13, 243, 77, 7, 46, 212, 251, 120, 151, 250, 42, 177, 197, 143, 184, 101, 193, 30, 190, 238, 118, 219, 251, 55, 2, 215, 135, 125, 127, 220, 152, 14, 63, 154, 72, 92, 54, 215, 128, 152, 224, 201, 19, 44, 12, 150, 146, 17, 8, 178, 206, 26, 191, 147, 214, 124, 155, 6, 232, 81, 52, 16, 182, 153, 1, 36, 240, 26, 29, 102, 81, 102, 144, 162, 63, 15, 143, 41, 153, 238, 252, 253, 18, 162, 134, 182, 194, 229, 229, 117, 22, 75, 123, 111, 142, 245, 16, 181, 227, 135, 71, 209, 18, 74, 27, 139, 77, 40, 174, 105, 144, 42, 103, 155, 139, 103, 2, 121, 92, 209 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("ee4dd42d-f956-46bf-af09-598db59382e7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("02762284-435f-41b7-a3d3-c00216a11a71") });
        }
    }
}
