using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migElastic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("90e0542e-baa0-48fb-889f-4a80f487d782"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a19eb723-158a-4444-ba01-8deeed57720f"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("f0100b67-7bac-4b31-9e0e-523c6b749367"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 25, 16, 28, 56, 120, DateTimeKind.Local).AddTicks(6650), null, "pair6@pair6.com", "Banu", "Dik", "TC1246", new byte[] { 22, 202, 206, 148, 135, 51, 249, 8, 173, 61, 43, 151, 17, 40, 206, 179, 117, 209, 64, 199, 247, 99, 52, 57, 210, 155, 196, 80, 6, 149, 27, 81, 141, 199, 240, 162, 98, 32, 234, 118, 39, 94, 37, 28, 96, 63, 184, 13, 116, 240, 158, 127, 50, 81, 133, 224, 71, 11, 224, 244, 109, 141, 29, 41 }, new byte[] { 23, 66, 86, 31, 98, 26, 83, 34, 66, 96, 92, 103, 218, 135, 175, 9, 184, 213, 107, 160, 1, 105, 132, 146, 31, 82, 192, 244, 65, 125, 36, 193, 12, 255, 197, 192, 116, 40, 180, 144, 219, 250, 202, 94, 220, 219, 66, 1, 216, 166, 145, 117, 200, 126, 71, 246, 152, 135, 166, 234, 206, 144, 250, 85, 29, 179, 106, 145, 171, 99, 39, 248, 22, 133, 92, 203, 68, 200, 199, 200, 47, 57, 31, 58, 245, 87, 84, 192, 40, 6, 139, 146, 234, 198, 174, 241, 51, 28, 39, 114, 199, 161, 207, 46, 89, 0, 152, 185, 237, 128, 15, 152, 133, 52, 193, 224, 60, 162, 247, 21, 152, 214, 134, 195, 169, 111, 44, 29 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("cca70faa-b341-47fd-91d5-4e56c5028aad"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("f0100b67-7bac-4b31-9e0e-523c6b749367") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("cca70faa-b341-47fd-91d5-4e56c5028aad"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f0100b67-7bac-4b31-9e0e-523c6b749367"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("a19eb723-158a-4444-ba01-8deeed57720f"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 25, 13, 54, 59, 545, DateTimeKind.Local).AddTicks(9907), null, "pair6@pair6.com", "Banu", "Dik", "TC1246", new byte[] { 239, 218, 203, 150, 116, 81, 185, 143, 60, 254, 206, 63, 237, 73, 179, 96, 80, 140, 41, 160, 182, 29, 185, 210, 141, 86, 197, 231, 93, 196, 162, 203, 193, 159, 56, 223, 95, 84, 67, 210, 250, 231, 137, 220, 95, 145, 197, 54, 102, 236, 62, 207, 193, 9, 50, 37, 70, 214, 172, 132, 87, 208, 117, 46 }, new byte[] { 67, 34, 14, 74, 168, 152, 73, 25, 179, 28, 132, 182, 126, 40, 9, 45, 198, 243, 112, 135, 252, 159, 67, 100, 183, 136, 148, 154, 231, 186, 238, 159, 198, 103, 242, 74, 184, 244, 238, 209, 210, 185, 114, 187, 201, 241, 84, 153, 168, 1, 176, 90, 45, 155, 63, 248, 78, 17, 224, 101, 9, 201, 179, 2, 237, 15, 116, 104, 242, 96, 7, 82, 41, 161, 31, 118, 232, 88, 118, 251, 189, 217, 84, 203, 236, 191, 99, 119, 160, 170, 105, 142, 124, 216, 148, 218, 202, 170, 213, 46, 30, 0, 73, 34, 191, 137, 188, 107, 134, 100, 88, 102, 244, 156, 79, 192, 133, 243, 130, 105, 32, 163, 166, 138, 200, 104, 7, 102 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("90e0542e-baa0-48fb-889f-4a80f487d782"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("a19eb723-158a-4444-ba01-8deeed57720f") });
        }
    }
}
