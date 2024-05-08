using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migBootcampFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("1d5bb250-8115-4cad-8536-fddf0c688eeb"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bb99e753-8824-4502-aecb-352e346f7f4e"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("4125ea7f-e0f3-42ab-b108-29abfa29a412"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 4, 17, 48, 4, 915, DateTimeKind.Local).AddTicks(6820), null, "pair6@pair6.com", "Banu", "Dik", "TC1246", new byte[] { 220, 82, 103, 74, 66, 220, 114, 184, 32, 189, 132, 82, 41, 100, 212, 186, 177, 215, 122, 119, 129, 187, 97, 14, 56, 210, 247, 35, 36, 238, 124, 34, 171, 30, 151, 197, 96, 172, 43, 27, 207, 34, 89, 37, 74, 247, 185, 189, 90, 40, 127, 111, 19, 72, 62, 120, 234, 237, 176, 41, 43, 207, 249, 52 }, new byte[] { 75, 109, 95, 134, 79, 136, 16, 253, 121, 110, 182, 210, 116, 116, 158, 38, 206, 0, 4, 165, 86, 93, 55, 75, 155, 190, 226, 119, 87, 202, 8, 130, 156, 146, 228, 32, 88, 50, 21, 66, 145, 96, 65, 215, 232, 55, 52, 239, 56, 83, 201, 11, 52, 71, 106, 79, 216, 145, 223, 22, 122, 173, 213, 83, 234, 16, 111, 133, 201, 121, 122, 120, 130, 90, 9, 134, 85, 126, 20, 118, 230, 56, 33, 172, 150, 48, 222, 254, 253, 228, 169, 234, 21, 33, 104, 152, 1, 182, 190, 72, 14, 87, 48, 129, 36, 27, 250, 86, 111, 58, 191, 173, 58, 17, 81, 38, 55, 26, 233, 175, 133, 94, 211, 211, 113, 250, 184, 119 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("9d08c23f-e515-49b2-b896-4ce48fb79bc2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("4125ea7f-e0f3-42ab-b108-29abfa29a412") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("9d08c23f-e515-49b2-b896-4ce48fb79bc2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4125ea7f-e0f3-42ab-b108-29abfa29a412"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("bb99e753-8824-4502-aecb-352e346f7f4e"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 25, 14, 28, 41, 175, DateTimeKind.Local).AddTicks(1703), null, "pair6@pair6.com", "Banu", "Dik", "TC1246", new byte[] { 182, 175, 182, 201, 139, 177, 176, 4, 25, 1, 62, 116, 15, 28, 91, 177, 209, 2, 163, 41, 146, 59, 143, 63, 87, 59, 217, 33, 155, 167, 91, 39, 250, 238, 99, 243, 137, 227, 153, 156, 19, 171, 29, 99, 214, 248, 153, 203, 71, 228, 227, 250, 83, 106, 192, 106, 189, 188, 61, 47, 85, 132, 135, 168 }, new byte[] { 217, 222, 111, 155, 36, 216, 28, 200, 115, 211, 8, 86, 114, 66, 77, 174, 150, 110, 202, 79, 134, 181, 178, 211, 202, 117, 208, 27, 122, 136, 2, 90, 230, 232, 116, 49, 152, 160, 157, 172, 141, 43, 21, 218, 188, 124, 43, 6, 233, 106, 151, 27, 35, 37, 195, 182, 38, 246, 238, 175, 21, 211, 30, 169, 249, 236, 131, 53, 106, 64, 193, 251, 0, 96, 59, 58, 160, 115, 28, 113, 57, 129, 158, 53, 38, 149, 172, 187, 220, 160, 36, 50, 199, 5, 34, 89, 79, 123, 69, 164, 136, 77, 109, 181, 162, 231, 29, 126, 234, 170, 63, 99, 139, 152, 248, 161, 201, 167, 90, 252, 186, 252, 80, 30, 45, 50, 53, 109 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("1d5bb250-8115-4cad-8536-fddf0c688eeb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("bb99e753-8824-4502-aecb-352e346f7f4e") });
        }
    }
}
