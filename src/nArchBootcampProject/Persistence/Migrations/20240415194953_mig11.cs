using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("d5aee071-c17a-48a5-91bc-ceb31a745d42"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("030581f7-0a05-4ecd-b2cf-fa76e0502522"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("683f8b4c-e916-4bc5-877e-60802c320bce"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 15, 22, 49, 52, 919, DateTimeKind.Local).AddTicks(3061), null, "banudik_34@hotmail.com", "Banu", "Dik", "TC1246", new byte[] { 31, 44, 237, 200, 58, 65, 42, 28, 175, 255, 47, 113, 13, 28, 53, 1, 53, 195, 220, 115, 36, 130, 54, 88, 138, 28, 215, 131, 114, 92, 3, 7, 201, 26, 0, 14, 227, 94, 59, 233, 35, 248, 82, 59, 242, 88, 246, 229, 126, 41, 194, 248, 226, 6, 191, 22, 188, 134, 168, 70, 7, 212, 108, 146 }, new byte[] { 20, 171, 153, 106, 248, 162, 168, 132, 66, 4, 83, 16, 213, 97, 10, 48, 116, 250, 73, 209, 37, 239, 18, 43, 225, 219, 255, 45, 16, 129, 65, 110, 142, 36, 235, 1, 191, 119, 65, 92, 219, 101, 134, 206, 156, 60, 22, 158, 17, 21, 220, 1, 18, 92, 188, 75, 107, 72, 60, 243, 162, 235, 155, 79, 223, 23, 73, 130, 205, 31, 3, 245, 160, 22, 243, 187, 240, 70, 130, 228, 52, 77, 206, 73, 118, 74, 120, 67, 117, 158, 208, 144, 17, 177, 104, 83, 65, 29, 236, 116, 221, 236, 79, 168, 208, 79, 143, 141, 101, 211, 47, 194, 118, 89, 102, 198, 155, 246, 137, 218, 249, 0, 90, 220, 227, 252, 226, 84 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("60f389ac-e001-41d7-8833-ba7cc5b01323"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("683f8b4c-e916-4bc5-877e-60802c320bce") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("60f389ac-e001-41d7-8833-ba7cc5b01323"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("683f8b4c-e916-4bc5-877e-60802c320bce"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("030581f7-0a05-4ecd-b2cf-fa76e0502522"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 15, 22, 47, 27, 353, DateTimeKind.Local).AddTicks(4059), null, "banudik_34@hotmail.com", "Banu", "Dik", "TC1246", new byte[] { 68, 156, 136, 223, 42, 151, 129, 198, 173, 61, 250, 103, 90, 77, 144, 16, 33, 170, 143, 93, 51, 235, 180, 143, 148, 97, 94, 121, 250, 43, 163, 101, 158, 238, 175, 222, 174, 208, 85, 56, 231, 132, 182, 215, 125, 99, 163, 73, 36, 53, 140, 18, 14, 173, 13, 221, 84, 105, 168, 200, 90, 104, 155, 89 }, new byte[] { 54, 66, 191, 39, 34, 23, 218, 59, 16, 168, 21, 187, 199, 218, 203, 238, 31, 14, 234, 4, 49, 172, 202, 166, 41, 10, 208, 145, 108, 18, 30, 29, 243, 45, 96, 74, 75, 72, 28, 19, 82, 180, 122, 224, 47, 145, 24, 59, 224, 85, 34, 145, 114, 231, 253, 109, 74, 215, 54, 179, 244, 197, 78, 120, 251, 146, 236, 160, 76, 182, 198, 104, 203, 143, 0, 212, 139, 10, 232, 233, 121, 217, 69, 190, 174, 228, 82, 141, 95, 229, 70, 206, 144, 26, 230, 96, 190, 100, 53, 200, 180, 29, 175, 210, 203, 238, 246, 188, 205, 206, 168, 216, 174, 202, 184, 133, 246, 88, 17, 215, 104, 78, 164, 24, 134, 115, 182, 222 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("d5aee071-c17a-48a5-91bc-ceb31a745d42"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("030581f7-0a05-4ecd-b2cf-fa76e0502522") });
        }
    }
}
