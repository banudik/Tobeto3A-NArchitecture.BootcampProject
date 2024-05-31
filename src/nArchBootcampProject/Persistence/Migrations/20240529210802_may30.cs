using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class may30 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("e2a44b51-b125-4f90-bc48-ec762391b753"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7416802f-adcd-4967-b011-b7a97f204ac4"));

            migrationBuilder.InsertData(
                table: "ApplicationStateInformations",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { (short)2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Received", null },
                    { (short)3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Approved", null },
                    { (short)4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Un Approved", null },
                    { (short)5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cancelled", null }
                });

            migrationBuilder.InsertData(
                table: "BootcampStates",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { (short)1, new DateTime(2024, 5, 29, 21, 8, 2, 246, DateTimeKind.Utc).AddTicks(2571), null, "Not Started", null },
                    { (short)2, new DateTime(2024, 5, 29, 21, 8, 2, 246, DateTimeKind.Utc).AddTicks(2574), null, "Started", null },
                    { (short)3, new DateTime(2024, 5, 29, 21, 8, 2, 246, DateTimeKind.Utc).AddTicks(2576), null, "On Hold", null },
                    { (short)4, new DateTime(2024, 5, 29, 21, 8, 2, 246, DateTimeKind.Utc).AddTicks(2577), null, "Finished", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("b3c25812-4065-49df-b45c-18a94f242b6a"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 30, 0, 8, 2, 249, DateTimeKind.Local).AddTicks(6975), null, "pair6@pair6.com", "Banu", "Dik", "TC1246", new byte[] { 151, 163, 212, 14, 215, 173, 128, 42, 88, 242, 134, 78, 123, 26, 2, 14, 196, 222, 22, 98, 102, 24, 132, 42, 49, 179, 15, 53, 251, 199, 167, 213, 180, 28, 137, 15, 58, 135, 166, 7, 148, 133, 202, 187, 182, 106, 240, 66, 165, 196, 221, 226, 82, 35, 218, 194, 98, 195, 24, 57, 172, 147, 195, 79 }, new byte[] { 110, 0, 148, 186, 12, 146, 140, 14, 67, 136, 121, 28, 101, 200, 142, 192, 120, 165, 194, 89, 83, 91, 137, 59, 91, 202, 194, 213, 173, 85, 92, 45, 54, 102, 92, 94, 86, 68, 83, 176, 134, 14, 137, 178, 45, 26, 29, 201, 201, 214, 238, 223, 60, 5, 226, 213, 101, 111, 140, 200, 149, 155, 149, 162, 218, 128, 229, 57, 6, 19, 101, 145, 148, 242, 235, 41, 111, 192, 207, 182, 78, 91, 43, 91, 189, 206, 66, 61, 36, 51, 252, 78, 120, 12, 229, 80, 216, 109, 249, 137, 124, 187, 165, 172, 249, 65, 198, 188, 88, 235, 46, 197, 203, 90, 189, 72, 70, 56, 67, 235, 108, 171, 169, 226, 213, 79, 230, 79 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("66117390-2807-4909-8909-96559b00178e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("b3c25812-4065-49df-b45c-18a94f242b6a") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApplicationStateInformations",
                keyColumn: "Id",
                keyValue: (short)2);

            migrationBuilder.DeleteData(
                table: "ApplicationStateInformations",
                keyColumn: "Id",
                keyValue: (short)3);

            migrationBuilder.DeleteData(
                table: "ApplicationStateInformations",
                keyColumn: "Id",
                keyValue: (short)4);

            migrationBuilder.DeleteData(
                table: "ApplicationStateInformations",
                keyColumn: "Id",
                keyValue: (short)5);

            migrationBuilder.DeleteData(
                table: "BootcampStates",
                keyColumn: "Id",
                keyValue: (short)1);

            migrationBuilder.DeleteData(
                table: "BootcampStates",
                keyColumn: "Id",
                keyValue: (short)2);

            migrationBuilder.DeleteData(
                table: "BootcampStates",
                keyColumn: "Id",
                keyValue: (short)3);

            migrationBuilder.DeleteData(
                table: "BootcampStates",
                keyColumn: "Id",
                keyValue: (short)4);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("66117390-2807-4909-8909-96559b00178e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b3c25812-4065-49df-b45c-18a94f242b6a"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("7416802f-adcd-4967-b011-b7a97f204ac4"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 27, 16, 50, 8, 594, DateTimeKind.Local).AddTicks(2913), null, "pair6@pair6.com", "Banu", "Dik", "TC1246", new byte[] { 228, 91, 173, 143, 118, 201, 219, 89, 63, 6, 149, 155, 56, 241, 18, 226, 36, 105, 61, 177, 70, 152, 93, 75, 101, 138, 44, 23, 60, 27, 6, 70, 225, 184, 33, 40, 83, 217, 125, 53, 216, 6, 237, 187, 41, 22, 175, 68, 244, 165, 79, 137, 193, 135, 250, 72, 184, 1, 132, 149, 11, 132, 175, 35 }, new byte[] { 102, 208, 205, 202, 52, 132, 9, 30, 37, 122, 126, 207, 204, 237, 127, 191, 227, 230, 125, 193, 74, 0, 214, 6, 253, 20, 187, 31, 230, 168, 18, 215, 44, 243, 18, 199, 227, 5, 86, 156, 89, 78, 89, 190, 79, 50, 80, 249, 230, 223, 198, 222, 93, 210, 234, 3, 174, 177, 46, 22, 214, 203, 94, 230, 142, 168, 235, 35, 185, 145, 50, 227, 150, 251, 139, 247, 82, 49, 92, 166, 41, 172, 137, 182, 18, 196, 210, 249, 93, 164, 45, 209, 246, 70, 95, 48, 171, 42, 56, 76, 170, 172, 251, 72, 110, 89, 35, 178, 210, 175, 234, 149, 186, 145, 37, 75, 15, 16, 198, 19, 247, 77, 26, 94, 133, 31, 87, 99 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("e2a44b51-b125-4f90-bc48-ec762391b753"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("7416802f-adcd-4967-b011-b7a97f204ac4") });
        }
    }
}
