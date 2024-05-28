using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RefactorResetPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("26b68322-ded4-48e1-89b4-98e9aefa0342"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c0f27fe8-6047-4a13-befc-5ca7d301969a"));

            migrationBuilder.AlterColumn<bool>(
                name: "ResetPasswordToken",
                table: "EmailAuthenticators",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("7416802f-adcd-4967-b011-b7a97f204ac4"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 27, 16, 50, 8, 594, DateTimeKind.Local).AddTicks(2913), null, "pair6@pair6.com", "Banu", "Dik", "TC1246", new byte[] { 228, 91, 173, 143, 118, 201, 219, 89, 63, 6, 149, 155, 56, 241, 18, 226, 36, 105, 61, 177, 70, 152, 93, 75, 101, 138, 44, 23, 60, 27, 6, 70, 225, 184, 33, 40, 83, 217, 125, 53, 216, 6, 237, 187, 41, 22, 175, 68, 244, 165, 79, 137, 193, 135, 250, 72, 184, 1, 132, 149, 11, 132, 175, 35 }, new byte[] { 102, 208, 205, 202, 52, 132, 9, 30, 37, 122, 126, 207, 204, 237, 127, 191, 227, 230, 125, 193, 74, 0, 214, 6, 253, 20, 187, 31, 230, 168, 18, 215, 44, 243, 18, 199, 227, 5, 86, 156, 89, 78, 89, 190, 79, 50, 80, 249, 230, 223, 198, 222, 93, 210, 234, 3, 174, 177, 46, 22, 214, 203, 94, 230, 142, 168, 235, 35, 185, 145, 50, 227, 150, 251, 139, 247, 82, 49, 92, 166, 41, 172, 137, 182, 18, 196, 210, 249, 93, 164, 45, 209, 246, 70, 95, 48, 171, 42, 56, 76, 170, 172, 251, 72, 110, 89, 35, 178, 210, 175, 234, 149, 186, 145, 37, 75, 15, 16, 198, 19, 247, 77, 26, 94, 133, 31, 87, 99 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("e2a44b51-b125-4f90-bc48-ec762391b753"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("7416802f-adcd-4967-b011-b7a97f204ac4") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("e2a44b51-b125-4f90-bc48-ec762391b753"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7416802f-adcd-4967-b011-b7a97f204ac4"));

            migrationBuilder.AlterColumn<string>(
                name: "ResetPasswordToken",
                table: "EmailAuthenticators",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("c0f27fe8-6047-4a13-befc-5ca7d301969a"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 19, 0, 33, 59, 993, DateTimeKind.Local).AddTicks(6475), null, "pair6@pair6.com", "Banu", "Dik", "TC1246", new byte[] { 78, 16, 245, 24, 34, 227, 83, 124, 114, 134, 111, 13, 162, 245, 179, 92, 103, 247, 168, 0, 118, 86, 58, 93, 136, 218, 45, 42, 156, 136, 190, 154, 26, 150, 86, 218, 65, 197, 80, 222, 124, 250, 190, 251, 5, 214, 231, 92, 246, 1, 7, 204, 180, 141, 154, 21, 108, 219, 20, 6, 203, 86, 85, 178 }, new byte[] { 63, 133, 190, 230, 69, 217, 137, 225, 68, 226, 218, 169, 135, 47, 127, 128, 112, 159, 94, 138, 116, 210, 79, 241, 168, 47, 139, 211, 166, 196, 246, 210, 57, 184, 10, 34, 139, 130, 164, 201, 114, 164, 252, 81, 202, 157, 110, 46, 205, 227, 103, 225, 123, 31, 60, 90, 167, 83, 137, 204, 124, 106, 15, 17, 133, 228, 162, 177, 114, 182, 151, 231, 251, 175, 208, 168, 147, 230, 83, 125, 28, 17, 197, 229, 227, 141, 21, 97, 29, 113, 135, 49, 194, 63, 139, 143, 237, 33, 89, 213, 42, 87, 119, 223, 16, 205, 24, 188, 234, 91, 252, 41, 112, 41, 207, 46, 204, 217, 142, 250, 23, 222, 139, 169, 169, 219, 249, 128 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("26b68322-ded4-48e1-89b4-98e9aefa0342"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("c0f27fe8-6047-4a13-befc-5ca7d301969a") });
        }
    }
}
