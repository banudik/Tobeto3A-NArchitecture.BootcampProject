using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migYetkiler : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                keyValue: 73,
                column: "Name",
                value: "Employees.EmployeeRole");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 74,
                column: "Name",
                value: "Instructors.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 75,
                column: "Name",
                value: "Instructors.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 76,
                column: "Name",
                value: "Instructors.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 77,
                column: "Name",
                value: "Instructors.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 78,
                column: "Name",
                value: "Instructors.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 79,
                column: "Name",
                value: "Instructors.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 80,
                column: "Name",
                value: "Instructors.InstructorRole");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 81,
                column: "Name",
                value: "FAQs.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 82,
                column: "Name",
                value: "FAQs.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 83,
                column: "Name",
                value: "FAQs.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 84,
                column: "Name",
                value: "FAQs.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 85,
                column: "Name",
                value: "FAQs.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 86,
                column: "Name",
                value: "FAQs.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 87,
                column: "Name",
                value: "Chapters.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 88,
                column: "Name",
                value: "Chapters.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 89,
                column: "Name",
                value: "Chapters.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 90,
                column: "Name",
                value: "Chapters.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 91,
                column: "Name",
                value: "Chapters.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 92,
                column: "Name",
                value: "Chapters.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 93,
                column: "Name",
                value: "Comments.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 94,
                column: "Name",
                value: "Comments.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 95,
                column: "Name",
                value: "Comments.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 96,
                column: "Name",
                value: "Comments.Create");

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 97, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Comments.Update", null },
                    { 98, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Comments.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("3cc39bf4-e2d1-4631-b1ff-8902d51c4a63"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 23, 19, 25, 6, 561, DateTimeKind.Local).AddTicks(1863), null, "pair6@pair6.com", "Banu", "Dik", "TC1246", new byte[] { 35, 19, 152, 74, 45, 32, 3, 231, 120, 179, 25, 157, 133, 60, 66, 62, 210, 135, 244, 133, 65, 26, 49, 224, 96, 217, 122, 247, 182, 50, 78, 73, 68, 76, 230, 203, 111, 22, 222, 66, 14, 59, 43, 0, 67, 159, 156, 107, 62, 176, 39, 11, 110, 146, 157, 242, 186, 75, 190, 162, 219, 193, 117, 19 }, new byte[] { 165, 49, 98, 195, 122, 26, 196, 47, 95, 225, 220, 38, 14, 114, 66, 198, 44, 107, 153, 74, 123, 140, 245, 136, 22, 178, 25, 74, 77, 50, 89, 241, 239, 90, 154, 166, 20, 122, 195, 12, 205, 175, 131, 11, 134, 186, 4, 119, 98, 99, 85, 203, 98, 41, 17, 165, 5, 186, 63, 140, 31, 33, 224, 83, 54, 232, 164, 194, 155, 55, 167, 80, 136, 145, 6, 231, 243, 58, 201, 201, 195, 169, 35, 46, 9, 127, 31, 129, 238, 253, 62, 54, 170, 44, 159, 50, 159, 20, 97, 105, 65, 165, 2, 99, 14, 177, 194, 104, 220, 77, 169, 176, 243, 154, 212, 59, 236, 156, 166, 229, 166, 230, 212, 5, 56, 114, 191, 255 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("9e203bce-750a-405c-91d7-bf6d8cac8ce5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("3cc39bf4-e2d1-4631-b1ff-8902d51c4a63") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("9e203bce-750a-405c-91d7-bf6d8cac8ce5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3cc39bf4-e2d1-4631-b1ff-8902d51c4a63"));

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
    }
}
