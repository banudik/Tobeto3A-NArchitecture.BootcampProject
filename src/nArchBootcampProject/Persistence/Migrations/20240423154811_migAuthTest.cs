using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migAuthTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("0e2ab8e0-e333-4338-b040-a6dcb6311837"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d3a0c2b3-189a-4250-bb94-d2b0071396cf"));

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Context = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BootcampId = table.Column<int>(type: "int", nullable: false),
                    ChapterId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Chapters_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 24,
                column: "Name",
                value: "Applicants.ApplicantRole");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 25,
                column: "Name",
                value: "Applicants.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 26,
                column: "Name",
                value: "Applicants.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 27,
                column: "Name",
                value: "Applicants.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 28,
                column: "Name",
                value: "Applicants.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 29,
                column: "Name",
                value: "Applicants.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 30,
                column: "Name",
                value: "Applicants.Delete");

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

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 90, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Chapters.Read", null },
                    { 91, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Chapters.Write", null },
                    { 92, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Chapters.Create", null },
                    { 93, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Chapters.Update", null },
                    { 94, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Chapters.Delete", null },
                    { 95, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Applicants.ApplicantRole", null },
                    { 96, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Comments.Admin", null },
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

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ChapterId",
                table: "Comments",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 96);

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
                keyValue: 24,
                column: "Name",
                value: "Applicants.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 25,
                column: "Name",
                value: "Applicants.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 26,
                column: "Name",
                value: "Applicants.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 27,
                column: "Name",
                value: "Applicants.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 28,
                column: "Name",
                value: "Applicants.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 29,
                column: "Name",
                value: "Applicants.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 30,
                column: "Name",
                value: "ApplicationInformations.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 31,
                column: "Name",
                value: "ApplicationInformations.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 32,
                column: "Name",
                value: "ApplicationInformations.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 33,
                column: "Name",
                value: "ApplicationInformations.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 34,
                column: "Name",
                value: "ApplicationInformations.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 35,
                column: "Name",
                value: "ApplicationInformations.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 36,
                column: "Name",
                value: "ApplicationStateInformations.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 37,
                column: "Name",
                value: "ApplicationStateInformations.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 38,
                column: "Name",
                value: "ApplicationStateInformations.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 39,
                column: "Name",
                value: "ApplicationStateInformations.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 40,
                column: "Name",
                value: "ApplicationStateInformations.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 41,
                column: "Name",
                value: "ApplicationStateInformations.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 42,
                column: "Name",
                value: "Blacklists.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 43,
                column: "Name",
                value: "Blacklists.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 44,
                column: "Name",
                value: "Blacklists.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 45,
                column: "Name",
                value: "Blacklists.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 46,
                column: "Name",
                value: "Blacklists.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 47,
                column: "Name",
                value: "Blacklists.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 48,
                column: "Name",
                value: "Bootcamps.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 49,
                column: "Name",
                value: "Bootcamps.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 50,
                column: "Name",
                value: "Bootcamps.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 51,
                column: "Name",
                value: "Bootcamps.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 52,
                column: "Name",
                value: "Bootcamps.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 53,
                column: "Name",
                value: "Bootcamps.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 54,
                column: "Name",
                value: "BootcampImages.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 55,
                column: "Name",
                value: "BootcampImages.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 56,
                column: "Name",
                value: "BootcampImages.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 57,
                column: "Name",
                value: "BootcampImages.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 58,
                column: "Name",
                value: "BootcampImages.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 59,
                column: "Name",
                value: "BootcampImages.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 60,
                column: "Name",
                value: "BootcampStates.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 61,
                column: "Name",
                value: "BootcampStates.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 62,
                column: "Name",
                value: "BootcampStates.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 63,
                column: "Name",
                value: "BootcampStates.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 64,
                column: "Name",
                value: "BootcampStates.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 65,
                column: "Name",
                value: "BootcampStates.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 66,
                column: "Name",
                value: "Employees.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 67,
                column: "Name",
                value: "Employees.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 68,
                column: "Name",
                value: "Employees.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 69,
                column: "Name",
                value: "Employees.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 70,
                column: "Name",
                value: "Employees.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 71,
                column: "Name",
                value: "Employees.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 72,
                column: "Name",
                value: "Instructors.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 73,
                column: "Name",
                value: "Instructors.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 74,
                column: "Name",
                value: "Instructors.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 75,
                column: "Name",
                value: "Instructors.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 76,
                column: "Name",
                value: "Instructors.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 77,
                column: "Name",
                value: "Instructors.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 78,
                column: "Name",
                value: "FAQs.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 79,
                column: "Name",
                value: "FAQs.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 80,
                column: "Name",
                value: "FAQs.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 81,
                column: "Name",
                value: "FAQs.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 82,
                column: "Name",
                value: "FAQs.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 83,
                column: "Name",
                value: "FAQs.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 84,
                column: "Name",
                value: "Chapters.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 85,
                column: "Name",
                value: "Chapters.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 86,
                column: "Name",
                value: "Chapters.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 87,
                column: "Name",
                value: "Chapters.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 88,
                column: "Name",
                value: "Chapters.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 89,
                column: "Name",
                value: "Chapters.Delete");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("d3a0c2b3-189a-4250-bb94-d2b0071396cf"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 23, 17, 56, 13, 429, DateTimeKind.Local).AddTicks(5504), null, "pair6@pair6.com", "Banu", "Dik", "TC1246", new byte[] { 155, 169, 173, 7, 228, 181, 252, 66, 8, 69, 224, 1, 86, 239, 44, 34, 120, 40, 44, 190, 36, 11, 10, 0, 73, 38, 116, 76, 124, 112, 196, 209, 242, 110, 32, 214, 116, 58, 198, 255, 4, 190, 212, 157, 129, 216, 245, 149, 38, 20, 74, 11, 141, 80, 153, 118, 142, 154, 246, 228, 192, 146, 226, 173 }, new byte[] { 205, 77, 108, 163, 31, 70, 3, 41, 85, 224, 241, 45, 169, 50, 123, 51, 248, 31, 205, 70, 248, 48, 134, 125, 165, 66, 39, 66, 88, 248, 102, 147, 165, 145, 16, 125, 73, 210, 197, 82, 197, 192, 97, 10, 60, 78, 191, 200, 12, 89, 119, 250, 108, 210, 245, 109, 95, 245, 52, 210, 78, 210, 25, 0, 64, 9, 62, 10, 92, 125, 252, 201, 179, 4, 224, 47, 11, 30, 95, 128, 162, 118, 2, 191, 250, 163, 110, 122, 195, 203, 36, 118, 42, 214, 241, 85, 25, 94, 242, 222, 243, 92, 206, 198, 173, 174, 66, 253, 60, 31, 29, 167, 192, 16, 223, 185, 49, 154, 49, 154, 29, 233, 136, 210, 253, 193, 140, 131 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("0e2ab8e0-e333-4338-b040-a6dcb6311837"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("d3a0c2b3-189a-4250-bb94-d2b0071396cf") });
        }
    }
}
