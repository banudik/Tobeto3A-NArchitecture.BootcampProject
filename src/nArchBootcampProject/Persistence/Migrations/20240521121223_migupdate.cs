using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("26b68322-ded4-48e1-89b4-98e9aefa0342"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c0f27fe8-6047-4a13-befc-5ca7d301969a"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("a23cc1e3-9191-4b3d-9b6e-2b3f90ca0a51"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 21, 15, 12, 23, 460, DateTimeKind.Local).AddTicks(7270), null, "pair6@pair6.com", "Banu", "Dik", "TC1246", new byte[] { 87, 47, 236, 94, 78, 157, 109, 109, 148, 150, 239, 249, 201, 183, 19, 216, 104, 125, 18, 219, 63, 134, 84, 194, 93, 231, 108, 111, 141, 117, 72, 20, 106, 122, 145, 49, 88, 175, 73, 110, 23, 44, 41, 19, 169, 176, 187, 119, 229, 230, 245, 71, 97, 7, 63, 167, 99, 206, 90, 56, 70, 236, 212, 71 }, new byte[] { 205, 87, 8, 194, 70, 176, 77, 55, 0, 151, 217, 38, 26, 61, 145, 135, 12, 215, 178, 242, 63, 215, 7, 155, 113, 246, 162, 113, 116, 127, 5, 176, 55, 104, 201, 186, 119, 72, 16, 160, 95, 96, 137, 110, 75, 114, 178, 251, 226, 216, 98, 224, 101, 136, 226, 68, 105, 206, 42, 227, 135, 52, 21, 115, 240, 131, 193, 43, 41, 251, 96, 39, 80, 156, 80, 68, 248, 180, 226, 215, 2, 115, 5, 105, 41, 254, 48, 47, 252, 34, 62, 232, 53, 226, 45, 19, 108, 87, 240, 228, 134, 188, 213, 4, 73, 1, 38, 203, 31, 35, 223, 204, 25, 151, 77, 126, 8, 246, 231, 50, 232, 130, 157, 13, 180, 26, 152, 128 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("abb2ab40-c41c-47dc-a387-a7ac3e00dcf3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("a23cc1e3-9191-4b3d-9b6e-2b3f90ca0a51") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("abb2ab40-c41c-47dc-a387-a7ac3e00dcf3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a23cc1e3-9191-4b3d-9b6e-2b3f90ca0a51"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("c0f27fe8-6047-4a13-befc-5ca7d301969a"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 19, 0, 33, 59, 993, DateTimeKind.Local).AddTicks(6475), null, "pair6@pair6.com", "Banu", "Dik", "TC1246", new byte[] { 78, 16, 245, 24, 34, 227, 83, 124, 114, 134, 111, 13, 162, 245, 179, 92, 103, 247, 168, 0, 118, 86, 58, 93, 136, 218, 45, 42, 156, 136, 190, 154, 26, 150, 86, 218, 65, 197, 80, 222, 124, 250, 190, 251, 5, 214, 231, 92, 246, 1, 7, 204, 180, 141, 154, 21, 108, 219, 20, 6, 203, 86, 85, 178 }, new byte[] { 63, 133, 190, 230, 69, 217, 137, 225, 68, 226, 218, 169, 135, 47, 127, 128, 112, 159, 94, 138, 116, 210, 79, 241, 168, 47, 139, 211, 166, 196, 246, 210, 57, 184, 10, 34, 139, 130, 164, 201, 114, 164, 252, 81, 202, 157, 110, 46, 205, 227, 103, 225, 123, 31, 60, 90, 167, 83, 137, 204, 124, 106, 15, 17, 133, 228, 162, 177, 114, 182, 151, 231, 251, 175, 208, 168, 147, 230, 83, 125, 28, 17, 197, 229, 227, 141, 21, 97, 29, 113, 135, 49, 194, 63, 139, 143, 237, 33, 89, 213, 42, 87, 119, 223, 16, 205, 24, 188, 234, 91, 252, 41, 112, 41, 207, 46, 204, 217, 142, 250, 23, 222, 139, 169, 169, 219, 249, 128 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("26b68322-ded4-48e1-89b4-98e9aefa0342"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("c0f27fe8-6047-4a13-befc-5ca7d301969a") });
        }
    }
}
