using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class may21 : Migration
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
                values: new object[] { new Guid("f47bb1e9-77e4-4404-b580-526036c76723"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 21, 14, 55, 15, 461, DateTimeKind.Local).AddTicks(491), null, "pair6@pair6.com", "Banu", "Dik", "TC1246", new byte[] { 237, 171, 210, 176, 88, 248, 88, 184, 69, 117, 164, 136, 84, 111, 131, 2, 54, 80, 85, 0, 248, 49, 56, 6, 174, 248, 17, 70, 24, 65, 228, 109, 85, 2, 127, 18, 216, 115, 31, 199, 159, 97, 166, 103, 236, 34, 98, 42, 80, 81, 57, 206, 190, 120, 50, 78, 179, 241, 224, 44, 68, 79, 154, 16 }, new byte[] { 28, 62, 237, 76, 212, 95, 224, 67, 233, 180, 193, 161, 69, 116, 87, 146, 175, 214, 143, 153, 214, 215, 214, 199, 192, 50, 142, 79, 76, 202, 224, 233, 38, 187, 28, 113, 89, 190, 28, 87, 161, 34, 214, 183, 237, 21, 164, 113, 100, 219, 17, 148, 69, 188, 245, 6, 187, 237, 111, 24, 210, 159, 18, 106, 5, 168, 234, 129, 128, 232, 99, 241, 167, 197, 113, 45, 152, 24, 240, 27, 107, 185, 233, 140, 32, 9, 13, 6, 17, 7, 69, 241, 130, 93, 39, 176, 238, 245, 212, 153, 209, 221, 176, 4, 184, 225, 195, 167, 55, 88, 196, 143, 63, 105, 68, 204, 61, 160, 139, 58, 172, 117, 198, 177, 82, 149, 179, 78 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("340ae187-a773-482e-ba85-254e22483fc7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("f47bb1e9-77e4-4404-b580-526036c76723") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("340ae187-a773-482e-ba85-254e22483fc7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f47bb1e9-77e4-4404-b580-526036c76723"));

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
