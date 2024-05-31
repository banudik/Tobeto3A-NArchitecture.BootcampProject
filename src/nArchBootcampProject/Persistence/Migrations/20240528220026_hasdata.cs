using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class hasdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("4fd8ff7b-8bb7-4616-ab39-c286856ce898"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("83e00ad5-6265-4535-8188-9b97ffc2630b"));

            migrationBuilder.InsertData(
                table: "ApplicationStateInformations",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { (short)2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Received", null },
                    { (short)3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Approved", null },
                    { (short)4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Un Approved", null },
                    { (short)5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cancelled", null }
                });

            migrationBuilder.InsertData(
                table: "BootcampStates",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { (short)2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Not Started", null },
                    { (short)3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Started", null },
                    { (short)4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "On Hold", null },
                    { (short)5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Finished", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("51650116-dd54-4269-b4f5-9748f0d9a694"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 29, 1, 0, 26, 139, DateTimeKind.Local).AddTicks(7435), null, "pair6@pair6.com", "Banu", "Dik", "TC1246", new byte[] { 159, 69, 171, 173, 18, 215, 120, 3, 80, 177, 216, 198, 66, 2, 51, 26, 45, 14, 105, 192, 231, 227, 11, 13, 4, 18, 119, 108, 87, 43, 247, 168, 82, 182, 56, 70, 116, 143, 93, 231, 101, 112, 47, 125, 187, 246, 1, 153, 16, 112, 186, 49, 180, 92, 171, 133, 9, 98, 184, 147, 93, 8, 134, 149 }, new byte[] { 85, 20, 62, 178, 22, 168, 138, 81, 60, 121, 82, 89, 40, 200, 13, 252, 22, 21, 56, 113, 240, 99, 73, 93, 243, 74, 89, 18, 227, 93, 193, 104, 96, 32, 202, 18, 12, 196, 36, 213, 56, 57, 104, 182, 104, 236, 230, 103, 95, 239, 227, 171, 241, 130, 127, 254, 182, 85, 126, 248, 110, 180, 100, 107, 42, 254, 89, 235, 207, 129, 0, 151, 99, 205, 189, 82, 24, 232, 69, 160, 116, 145, 15, 70, 201, 11, 56, 43, 144, 215, 255, 197, 58, 35, 253, 251, 69, 105, 159, 95, 40, 180, 62, 1, 30, 111, 181, 211, 122, 75, 46, 140, 138, 5, 68, 139, 159, 19, 82, 136, 2, 172, 186, 139, 61, 11, 173, 69 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("2ed0160b-0442-4da2-af58-51f30299adb2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("51650116-dd54-4269-b4f5-9748f0d9a694") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApplicationStateInformations",
                keyColumn: "Id",
                keyValue: (short)2);

            migrationBuilder.DeleteData(
                table: "ApplicationStateInformations",
                keyColumn: "Id",
                keyValue: (short)3);

            migrationBuilder.DeleteData(
                table: "ApplicationStateInformations",
                keyColumn: "Id",
                keyValue: (short)4);

            migrationBuilder.DeleteData(
                table: "ApplicationStateInformations",
                keyColumn: "Id",
                keyValue: (short)5);

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
                table: "BootcampStates",
                keyColumn: "Id",
                keyValue: (short)5);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("2ed0160b-0442-4da2-af58-51f30299adb2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("51650116-dd54-4269-b4f5-9748f0d9a694"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("83e00ad5-6265-4535-8188-9b97ffc2630b"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 29, 0, 57, 31, 805, DateTimeKind.Local).AddTicks(6857), null, "pair6@pair6.com", "Banu", "Dik", "TC1246", new byte[] { 237, 228, 157, 227, 255, 235, 178, 226, 205, 166, 43, 127, 228, 102, 208, 228, 237, 101, 248, 202, 56, 162, 140, 154, 133, 51, 39, 72, 65, 220, 65, 226, 234, 51, 133, 74, 121, 238, 250, 175, 241, 9, 10, 233, 170, 57, 79, 177, 136, 70, 7, 238, 91, 158, 216, 96, 154, 225, 32, 22, 196, 175, 34, 196 }, new byte[] { 55, 85, 205, 157, 207, 167, 99, 212, 179, 93, 107, 227, 145, 250, 58, 146, 70, 222, 239, 125, 187, 101, 84, 228, 38, 63, 253, 43, 178, 112, 174, 92, 158, 131, 139, 62, 252, 4, 66, 137, 235, 116, 147, 242, 239, 252, 160, 43, 45, 49, 53, 16, 30, 96, 195, 188, 41, 214, 196, 118, 114, 96, 76, 11, 212, 185, 221, 177, 153, 203, 7, 244, 5, 72, 80, 130, 207, 171, 27, 117, 170, 218, 220, 22, 81, 126, 103, 19, 74, 103, 60, 144, 65, 87, 67, 39, 190, 132, 204, 230, 143, 149, 88, 232, 50, 36, 216, 65, 184, 165, 110, 199, 140, 195, 6, 35, 69, 30, 9, 194, 131, 198, 7, 37, 133, 245, 207, 144 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("4fd8ff7b-8bb7-4616-ab39-c286856ce898"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("83e00ad5-6265-4535-8188-9b97ffc2630b") });
        }
    }
}
