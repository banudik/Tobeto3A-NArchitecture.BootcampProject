using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class may302 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApplicationStateInformations",
                keyColumn: "Id",
                keyValue: (short)5);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("66117390-2807-4909-8909-96559b00178e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b3c25812-4065-49df-b45c-18a94f242b6a"));

            migrationBuilder.UpdateData(
                table: "ApplicationStateInformations",
                keyColumn: "Id",
                keyValue: (short)2,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 5, 29, 21, 14, 46, 535, DateTimeKind.Utc).AddTicks(6931), "Started" });

            migrationBuilder.UpdateData(
                table: "ApplicationStateInformations",
                keyColumn: "Id",
                keyValue: (short)3,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 5, 29, 21, 14, 46, 535, DateTimeKind.Utc).AddTicks(6933), "On Hold" });

            migrationBuilder.UpdateData(
                table: "ApplicationStateInformations",
                keyColumn: "Id",
                keyValue: (short)4,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 5, 29, 21, 14, 46, 535, DateTimeKind.Utc).AddTicks(6933), "Finished" });

            migrationBuilder.InsertData(
                table: "ApplicationStateInformations",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[] { (short)1, new DateTime(2024, 5, 29, 21, 14, 46, 535, DateTimeKind.Utc).AddTicks(6929), null, "Not Started", null });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApplicationStateInformations",
                keyColumn: "Id",
                keyValue: (short)1);

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
                keyValue: (short)2,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Received" });

            migrationBuilder.UpdateData(
                table: "ApplicationStateInformations",
                keyColumn: "Id",
                keyValue: (short)3,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Approved" });

            migrationBuilder.UpdateData(
                table: "ApplicationStateInformations",
                keyColumn: "Id",
                keyValue: (short)4,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Un Approved" });

            migrationBuilder.InsertData(
                table: "ApplicationStateInformations",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[] { (short)5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cancelled", null });

            migrationBuilder.UpdateData(
                table: "BootcampStates",
                keyColumn: "Id",
                keyValue: (short)1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 29, 21, 8, 2, 246, DateTimeKind.Utc).AddTicks(2571));

            migrationBuilder.UpdateData(
                table: "BootcampStates",
                keyColumn: "Id",
                keyValue: (short)2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 29, 21, 8, 2, 246, DateTimeKind.Utc).AddTicks(2574));

            migrationBuilder.UpdateData(
                table: "BootcampStates",
                keyColumn: "Id",
                keyValue: (short)3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 29, 21, 8, 2, 246, DateTimeKind.Utc).AddTicks(2576));

            migrationBuilder.UpdateData(
                table: "BootcampStates",
                keyColumn: "Id",
                keyValue: (short)4,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 29, 21, 8, 2, 246, DateTimeKind.Utc).AddTicks(2577));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("b3c25812-4065-49df-b45c-18a94f242b6a"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 30, 0, 8, 2, 249, DateTimeKind.Local).AddTicks(6975), null, "pair6@pair6.com", "Banu", "Dik", "TC1246", new byte[] { 151, 163, 212, 14, 215, 173, 128, 42, 88, 242, 134, 78, 123, 26, 2, 14, 196, 222, 22, 98, 102, 24, 132, 42, 49, 179, 15, 53, 251, 199, 167, 213, 180, 28, 137, 15, 58, 135, 166, 7, 148, 133, 202, 187, 182, 106, 240, 66, 165, 196, 221, 226, 82, 35, 218, 194, 98, 195, 24, 57, 172, 147, 195, 79 }, new byte[] { 110, 0, 148, 186, 12, 146, 140, 14, 67, 136, 121, 28, 101, 200, 142, 192, 120, 165, 194, 89, 83, 91, 137, 59, 91, 202, 194, 213, 173, 85, 92, 45, 54, 102, 92, 94, 86, 68, 83, 176, 134, 14, 137, 178, 45, 26, 29, 201, 201, 214, 238, 223, 60, 5, 226, 213, 101, 111, 140, 200, 149, 155, 149, 162, 218, 128, 229, 57, 6, 19, 101, 145, 148, 242, 235, 41, 111, 192, 207, 182, 78, 91, 43, 91, 189, 206, 66, 61, 36, 51, 252, 78, 120, 12, 229, 80, 216, 109, 249, 137, 124, 187, 165, 172, 249, 65, 198, 188, 88, 235, 46, 197, 203, 90, 189, 72, 70, 56, 67, 235, 108, 171, 169, 226, 213, 79, 230, 79 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("66117390-2807-4909-8909-96559b00178e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("b3c25812-4065-49df-b45c-18a94f242b6a") });
        }
    }
}
