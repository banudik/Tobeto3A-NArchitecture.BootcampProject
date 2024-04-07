using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("30f7abc6-2f94-4986-b664-089b7598c5e8"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("abc43741-d786-45d5-9ae6-bcd917af509c"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("730935ac-9d32-45cb-a849-744918fb19ac"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 2, 15, 30, 47, 166, DateTimeKind.Local).AddTicks(6491), null, "banudik_34@hotmail.com", "Banu", "Dik", "TC1246", new byte[] { 112, 151, 67, 98, 185, 174, 76, 188, 71, 218, 79, 179, 31, 170, 57, 148, 35, 199, 109, 201, 228, 11, 187, 35, 111, 216, 102, 19, 49, 157, 125, 90, 85, 244, 87, 235, 221, 212, 48, 249, 3, 201, 23, 14, 11, 10, 189, 40, 31, 118, 175, 41, 56, 219, 0, 104, 89, 79, 52, 239, 8, 15, 46, 19 }, new byte[] { 151, 140, 13, 253, 100, 95, 173, 32, 43, 154, 63, 222, 87, 130, 6, 199, 153, 228, 102, 89, 128, 187, 16, 109, 3, 194, 94, 54, 153, 67, 129, 201, 17, 20, 111, 165, 242, 180, 171, 55, 109, 239, 14, 151, 199, 5, 77, 11, 99, 251, 85, 161, 95, 151, 181, 198, 204, 208, 188, 82, 51, 226, 152, 137, 68, 206, 112, 247, 155, 111, 72, 19, 78, 136, 118, 87, 221, 130, 222, 151, 110, 104, 62, 99, 199, 99, 251, 115, 9, 220, 17, 253, 10, 169, 243, 227, 30, 136, 21, 220, 46, 150, 107, 149, 52, 105, 210, 122, 35, 110, 239, 220, 132, 240, 154, 43, 61, 40, 40, 145, 123, 30, 147, 90, 221, 185, 133, 194 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("9e7fbb14-538c-4219-8d01-906fd2d3f14c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("730935ac-9d32-45cb-a849-744918fb19ac") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("9e7fbb14-538c-4219-8d01-906fd2d3f14c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("730935ac-9d32-45cb-a849-744918fb19ac"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("abc43741-d786-45d5-9ae6-bcd917af509c"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 2, 15, 21, 30, 605, DateTimeKind.Local).AddTicks(2923), null, "banudik_34@hotmail.com", "Banu", "Dik", "TC1246", new byte[] { 111, 38, 43, 166, 46, 49, 40, 82, 195, 110, 237, 200, 186, 72, 47, 86, 233, 172, 23, 212, 240, 30, 59, 131, 228, 81, 222, 188, 12, 46, 117, 53, 235, 77, 81, 7, 57, 107, 42, 166, 39, 91, 161, 151, 16, 172, 34, 211, 154, 129, 38, 203, 218, 157, 191, 192, 54, 49, 161, 209, 168, 201, 117, 46 }, new byte[] { 221, 96, 118, 239, 21, 251, 28, 163, 122, 186, 67, 163, 76, 184, 197, 46, 2, 32, 37, 91, 175, 126, 240, 212, 68, 198, 20, 143, 119, 110, 63, 49, 209, 188, 165, 99, 16, 254, 20, 22, 127, 135, 74, 33, 54, 152, 17, 242, 40, 116, 67, 105, 174, 116, 169, 56, 239, 155, 164, 36, 15, 6, 7, 49, 206, 103, 69, 73, 121, 28, 228, 137, 33, 150, 214, 115, 228, 85, 152, 70, 185, 164, 3, 124, 195, 70, 133, 82, 148, 176, 152, 108, 41, 128, 16, 249, 131, 210, 143, 136, 29, 129, 82, 175, 205, 207, 16, 182, 55, 38, 138, 42, 35, 113, 32, 115, 45, 239, 47, 178, 148, 60, 126, 243, 57, 248, 78, 174 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("30f7abc6-2f94-4986-b664-089b7598c5e8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("abc43741-d786-45d5-9ae6-bcd917af509c") });
        }
    }
}
