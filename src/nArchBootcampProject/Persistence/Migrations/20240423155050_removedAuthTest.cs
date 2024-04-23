using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class removedAuthTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("f31fd9b9-f4b3-4164-8d22-f203db82219f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b6823189-6d4c-4fa4-88ce-e0148c1feac6"));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 31,
                column: "Name",
                value: "ApplicationInformations.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 32,
                column: "Name",
                value: "ApplicationInformations.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 33,
                column: "Name",
                value: "ApplicationInformations.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 34,
                column: "Name",
                value: "ApplicationInformations.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 35,
                column: "Name",
                value: "ApplicationInformations.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 36,
                column: "Name",
                value: "ApplicationInformations.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 37,
                column: "Name",
                value: "ApplicationStateInformations.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 38,
                column: "Name",
                value: "ApplicationStateInformations.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 39,
                column: "Name",
                value: "ApplicationStateInformations.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 40,
                column: "Name",
                value: "ApplicationStateInformations.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 41,
                column: "Name",
                value: "ApplicationStateInformations.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 42,
                column: "Name",
                value: "ApplicationStateInformations.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 43,
                column: "Name",
                value: "Blacklists.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 44,
                column: "Name",
                value: "Blacklists.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 45,
                column: "Name",
                value: "Blacklists.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 46,
                column: "Name",
                value: "Blacklists.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 47,
                column: "Name",
                value: "Blacklists.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 48,
                column: "Name",
                value: "Blacklists.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 49,
                column: "Name",
                value: "Bootcamps.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 50,
                column: "Name",
                value: "Bootcamps.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 51,
                column: "Name",
                value: "Bootcamps.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 52,
                column: "Name",
                value: "Bootcamps.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 53,
                column: "Name",
                value: "Bootcamps.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 54,
                column: "Name",
                value: "Bootcamps.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 55,
                column: "Name",
                value: "BootcampImages.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 56,
                column: "Name",
                value: "BootcampImages.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 57,
                column: "Name",
                value: "BootcampImages.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 58,
                column: "Name",
                value: "BootcampImages.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 59,
                column: "Name",
                value: "BootcampImages.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 60,
                column: "Name",
                value: "BootcampImages.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 61,
                column: "Name",
                value: "BootcampStates.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 62,
                column: "Name",
                value: "BootcampStates.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 63,
                column: "Name",
                value: "BootcampStates.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 64,
                column: "Name",
                value: "BootcampStates.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 65,
                column: "Name",
                value: "BootcampStates.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 66,
                column: "Name",
                value: "BootcampStates.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 67,
                column: "Name",
                value: "Employees.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 68,
                column: "Name",
                value: "Employees.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 69,
                column: "Name",
                value: "Employees.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 70,
                column: "Name",
                value: "Employees.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 71,
                column: "Name",
                value: "Employees.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 72,
                column: "Name",
                value: "Employees.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 73,
                column: "Name",
                value: "Instructors.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 74,
                column: "Name",
                value: "Instructors.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 75,
                column: "Name",
                value: "Instructors.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 76,
                column: "Name",
                value: "Instructors.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 77,
                column: "Name",
                value: "Instructors.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 78,
                column: "Name",
                value: "Instructors.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 79,
                column: "Name",
                value: "FAQs.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 80,
                column: "Name",
                value: "FAQs.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 81,
                column: "Name",
                value: "FAQs.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 82,
                column: "Name",
                value: "FAQs.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 83,
                column: "Name",
                value: "FAQs.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 84,
                column: "Name",
                value: "FAQs.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 85,
                column: "Name",
                value: "Chapters.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 86,
                column: "Name",
                value: "Chapters.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 87,
                column: "Name",
                value: "Chapters.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 88,
                column: "Name",
                value: "Chapters.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 89,
                column: "Name",
                value: "Chapters.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 90,
                column: "Name",
                value: "Chapters.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 91,
                column: "Name",
                value: "Comments.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 92,
                column: "Name",
                value: "Comments.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 93,
                column: "Name",
                value: "Comments.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 94,
                column: "Name",
                value: "Comments.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 95,
                column: "Name",
                value: "Comments.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 96,
                column: "Name",
                value: "Comments.Delete");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("8a14b796-804f-4d77-b8e8-d983dd68b25e"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 23, 18, 50, 49, 651, DateTimeKind.Local).AddTicks(534), null, "pair6@pair6.com", "Banu", "Dik", "TC1246", new byte[] { 88, 243, 131, 128, 33, 4, 242, 90, 146, 167, 222, 222, 232, 196, 59, 110, 128, 215, 69, 197, 66, 86, 8, 181, 173, 82, 89, 163, 133, 2, 134, 141, 44, 228, 213, 86, 252, 197, 139, 58, 116, 245, 119, 239, 237, 215, 166, 148, 206, 12, 204, 247, 38, 4, 107, 73, 163, 212, 134, 63, 12, 53, 225, 38 }, new byte[] { 232, 131, 220, 137, 135, 139, 123, 117, 88, 76, 154, 234, 190, 176, 219, 207, 203, 85, 3, 230, 67, 29, 165, 189, 55, 170, 244, 208, 189, 149, 120, 225, 120, 2, 78, 10, 105, 191, 62, 16, 84, 75, 171, 88, 183, 17, 134, 57, 210, 161, 97, 241, 205, 23, 130, 114, 156, 171, 104, 116, 178, 168, 68, 241, 129, 255, 234, 248, 218, 203, 72, 16, 139, 235, 200, 67, 197, 193, 65, 83, 132, 112, 13, 130, 67, 129, 108, 216, 75, 58, 100, 83, 90, 59, 61, 72, 54, 175, 224, 251, 60, 92, 244, 112, 114, 130, 76, 133, 125, 134, 84, 148, 6, 145, 251, 184, 17, 164, 233, 177, 126, 228, 48, 48, 234, 91, 6, 7 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("a5af3fb6-8e3c-49bd-98a0-bb99dd3a96e4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("8a14b796-804f-4d77-b8e8-d983dd68b25e") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("a5af3fb6-8e3c-49bd-98a0-bb99dd3a96e4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8a14b796-804f-4d77-b8e8-d983dd68b25e"));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 31,
                column: "Name",
                value: "Applicants.ApplicantRole");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 32,
                column: "Name",
                value: "ApplicationInformations.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 33,
                column: "Name",
                value: "ApplicationInformations.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 34,
                column: "Name",
                value: "ApplicationInformations.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 35,
                column: "Name",
                value: "ApplicationInformations.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 36,
                column: "Name",
                value: "ApplicationInformations.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 37,
                column: "Name",
                value: "ApplicationInformations.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 38,
                column: "Name",
                value: "Applicants.ApplicantRole");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 39,
                column: "Name",
                value: "ApplicationStateInformations.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 40,
                column: "Name",
                value: "ApplicationStateInformations.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 41,
                column: "Name",
                value: "ApplicationStateInformations.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 42,
                column: "Name",
                value: "ApplicationStateInformations.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 43,
                column: "Name",
                value: "ApplicationStateInformations.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 44,
                column: "Name",
                value: "ApplicationStateInformations.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 45,
                column: "Name",
                value: "Applicants.ApplicantRole");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 46,
                column: "Name",
                value: "Blacklists.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 47,
                column: "Name",
                value: "Blacklists.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 48,
                column: "Name",
                value: "Blacklists.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 49,
                column: "Name",
                value: "Blacklists.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 50,
                column: "Name",
                value: "Blacklists.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 51,
                column: "Name",
                value: "Blacklists.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 52,
                column: "Name",
                value: "Bootcamps.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 53,
                column: "Name",
                value: "Bootcamps.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 54,
                column: "Name",
                value: "Bootcamps.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 55,
                column: "Name",
                value: "Bootcamps.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 56,
                column: "Name",
                value: "Bootcamps.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 57,
                column: "Name",
                value: "Bootcamps.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 58,
                column: "Name",
                value: "Applicants.ApplicantRole");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 59,
                column: "Name",
                value: "BootcampImages.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 60,
                column: "Name",
                value: "BootcampImages.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 61,
                column: "Name",
                value: "BootcampImages.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 62,
                column: "Name",
                value: "BootcampImages.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 63,
                column: "Name",
                value: "BootcampImages.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 64,
                column: "Name",
                value: "BootcampImages.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 65,
                column: "Name",
                value: "BootcampStates.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 66,
                column: "Name",
                value: "BootcampStates.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 67,
                column: "Name",
                value: "BootcampStates.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 68,
                column: "Name",
                value: "BootcampStates.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 69,
                column: "Name",
                value: "BootcampStates.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 70,
                column: "Name",
                value: "BootcampStates.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 71,
                column: "Name",
                value: "Employees.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 72,
                column: "Name",
                value: "Employees.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 73,
                column: "Name",
                value: "Employees.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 74,
                column: "Name",
                value: "Employees.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 75,
                column: "Name",
                value: "Employees.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 76,
                column: "Name",
                value: "Employees.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 77,
                column: "Name",
                value: "Instructors.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 78,
                column: "Name",
                value: "Instructors.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 79,
                column: "Name",
                value: "Instructors.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 80,
                column: "Name",
                value: "Instructors.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 81,
                column: "Name",
                value: "Instructors.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 82,
                column: "Name",
                value: "Instructors.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 83,
                column: "Name",
                value: "FAQs.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 84,
                column: "Name",
                value: "FAQs.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 85,
                column: "Name",
                value: "FAQs.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 86,
                column: "Name",
                value: "FAQs.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 87,
                column: "Name",
                value: "FAQs.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 88,
                column: "Name",
                value: "FAQs.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 89,
                column: "Name",
                value: "Chapters.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 90,
                column: "Name",
                value: "Chapters.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 91,
                column: "Name",
                value: "Chapters.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 92,
                column: "Name",
                value: "Chapters.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 93,
                column: "Name",
                value: "Chapters.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 94,
                column: "Name",
                value: "Chapters.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 95,
                column: "Name",
                value: "Applicants.ApplicantRole");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 96,
                column: "Name",
                value: "Comments.Admin");

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 97, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Comments.Read", null },
                    { 98, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Comments.Write", null },
                    { 99, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Comments.Create", null },
                    { 100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Comments.Update", null },
                    { 101, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Comments.Delete", null },
                    { 102, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Applicants.ApplicantRole", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("b6823189-6d4c-4fa4-88ce-e0148c1feac6"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 23, 18, 48, 10, 732, DateTimeKind.Local).AddTicks(310), null, "pair6@pair6.com", "Banu", "Dik", "TC1246", new byte[] { 191, 229, 221, 118, 141, 34, 240, 48, 93, 165, 219, 38, 108, 177, 114, 153, 196, 102, 196, 51, 212, 79, 191, 87, 248, 152, 143, 47, 20, 95, 21, 144, 176, 122, 20, 206, 146, 72, 241, 5, 108, 167, 0, 200, 63, 162, 236, 52, 126, 203, 21, 169, 130, 52, 23, 210, 222, 9, 68, 231, 15, 176, 70, 60 }, new byte[] { 174, 47, 241, 174, 113, 239, 51, 167, 85, 127, 157, 223, 61, 115, 120, 229, 5, 0, 12, 225, 209, 44, 162, 74, 244, 215, 227, 241, 55, 187, 95, 232, 107, 165, 11, 76, 206, 39, 67, 41, 20, 21, 226, 108, 123, 69, 97, 14, 32, 116, 33, 173, 237, 10, 66, 95, 235, 185, 161, 197, 159, 92, 177, 213, 145, 33, 190, 85, 140, 117, 75, 20, 128, 214, 21, 78, 19, 73, 43, 176, 247, 255, 77, 233, 163, 233, 229, 167, 114, 237, 121, 62, 102, 191, 19, 100, 194, 107, 51, 56, 228, 28, 254, 61, 205, 255, 51, 199, 162, 161, 207, 48, 23, 7, 239, 84, 4, 149, 37, 249, 199, 117, 249, 79, 86, 93, 118, 10 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("f31fd9b9-f4b3-4164-8d22-f203db82219f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("b6823189-6d4c-4fa4-88ce-e0148c1feac6") });
        }
    }
}
