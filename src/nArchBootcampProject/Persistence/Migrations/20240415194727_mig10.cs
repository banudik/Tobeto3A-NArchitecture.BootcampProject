using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("9e7fbb14-538c-4219-8d01-906fd2d3f14c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("730935ac-9d32-45cb-a849-744918fb19ac"));

            migrationBuilder.DropColumn(
                name: "ApplicationStateId",
                table: "ApplicationInformations");

            migrationBuilder.AlterColumn<short>(
                name: "ApplicationStateInformationId",
                table: "ApplicationInformations",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("030581f7-0a05-4ecd-b2cf-fa76e0502522"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 15, 22, 47, 27, 353, DateTimeKind.Local).AddTicks(4059), null, "banudik_34@hotmail.com", "Banu", "Dik", "TC1246", new byte[] { 68, 156, 136, 223, 42, 151, 129, 198, 173, 61, 250, 103, 90, 77, 144, 16, 33, 170, 143, 93, 51, 235, 180, 143, 148, 97, 94, 121, 250, 43, 163, 101, 158, 238, 175, 222, 174, 208, 85, 56, 231, 132, 182, 215, 125, 99, 163, 73, 36, 53, 140, 18, 14, 173, 13, 221, 84, 105, 168, 200, 90, 104, 155, 89 }, new byte[] { 54, 66, 191, 39, 34, 23, 218, 59, 16, 168, 21, 187, 199, 218, 203, 238, 31, 14, 234, 4, 49, 172, 202, 166, 41, 10, 208, 145, 108, 18, 30, 29, 243, 45, 96, 74, 75, 72, 28, 19, 82, 180, 122, 224, 47, 145, 24, 59, 224, 85, 34, 145, 114, 231, 253, 109, 74, 215, 54, 179, 244, 197, 78, 120, 251, 146, 236, 160, 76, 182, 198, 104, 203, 143, 0, 212, 139, 10, 232, 233, 121, 217, 69, 190, 174, 228, 82, 141, 95, 229, 70, 206, 144, 26, 230, 96, 190, 100, 53, 200, 180, 29, 175, 210, 203, 238, 246, 188, 205, 206, 168, 216, 174, 202, 184, 133, 246, 88, 17, 215, 104, 78, 164, 24, 134, 115, 182, 222 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("d5aee071-c17a-48a5-91bc-ceb31a745d42"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("030581f7-0a05-4ecd-b2cf-fa76e0502522") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("d5aee071-c17a-48a5-91bc-ceb31a745d42"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("030581f7-0a05-4ecd-b2cf-fa76e0502522"));

            migrationBuilder.AlterColumn<short>(
                name: "ApplicationStateInformationId",
                table: "ApplicationInformations",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AddColumn<short>(
                name: "ApplicationStateId",
                table: "ApplicationInformations",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("730935ac-9d32-45cb-a849-744918fb19ac"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 2, 15, 30, 47, 166, DateTimeKind.Local).AddTicks(6491), null, "banudik_34@hotmail.com", "Banu", "Dik", "TC1246", new byte[] { 112, 151, 67, 98, 185, 174, 76, 188, 71, 218, 79, 179, 31, 170, 57, 148, 35, 199, 109, 201, 228, 11, 187, 35, 111, 216, 102, 19, 49, 157, 125, 90, 85, 244, 87, 235, 221, 212, 48, 249, 3, 201, 23, 14, 11, 10, 189, 40, 31, 118, 175, 41, 56, 219, 0, 104, 89, 79, 52, 239, 8, 15, 46, 19 }, new byte[] { 151, 140, 13, 253, 100, 95, 173, 32, 43, 154, 63, 222, 87, 130, 6, 199, 153, 228, 102, 89, 128, 187, 16, 109, 3, 194, 94, 54, 153, 67, 129, 201, 17, 20, 111, 165, 242, 180, 171, 55, 109, 239, 14, 151, 199, 5, 77, 11, 99, 251, 85, 161, 95, 151, 181, 198, 204, 208, 188, 82, 51, 226, 152, 137, 68, 206, 112, 247, 155, 111, 72, 19, 78, 136, 118, 87, 221, 130, 222, 151, 110, 104, 62, 99, 199, 99, 251, 115, 9, 220, 17, 253, 10, 169, 243, 227, 30, 136, 21, 220, 46, 150, 107, 149, 52, 105, 210, 122, 35, 110, 239, 220, 132, 240, 154, 43, 61, 40, 40, 145, 123, 30, 147, 90, 221, 185, 133, 194 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("9e7fbb14-538c-4219-8d01-906fd2d3f14c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("730935ac-9d32-45cb-a849-744918fb19ac") });
        }
    }
}
