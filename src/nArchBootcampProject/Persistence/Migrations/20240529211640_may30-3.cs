using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class may303 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("032d817b-12a3-4e2e-9990-2bd084e458f2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("76d3247c-8a9a-4222-98a1-dfb32f8b6318"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                value: new DateTime(2024, 5, 29, 21, 14, 46, 535, DateTimeKind.Utc).AddTicks(6929));

            migrationBuilder.UpdateData(
                table: "ApplicationStateInformations",
                keyColumn: "Id",
                keyValue: (short)2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 29, 21, 14, 46, 535, DateTimeKind.Utc).AddTicks(6931));

            migrationBuilder.UpdateData(
                table: "ApplicationStateInformations",
                keyColumn: "Id",
                keyValue: (short)3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 29, 21, 14, 46, 535, DateTimeKind.Utc).AddTicks(6933));

            migrationBuilder.UpdateData(
                table: "ApplicationStateInformations",
                keyColumn: "Id",
                keyValue: (short)4,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 29, 21, 14, 46, 535, DateTimeKind.Utc).AddTicks(6933));

            migrationBuilder.UpdateData(
                table: "BootcampStates",
                keyColumn: "Id",
                keyValue: (short)1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 29, 21, 14, 46, 537, DateTimeKind.Utc).AddTicks(7210));

            migrationBuilder.UpdateData(
                table: "BootcampStates",
                keyColumn: "Id",
                keyValue: (short)2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 29, 21, 14, 46, 537, DateTimeKind.Utc).AddTicks(7213));

            migrationBuilder.UpdateData(
                table: "BootcampStates",
                keyColumn: "Id",
                keyValue: (short)3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 29, 21, 14, 46, 537, DateTimeKind.Utc).AddTicks(7214));

            migrationBuilder.UpdateData(
                table: "BootcampStates",
                keyColumn: "Id",
                keyValue: (short)4,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 29, 21, 14, 46, 537, DateTimeKind.Utc).AddTicks(7215));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("76d3247c-8a9a-4222-98a1-dfb32f8b6318"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 30, 0, 14, 46, 542, DateTimeKind.Local).AddTicks(870), null, "pair6@pair6.com", "Banu", "Dik", "TC1246", new byte[] { 250, 99, 147, 225, 78, 126, 193, 116, 17, 84, 14, 150, 75, 56, 184, 130, 1, 25, 0, 93, 87, 120, 210, 161, 96, 101, 162, 9, 158, 17, 20, 13, 72, 215, 157, 8, 45, 145, 165, 89, 123, 167, 152, 27, 148, 189, 248, 251, 214, 66, 68, 147, 168, 83, 86, 177, 125, 202, 125, 164, 236, 130, 178, 26 }, new byte[] { 95, 6, 189, 186, 252, 214, 23, 55, 39, 209, 192, 168, 215, 150, 205, 87, 251, 140, 102, 70, 237, 204, 255, 129, 254, 81, 97, 228, 39, 137, 111, 38, 103, 178, 61, 71, 153, 235, 72, 11, 7, 162, 192, 206, 172, 71, 208, 252, 122, 159, 91, 238, 137, 29, 38, 122, 60, 188, 75, 77, 108, 60, 93, 97, 86, 173, 4, 247, 218, 124, 181, 112, 248, 142, 56, 215, 148, 18, 221, 15, 196, 188, 180, 22, 254, 15, 16, 167, 162, 95, 255, 221, 74, 127, 49, 253, 96, 32, 221, 18, 146, 34, 162, 135, 238, 207, 141, 252, 33, 61, 153, 56, 251, 55, 178, 56, 52, 225, 38, 175, 154, 209, 53, 64, 101, 206, 35, 106 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("032d817b-12a3-4e2e-9990-2bd084e458f2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("76d3247c-8a9a-4222-98a1-dfb32f8b6318") });
        }
    }
}
