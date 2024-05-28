using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class may27oglen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("86f03eab-f67e-4eb5-b690-ad125579ad9c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c8a96723-faee-4587-b76a-849d866912fe"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("72edc281-8a58-46d1-9f66-7d71a45d4161"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 27, 17, 35, 50, 180, DateTimeKind.Local).AddTicks(284), null, "pair6@pair6.com", "Banu", "Dik", "TC1246", new byte[] { 203, 45, 250, 182, 198, 7, 73, 15, 149, 181, 40, 47, 43, 248, 221, 41, 193, 28, 113, 162, 208, 211, 141, 123, 180, 177, 61, 185, 11, 219, 53, 216, 102, 25, 52, 191, 156, 176, 200, 109, 235, 254, 10, 164, 82, 179, 190, 139, 77, 69, 10, 24, 148, 150, 186, 29, 188, 54, 221, 131, 142, 86, 37, 63 }, new byte[] { 206, 85, 122, 70, 211, 75, 58, 74, 69, 81, 59, 125, 239, 209, 57, 42, 137, 179, 116, 244, 25, 127, 82, 149, 168, 171, 69, 122, 84, 216, 100, 17, 71, 58, 88, 117, 36, 248, 226, 25, 122, 58, 72, 243, 212, 232, 164, 193, 43, 46, 120, 86, 72, 78, 136, 110, 223, 37, 236, 23, 252, 254, 3, 35, 1, 56, 86, 155, 77, 43, 187, 169, 49, 59, 168, 58, 71, 71, 196, 62, 0, 80, 182, 183, 85, 8, 221, 188, 132, 243, 251, 213, 208, 212, 14, 138, 218, 154, 234, 65, 213, 148, 39, 188, 96, 78, 95, 133, 82, 170, 61, 152, 56, 60, 205, 1, 177, 200, 213, 183, 131, 13, 236, 127, 168, 85, 127, 83 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("86c84114-a52f-4d63-be4e-e560e6ac6e57"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("72edc281-8a58-46d1-9f66-7d71a45d4161") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("86c84114-a52f-4d63-be4e-e560e6ac6e57"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("72edc281-8a58-46d1-9f66-7d71a45d4161"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("c8a96723-faee-4587-b76a-849d866912fe"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 26, 17, 14, 48, 148, DateTimeKind.Local).AddTicks(2710), null, "pair6@pair6.com", "Banu", "Dik", "TC1246", new byte[] { 5, 210, 89, 74, 164, 176, 102, 205, 89, 158, 96, 112, 69, 81, 81, 190, 70, 152, 208, 48, 7, 26, 77, 160, 234, 50, 75, 141, 246, 153, 166, 23, 254, 215, 242, 134, 26, 63, 38, 80, 197, 225, 69, 112, 52, 166, 94, 39, 165, 87, 149, 247, 137, 53, 138, 244, 40, 125, 9, 229, 52, 176, 208, 228 }, new byte[] { 250, 95, 18, 44, 120, 124, 213, 83, 161, 58, 101, 173, 107, 247, 114, 122, 203, 125, 71, 5, 166, 201, 171, 231, 189, 187, 253, 77, 201, 79, 104, 40, 195, 120, 235, 107, 85, 90, 99, 253, 158, 182, 252, 191, 31, 197, 185, 148, 23, 62, 23, 55, 91, 76, 17, 198, 44, 249, 151, 246, 201, 59, 195, 145, 144, 174, 152, 84, 247, 217, 225, 113, 82, 73, 9, 102, 64, 20, 81, 90, 234, 226, 217, 107, 117, 26, 182, 218, 110, 127, 112, 161, 56, 221, 78, 248, 195, 138, 113, 20, 107, 116, 149, 196, 113, 241, 90, 97, 79, 151, 151, 16, 164, 85, 139, 138, 20, 19, 16, 194, 119, 55, 193, 3, 179, 233, 116, 45 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("86f03eab-f67e-4eb5-b690-ad125579ad9c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("c8a96723-faee-4587-b76a-849d866912fe") });
        }
    }
}
