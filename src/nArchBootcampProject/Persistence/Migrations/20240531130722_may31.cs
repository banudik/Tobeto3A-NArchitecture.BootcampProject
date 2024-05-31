using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class may31 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Chapters_ChapterId",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("6db36b23-ceab-4539-9ddc-f23fac169b8d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2d6afe9c-387d-4b72-9f73-31d47c320ff4"));

            migrationBuilder.RenameColumn(
                name: "ChapterId",
                table: "Comments",
                newName: "BootcampId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ChapterId",
                table: "Comments",
                newName: "IX_Comments_BootcampId");

            migrationBuilder.UpdateData(
                table: "ApplicationStateInformations",
                keyColumn: "Id",
                keyValue: (short)1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 31, 13, 7, 21, 686, DateTimeKind.Utc).AddTicks(6445));

            migrationBuilder.UpdateData(
                table: "ApplicationStateInformations",
                keyColumn: "Id",
                keyValue: (short)2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 31, 13, 7, 21, 686, DateTimeKind.Utc).AddTicks(6447));

            migrationBuilder.UpdateData(
                table: "ApplicationStateInformations",
                keyColumn: "Id",
                keyValue: (short)3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 31, 13, 7, 21, 686, DateTimeKind.Utc).AddTicks(6448));

            migrationBuilder.UpdateData(
                table: "ApplicationStateInformations",
                keyColumn: "Id",
                keyValue: (short)4,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 31, 13, 7, 21, 686, DateTimeKind.Utc).AddTicks(6449));

            migrationBuilder.UpdateData(
                table: "BootcampStates",
                keyColumn: "Id",
                keyValue: (short)1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 31, 13, 7, 21, 688, DateTimeKind.Utc).AddTicks(4198));

            migrationBuilder.UpdateData(
                table: "BootcampStates",
                keyColumn: "Id",
                keyValue: (short)2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 31, 13, 7, 21, 688, DateTimeKind.Utc).AddTicks(4199));

            migrationBuilder.UpdateData(
                table: "BootcampStates",
                keyColumn: "Id",
                keyValue: (short)3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 31, 13, 7, 21, 688, DateTimeKind.Utc).AddTicks(4200));

            migrationBuilder.UpdateData(
                table: "BootcampStates",
                keyColumn: "Id",
                keyValue: (short)4,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 31, 13, 7, 21, 688, DateTimeKind.Utc).AddTicks(4201));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("f9a0e49e-2cfe-436b-aa43-0365de283a09"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 31, 16, 7, 21, 691, DateTimeKind.Local).AddTicks(4723), null, "pair6@pair6.com", "Banu", "Dik", "TC1246", new byte[] { 124, 37, 194, 75, 20, 12, 66, 141, 19, 48, 19, 111, 148, 247, 175, 192, 37, 36, 122, 178, 14, 5, 184, 185, 79, 105, 17, 113, 223, 168, 239, 143, 200, 174, 29, 239, 233, 52, 93, 125, 139, 15, 252, 140, 140, 81, 233, 215, 81, 126, 246, 159, 170, 6, 157, 170, 226, 74, 95, 91, 98, 84, 80, 169 }, new byte[] { 250, 97, 132, 210, 203, 16, 184, 25, 237, 208, 66, 214, 46, 10, 199, 72, 84, 85, 3, 128, 82, 239, 213, 34, 135, 8, 175, 123, 252, 182, 210, 141, 172, 242, 65, 220, 226, 18, 24, 77, 101, 178, 161, 118, 2, 175, 134, 156, 99, 192, 118, 82, 230, 132, 139, 29, 168, 100, 251, 188, 105, 176, 184, 211, 110, 47, 35, 55, 72, 99, 6, 95, 193, 41, 103, 129, 111, 227, 14, 54, 250, 69, 117, 15, 188, 82, 17, 218, 33, 222, 18, 9, 65, 25, 28, 57, 231, 218, 198, 123, 2, 240, 203, 61, 215, 107, 192, 70, 58, 215, 20, 25, 12, 235, 220, 61, 67, 85, 255, 115, 149, 84, 203, 126, 159, 188, 102, 91 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("0359ebdc-7434-49fe-9b4a-36324d41e688"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("f9a0e49e-2cfe-436b-aa43-0365de283a09") });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Bootcamps_BootcampId",
                table: "Comments",
                column: "BootcampId",
                principalTable: "Bootcamps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Bootcamps_BootcampId",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("0359ebdc-7434-49fe-9b4a-36324d41e688"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f9a0e49e-2cfe-436b-aa43-0365de283a09"));

            migrationBuilder.RenameColumn(
                name: "BootcampId",
                table: "Comments",
                newName: "ChapterId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_BootcampId",
                table: "Comments",
                newName: "IX_Comments_ChapterId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Chapters_ChapterId",
                table: "Comments",
                column: "ChapterId",
                principalTable: "Chapters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
