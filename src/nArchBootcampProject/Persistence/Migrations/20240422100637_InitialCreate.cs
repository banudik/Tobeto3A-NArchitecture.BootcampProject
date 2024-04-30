using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("0ca1114b-10c7-4dd2-a408-0148174809b3"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 22, 13, 6, 36, 649, DateTimeKind.Local).AddTicks(9854), null, "pair6@pair6.com", "Banu", "Dik", "TC1246", new byte[] { 210, 200, 17, 35, 231, 69, 71, 250, 128, 233, 55, 68, 192, 18, 1, 141, 108, 219, 157, 104, 167, 216, 217, 122, 180, 196, 135, 152, 31, 215, 126, 248, 253, 253, 165, 178, 205, 243, 78, 156, 205, 201, 167, 255, 99, 12, 159, 128, 91, 37, 171, 155, 120, 136, 185, 178, 195, 178, 159, 204, 58, 87, 80, 131 }, new byte[] { 51, 200, 244, 175, 79, 115, 139, 32, 170, 139, 160, 56, 104, 55, 7, 31, 3, 94, 153, 213, 13, 224, 211, 228, 34, 114, 245, 121, 214, 120, 107, 127, 100, 29, 144, 86, 64, 180, 229, 190, 190, 102, 206, 119, 121, 15, 226, 82, 128, 224, 151, 113, 49, 133, 129, 115, 167, 179, 186, 146, 64, 103, 158, 188, 253, 154, 180, 125, 192, 59, 52, 239, 156, 103, 137, 149, 75, 202, 87, 214, 184, 143, 136, 234, 140, 56, 231, 171, 85, 37, 27, 38, 101, 57, 20, 190, 180, 91, 196, 53, 228, 196, 204, 113, 206, 139, 251, 1, 212, 23, 231, 59, 164, 176, 248, 80, 23, 133, 179, 101, 50, 209, 4, 239, 107, 172, 61, 38 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("c1d01347-068d-4dd8-bab6-fafd908c2215"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("0ca1114b-10c7-4dd2-a408-0148174809b3") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("c1d01347-068d-4dd8-bab6-fafd908c2215"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0ca1114b-10c7-4dd2-a408-0148174809b3"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("683f8b4c-e916-4bc5-877e-60802c320bce"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 15, 22, 49, 52, 919, DateTimeKind.Local).AddTicks(3061), null, "banudik_34@hotmail.com", "Banu", "Dik", "TC1246", new byte[] { 31, 44, 237, 200, 58, 65, 42, 28, 175, 255, 47, 113, 13, 28, 53, 1, 53, 195, 220, 115, 36, 130, 54, 88, 138, 28, 215, 131, 114, 92, 3, 7, 201, 26, 0, 14, 227, 94, 59, 233, 35, 248, 82, 59, 242, 88, 246, 229, 126, 41, 194, 248, 226, 6, 191, 22, 188, 134, 168, 70, 7, 212, 108, 146 }, new byte[] { 20, 171, 153, 106, 248, 162, 168, 132, 66, 4, 83, 16, 213, 97, 10, 48, 116, 250, 73, 209, 37, 239, 18, 43, 225, 219, 255, 45, 16, 129, 65, 110, 142, 36, 235, 1, 191, 119, 65, 92, 219, 101, 134, 206, 156, 60, 22, 158, 17, 21, 220, 1, 18, 92, 188, 75, 107, 72, 60, 243, 162, 235, 155, 79, 223, 23, 73, 130, 205, 31, 3, 245, 160, 22, 243, 187, 240, 70, 130, 228, 52, 77, 206, 73, 118, 74, 120, 67, 117, 158, 208, 144, 17, 177, 104, 83, 65, 29, 236, 116, 221, 236, 79, 168, 208, 79, 143, 141, 101, 211, 47, 194, 118, 89, 102, 198, 155, 246, 137, 218, 249, 0, 90, 220, 227, 252, 226, 84 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("60f389ac-e001-41d7-8833-ba7cc5b01323"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("683f8b4c-e916-4bc5-877e-60802c320bce") });
        }
    }
}
