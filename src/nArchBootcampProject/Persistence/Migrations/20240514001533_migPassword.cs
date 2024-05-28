using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("90e0542e-baa0-48fb-889f-4a80f487d782"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a19eb723-158a-4444-ba01-8deeed57720f"));

            migrationBuilder.AddColumn<string>(
                name: "ResetPasswordToken",
                table: "EmailAuthenticators",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ResetPasswordTokenExpiry",
                table: "EmailAuthenticators",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("0d89b4ea-f818-45bb-a130-73d263143161"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 14, 3, 15, 32, 739, DateTimeKind.Local).AddTicks(424), null, "pair6@pair6.com", "Banu", "Dik", "TC1246", new byte[] { 158, 239, 69, 209, 26, 135, 196, 0, 63, 121, 101, 230, 224, 41, 171, 127, 3, 79, 160, 179, 136, 54, 10, 154, 57, 4, 227, 3, 125, 165, 29, 166, 15, 149, 172, 15, 253, 116, 230, 84, 178, 113, 107, 254, 5, 80, 4, 41, 58, 134, 146, 8, 112, 124, 152, 64, 16, 61, 248, 30, 132, 151, 253, 90 }, new byte[] { 146, 250, 144, 222, 86, 35, 104, 100, 25, 171, 162, 105, 53, 179, 215, 116, 242, 226, 55, 66, 75, 195, 139, 221, 252, 30, 124, 35, 223, 31, 219, 115, 62, 174, 64, 225, 143, 182, 114, 118, 240, 46, 25, 78, 169, 99, 69, 59, 163, 150, 208, 32, 175, 213, 4, 8, 124, 80, 67, 101, 237, 201, 75, 82, 50, 94, 151, 233, 34, 137, 39, 74, 131, 33, 242, 245, 95, 128, 90, 134, 85, 139, 65, 63, 142, 139, 128, 78, 20, 237, 66, 129, 67, 49, 242, 138, 141, 19, 120, 114, 44, 100, 124, 192, 84, 89, 140, 241, 227, 230, 176, 78, 12, 77, 203, 241, 113, 254, 187, 198, 40, 45, 72, 181, 170, 143, 81, 255 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("680cdf6d-518b-46fc-ae85-0c02938f3912"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("0d89b4ea-f818-45bb-a130-73d263143161") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("680cdf6d-518b-46fc-ae85-0c02938f3912"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0d89b4ea-f818-45bb-a130-73d263143161"));

            migrationBuilder.DropColumn(
                name: "ResetPasswordToken",
                table: "EmailAuthenticators");

            migrationBuilder.DropColumn(
                name: "ResetPasswordTokenExpiry",
                table: "EmailAuthenticators");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("a19eb723-158a-4444-ba01-8deeed57720f"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 25, 13, 54, 59, 545, DateTimeKind.Local).AddTicks(9907), null, "pair6@pair6.com", "Banu", "Dik", "TC1246", new byte[] { 239, 218, 203, 150, 116, 81, 185, 143, 60, 254, 206, 63, 237, 73, 179, 96, 80, 140, 41, 160, 182, 29, 185, 210, 141, 86, 197, 231, 93, 196, 162, 203, 193, 159, 56, 223, 95, 84, 67, 210, 250, 231, 137, 220, 95, 145, 197, 54, 102, 236, 62, 207, 193, 9, 50, 37, 70, 214, 172, 132, 87, 208, 117, 46 }, new byte[] { 67, 34, 14, 74, 168, 152, 73, 25, 179, 28, 132, 182, 126, 40, 9, 45, 198, 243, 112, 135, 252, 159, 67, 100, 183, 136, 148, 154, 231, 186, 238, 159, 198, 103, 242, 74, 184, 244, 238, 209, 210, 185, 114, 187, 201, 241, 84, 153, 168, 1, 176, 90, 45, 155, 63, 248, 78, 17, 224, 101, 9, 201, 179, 2, 237, 15, 116, 104, 242, 96, 7, 82, 41, 161, 31, 118, 232, 88, 118, 251, 189, 217, 84, 203, 236, 191, 99, 119, 160, 170, 105, 142, 124, 216, 148, 218, 202, 170, 213, 46, 30, 0, 73, 34, 191, 137, 188, 107, 134, 100, 88, 102, 244, 156, 79, 192, 133, 243, 130, 105, 32, 163, 166, 138, 200, 104, 7, 102 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("90e0542e-baa0-48fb-889f-4a80f487d782"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("a19eb723-158a-4444-ba01-8deeed57720f") });
        }
    }
}
