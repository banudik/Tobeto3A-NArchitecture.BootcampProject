using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migCertificateRefactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_Applicants_ApplicantId",
                table: "Certificates");

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
                values: new object[] { new Guid("c0f27fe8-6047-4a13-befc-5ca7d301969a"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 19, 0, 33, 59, 993, DateTimeKind.Local).AddTicks(6475), null, "pair6@pair6.com", "Banu", "Dik", "TC1246", new byte[] { 78, 16, 245, 24, 34, 227, 83, 124, 114, 134, 111, 13, 162, 245, 179, 92, 103, 247, 168, 0, 118, 86, 58, 93, 136, 218, 45, 42, 156, 136, 190, 154, 26, 150, 86, 218, 65, 197, 80, 222, 124, 250, 190, 251, 5, 214, 231, 92, 246, 1, 7, 204, 180, 141, 154, 21, 108, 219, 20, 6, 203, 86, 85, 178 }, new byte[] { 63, 133, 190, 230, 69, 217, 137, 225, 68, 226, 218, 169, 135, 47, 127, 128, 112, 159, 94, 138, 116, 210, 79, 241, 168, 47, 139, 211, 166, 196, 246, 210, 57, 184, 10, 34, 139, 130, 164, 201, 114, 164, 252, 81, 202, 157, 110, 46, 205, 227, 103, 225, 123, 31, 60, 90, 167, 83, 137, 204, 124, 106, 15, 17, 133, 228, 162, 177, 114, 182, 151, 231, 251, 175, 208, 168, 147, 230, 83, 125, 28, 17, 197, 229, 227, 141, 21, 97, 29, 113, 135, 49, 194, 63, 139, 143, 237, 33, 89, 213, 42, 87, 119, 223, 16, 205, 24, 188, 234, 91, 252, 41, 112, 41, 207, 46, 204, 217, 142, 250, 23, 222, 139, 169, 169, 219, 249, 128 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("26b68322-ded4-48e1-89b4-98e9aefa0342"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("c0f27fe8-6047-4a13-befc-5ca7d301969a") });

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_Users_ApplicantId",
                table: "Certificates",
                column: "ApplicantId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_Users_ApplicantId",
                table: "Certificates");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("26b68322-ded4-48e1-89b4-98e9aefa0342"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c0f27fe8-6047-4a13-befc-5ca7d301969a"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("d3df1a25-8c65-4673-b10c-93e71e1c5f1b"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 18, 16, 55, 30, 782, DateTimeKind.Local).AddTicks(9850), null, "pair6@pair6.com", "Banu", "Dik", "TC1246", new byte[] { 14, 157, 253, 218, 225, 70, 36, 27, 63, 52, 100, 44, 22, 93, 97, 76, 170, 107, 108, 141, 65, 219, 98, 146, 104, 228, 36, 253, 159, 173, 106, 111, 40, 127, 68, 120, 45, 39, 20, 123, 128, 60, 142, 39, 102, 33, 219, 108, 122, 81, 230, 32, 196, 144, 20, 56, 172, 134, 16, 63, 156, 109, 166, 196 }, new byte[] { 69, 127, 104, 4, 112, 220, 180, 235, 199, 0, 68, 234, 101, 25, 81, 150, 195, 101, 250, 236, 97, 246, 116, 75, 144, 32, 237, 222, 156, 65, 45, 221, 115, 113, 97, 13, 120, 148, 245, 155, 30, 224, 86, 91, 219, 221, 97, 51, 194, 16, 79, 35, 126, 80, 238, 34, 53, 41, 208, 122, 233, 69, 213, 140, 213, 20, 162, 41, 186, 187, 173, 181, 252, 18, 74, 92, 250, 100, 237, 2, 218, 84, 169, 84, 183, 145, 169, 179, 97, 122, 210, 131, 96, 110, 128, 155, 37, 68, 57, 221, 214, 8, 247, 7, 24, 48, 53, 215, 4, 46, 185, 125, 189, 49, 93, 110, 1, 136, 239, 226, 37, 140, 149, 77, 73, 183, 230, 42 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("6b165552-3c18-4086-81fb-3dedcf6d9564"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("d3df1a25-8c65-4673-b10c-93e71e1c5f1b") });

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_Applicants_ApplicantId",
                table: "Certificates",
                column: "ApplicantId",
                principalTable: "Applicants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
