using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class may304 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("c98e0763-5b44-4839-bb1d-5af6a4cfd6e8"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3c0d427a-e0d7-4735-98a2-3ff4847b43d0"));

            migrationBuilder.UpdateData(
                table: "ApplicationStateInformations",
                keyColumn: "Id",
                keyValue: (short)1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 29, 21, 17, 26, 558, DateTimeKind.Utc).AddTicks(5014));

            migrationBuilder.UpdateData(
                table: "ApplicationStateInformations",
                keyColumn: "Id",
                keyValue: (short)2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 29, 21, 17, 26, 558, DateTimeKind.Utc).AddTicks(5017));

            migrationBuilder.UpdateData(
                table: "ApplicationStateInformations",
                keyColumn: "Id",
                keyValue: (short)3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 29, 21, 17, 26, 558, DateTimeKind.Utc).AddTicks(5018));

            migrationBuilder.UpdateData(
                table: "ApplicationStateInformations",
                keyColumn: "Id",
                keyValue: (short)4,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 29, 21, 17, 26, 558, DateTimeKind.Utc).AddTicks(5019));

            migrationBuilder.UpdateData(
                table: "BootcampStates",
                keyColumn: "Id",
                keyValue: (short)1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 29, 21, 17, 26, 560, DateTimeKind.Utc).AddTicks(3248));

            migrationBuilder.UpdateData(
                table: "BootcampStates",
                keyColumn: "Id",
                keyValue: (short)2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 29, 21, 17, 26, 560, DateTimeKind.Utc).AddTicks(3250));

            migrationBuilder.UpdateData(
                table: "BootcampStates",
                keyColumn: "Id",
                keyValue: (short)3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 29, 21, 17, 26, 560, DateTimeKind.Utc).AddTicks(3251));

            migrationBuilder.UpdateData(
                table: "BootcampStates",
                keyColumn: "Id",
                keyValue: (short)4,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 29, 21, 17, 26, 560, DateTimeKind.Utc).AddTicks(3252));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("2d6afe9c-387d-4b72-9f73-31d47c320ff4"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 30, 0, 17, 26, 563, DateTimeKind.Local).AddTicks(2271), null, "pair6@pair6.com", "Banu", "Dik", "TC1246", new byte[] { 113, 208, 26, 94, 3, 71, 105, 71, 164, 137, 164, 51, 165, 117, 101, 248, 244, 177, 253, 238, 65, 125, 168, 160, 216, 244, 26, 180, 250, 138, 173, 171, 115, 182, 70, 223, 182, 68, 244, 232, 207, 167, 47, 188, 251, 58, 98, 242, 124, 122, 219, 154, 28, 172, 174, 65, 116, 205, 127, 254, 41, 171, 114, 220 }, new byte[] { 48, 47, 8, 144, 111, 80, 175, 148, 208, 224, 81, 239, 183, 131, 61, 3, 73, 130, 90, 187, 227, 243, 175, 16, 245, 35, 107, 240, 78, 134, 39, 174, 89, 220, 157, 116, 77, 3, 162, 211, 110, 208, 190, 162, 134, 82, 156, 57, 40, 117, 178, 30, 5, 9, 150, 26, 197, 121, 162, 213, 97, 124, 4, 43, 185, 188, 185, 5, 194, 195, 150, 64, 228, 45, 63, 248, 247, 206, 113, 87, 165, 144, 89, 226, 129, 159, 79, 53, 185, 70, 22, 231, 251, 116, 254, 120, 229, 208, 21, 64, 165, 126, 203, 152, 195, 125, 193, 9, 94, 30, 114, 25, 104, 101, 67, 53, 95, 188, 214, 93, 6, 133, 112, 179, 224, 11, 136, 237 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("6db36b23-ceab-4539-9ddc-f23fac169b8d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("2d6afe9c-387d-4b72-9f73-31d47c320ff4") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("6db36b23-ceab-4539-9ddc-f23fac169b8d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2d6afe9c-387d-4b72-9f73-31d47c320ff4"));

            migrationBuilder.UpdateData(
                table: "ApplicationStateInformations",
                keyColumn: "Id",
                keyValue: (short)1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 29, 21, 16, 39, 855, DateTimeKind.Utc).AddTicks(1068));

            migrationBuilder.UpdateData(
                table: "ApplicationStateInformations",
                keyColumn: "Id",
                keyValue: (short)2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 29, 21, 16, 39, 855, DateTimeKind.Utc).AddTicks(1071));

            migrationBuilder.UpdateData(
                table: "ApplicationStateInformations",
                keyColumn: "Id",
                keyValue: (short)3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 29, 21, 16, 39, 855, DateTimeKind.Utc).AddTicks(1072));

            migrationBuilder.UpdateData(
                table: "ApplicationStateInformations",
                keyColumn: "Id",
                keyValue: (short)4,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 29, 21, 16, 39, 855, DateTimeKind.Utc).AddTicks(1073));

            migrationBuilder.UpdateData(
                table: "BootcampStates",
                keyColumn: "Id",
                keyValue: (short)1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 29, 21, 16, 39, 857, DateTimeKind.Utc).AddTicks(13));

            migrationBuilder.UpdateData(
                table: "BootcampStates",
                keyColumn: "Id",
                keyValue: (short)2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 29, 21, 16, 39, 857, DateTimeKind.Utc).AddTicks(16));

            migrationBuilder.UpdateData(
                table: "BootcampStates",
                keyColumn: "Id",
                keyValue: (short)3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 29, 21, 16, 39, 857, DateTimeKind.Utc).AddTicks(17));

            migrationBuilder.UpdateData(
                table: "BootcampStates",
                keyColumn: "Id",
                keyValue: (short)4,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 29, 21, 16, 39, 857, DateTimeKind.Utc).AddTicks(48));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("3c0d427a-e0d7-4735-98a2-3ff4847b43d0"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 30, 0, 16, 39, 859, DateTimeKind.Local).AddTicks(9653), null, "pair6@pair6.com", "Banu", "Dik", "TC1246", new byte[] { 32, 93, 22, 62, 189, 47, 146, 114, 94, 5, 192, 177, 12, 226, 200, 203, 188, 181, 114, 63, 126, 113, 10, 124, 121, 87, 102, 197, 216, 216, 96, 232, 208, 34, 54, 45, 102, 10, 200, 222, 80, 138, 6, 205, 42, 3, 242, 163, 210, 206, 166, 206, 218, 234, 108, 126, 33, 213, 157, 181, 110, 252, 14, 255 }, new byte[] { 57, 136, 214, 59, 235, 254, 97, 218, 106, 199, 109, 39, 32, 125, 248, 200, 46, 80, 25, 106, 162, 243, 34, 88, 116, 240, 198, 213, 231, 46, 209, 196, 59, 77, 123, 113, 228, 192, 85, 46, 3, 183, 47, 77, 130, 227, 248, 53, 183, 52, 92, 116, 29, 115, 211, 113, 226, 40, 249, 135, 253, 132, 132, 115, 83, 167, 254, 75, 15, 129, 196, 15, 127, 220, 129, 236, 106, 122, 79, 83, 125, 110, 95, 166, 86, 122, 84, 116, 25, 27, 153, 57, 163, 245, 60, 197, 116, 93, 108, 29, 226, 222, 163, 236, 48, 166, 76, 152, 114, 228, 0, 75, 83, 239, 182, 9, 41, 60, 115, 227, 167, 119, 138, 27, 37, 81, 79, 174 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("c98e0763-5b44-4839-bb1d-5af6a4cfd6e8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("3c0d427a-e0d7-4735-98a2-3ff4847b43d0") });
        }
    }
}
