using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migAddedDescToInstructor : Migration
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
                name: "Description",
                table: "Instructors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("bb99e753-8824-4502-aecb-352e346f7f4e"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 25, 14, 28, 41, 175, DateTimeKind.Local).AddTicks(1703), null, "pair6@pair6.com", "Banu", "Dik", "TC1246", new byte[] { 182, 175, 182, 201, 139, 177, 176, 4, 25, 1, 62, 116, 15, 28, 91, 177, 209, 2, 163, 41, 146, 59, 143, 63, 87, 59, 217, 33, 155, 167, 91, 39, 250, 238, 99, 243, 137, 227, 153, 156, 19, 171, 29, 99, 214, 248, 153, 203, 71, 228, 227, 250, 83, 106, 192, 106, 189, 188, 61, 47, 85, 132, 135, 168 }, new byte[] { 217, 222, 111, 155, 36, 216, 28, 200, 115, 211, 8, 86, 114, 66, 77, 174, 150, 110, 202, 79, 134, 181, 178, 211, 202, 117, 208, 27, 122, 136, 2, 90, 230, 232, 116, 49, 152, 160, 157, 172, 141, 43, 21, 218, 188, 124, 43, 6, 233, 106, 151, 27, 35, 37, 195, 182, 38, 246, 238, 175, 21, 211, 30, 169, 249, 236, 131, 53, 106, 64, 193, 251, 0, 96, 59, 58, 160, 115, 28, 113, 57, 129, 158, 53, 38, 149, 172, 187, 220, 160, 36, 50, 199, 5, 34, 89, 79, 123, 69, 164, 136, 77, 109, 181, 162, 231, 29, 126, 234, 170, 63, 99, 139, 152, 248, 161, 201, 167, 90, 252, 186, 252, 80, 30, 45, 50, 53, 109 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("1d5bb250-8115-4cad-8536-fddf0c688eeb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("bb99e753-8824-4502-aecb-352e346f7f4e") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("1d5bb250-8115-4cad-8536-fddf0c688eeb"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bb99e753-8824-4502-aecb-352e346f7f4e"));

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Instructors");

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
