using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migCertificate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("680cdf6d-518b-46fc-ae85-0c02938f3912"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0d89b4ea-f818-45bb-a130-73d263143161"));

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BootcampId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certificates_Applicants_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Certificates_Bootcamps_BootcampId",
                        column: x => x.BootcampId,
                        principalTable: "Bootcamps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 99, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Certificates.Admin", null },
                    { 100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Certificates.Read", null },
                    { 101, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Certificates.Write", null },
                    { 102, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Certificates.Create", null },
                    { 103, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Certificates.Update", null },
                    { 104, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Certificates.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("d3df1a25-8c65-4673-b10c-93e71e1c5f1b"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 18, 16, 55, 30, 782, DateTimeKind.Local).AddTicks(9850), null, "pair6@pair6.com", "Banu", "Dik", "TC1246", new byte[] { 14, 157, 253, 218, 225, 70, 36, 27, 63, 52, 100, 44, 22, 93, 97, 76, 170, 107, 108, 141, 65, 219, 98, 146, 104, 228, 36, 253, 159, 173, 106, 111, 40, 127, 68, 120, 45, 39, 20, 123, 128, 60, 142, 39, 102, 33, 219, 108, 122, 81, 230, 32, 196, 144, 20, 56, 172, 134, 16, 63, 156, 109, 166, 196 }, new byte[] { 69, 127, 104, 4, 112, 220, 180, 235, 199, 0, 68, 234, 101, 25, 81, 150, 195, 101, 250, 236, 97, 246, 116, 75, 144, 32, 237, 222, 156, 65, 45, 221, 115, 113, 97, 13, 120, 148, 245, 155, 30, 224, 86, 91, 219, 221, 97, 51, 194, 16, 79, 35, 126, 80, 238, 34, 53, 41, 208, 122, 233, 69, 213, 140, 213, 20, 162, 41, 186, 187, 173, 181, 252, 18, 74, 92, 250, 100, 237, 2, 218, 84, 169, 84, 183, 145, 169, 179, 97, 122, 210, 131, 96, 110, 128, 155, 37, 68, 57, 221, 214, 8, 247, 7, 24, 48, 53, 215, 4, 46, 185, 125, 189, 49, 93, 110, 1, 136, 239, 226, 37, 140, 149, 77, 73, 183, 230, 42 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("6b165552-3c18-4086-81fb-3dedcf6d9564"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("d3df1a25-8c65-4673-b10c-93e71e1c5f1b") });

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_ApplicantId",
                table: "Certificates",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_BootcampId",
                table: "Certificates",
                column: "BootcampId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Certificates");

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
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("6b165552-3c18-4086-81fb-3dedcf6d9564"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d3df1a25-8c65-4673-b10c-93e71e1c5f1b"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("0d89b4ea-f818-45bb-a130-73d263143161"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 14, 3, 15, 32, 739, DateTimeKind.Local).AddTicks(424), null, "pair6@pair6.com", "Banu", "Dik", "TC1246", new byte[] { 158, 239, 69, 209, 26, 135, 196, 0, 63, 121, 101, 230, 224, 41, 171, 127, 3, 79, 160, 179, 136, 54, 10, 154, 57, 4, 227, 3, 125, 165, 29, 166, 15, 149, 172, 15, 253, 116, 230, 84, 178, 113, 107, 254, 5, 80, 4, 41, 58, 134, 146, 8, 112, 124, 152, 64, 16, 61, 248, 30, 132, 151, 253, 90 }, new byte[] { 146, 250, 144, 222, 86, 35, 104, 100, 25, 171, 162, 105, 53, 179, 215, 116, 242, 226, 55, 66, 75, 195, 139, 221, 252, 30, 124, 35, 223, 31, 219, 115, 62, 174, 64, 225, 143, 182, 114, 118, 240, 46, 25, 78, 169, 99, 69, 59, 163, 150, 208, 32, 175, 213, 4, 8, 124, 80, 67, 101, 237, 201, 75, 82, 50, 94, 151, 233, 34, 137, 39, 74, 131, 33, 242, 245, 95, 128, 90, 134, 85, 139, 65, 63, 142, 139, 128, 78, 20, 237, 66, 129, 67, 49, 242, 138, 141, 19, 120, 114, 44, 100, 124, 192, 84, 89, 140, 241, 227, 230, 176, 78, 12, 77, 203, 241, 113, 254, 187, 198, 40, 45, 72, 181, 170, 143, 81, 255 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("680cdf6d-518b-46fc-ae85-0c02938f3912"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("0d89b4ea-f818-45bb-a130-73d263143161") });
        }
    }
}
