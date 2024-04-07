using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("a7fc6e21-7d88-4849-b5e5-b36fa4fa4ad5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3a0a8944-7fd6-4269-a07d-3af27eea1168"));

            migrationBuilder.AlterColumn<int>(
                name: "BootcampImageId",
                table: "Bootcamps",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("abc43741-d786-45d5-9ae6-bcd917af509c"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 2, 15, 21, 30, 605, DateTimeKind.Local).AddTicks(2923), null, "banudik_34@hotmail.com", "Banu", "Dik", "TC1246", new byte[] { 111, 38, 43, 166, 46, 49, 40, 82, 195, 110, 237, 200, 186, 72, 47, 86, 233, 172, 23, 212, 240, 30, 59, 131, 228, 81, 222, 188, 12, 46, 117, 53, 235, 77, 81, 7, 57, 107, 42, 166, 39, 91, 161, 151, 16, 172, 34, 211, 154, 129, 38, 203, 218, 157, 191, 192, 54, 49, 161, 209, 168, 201, 117, 46 }, new byte[] { 221, 96, 118, 239, 21, 251, 28, 163, 122, 186, 67, 163, 76, 184, 197, 46, 2, 32, 37, 91, 175, 126, 240, 212, 68, 198, 20, 143, 119, 110, 63, 49, 209, 188, 165, 99, 16, 254, 20, 22, 127, 135, 74, 33, 54, 152, 17, 242, 40, 116, 67, 105, 174, 116, 169, 56, 239, 155, 164, 36, 15, 6, 7, 49, 206, 103, 69, 73, 121, 28, 228, 137, 33, 150, 214, 115, 228, 85, 152, 70, 185, 164, 3, 124, 195, 70, 133, 82, 148, 176, 152, 108, 41, 128, 16, 249, 131, 210, 143, 136, 29, 129, 82, 175, 205, 207, 16, 182, 55, 38, 138, 42, 35, 113, 32, 115, 45, 239, 47, 178, 148, 60, 126, 243, 57, 248, 78, 174 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("30f7abc6-2f94-4986-b664-089b7598c5e8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("abc43741-d786-45d5-9ae6-bcd917af509c") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("30f7abc6-2f94-4986-b664-089b7598c5e8"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("abc43741-d786-45d5-9ae6-bcd917af509c"));

            migrationBuilder.AlterColumn<string>(
                name: "BootcampImageId",
                table: "Bootcamps",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("3a0a8944-7fd6-4269-a07d-3af27eea1168"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 25, 3, 48, 30, 645, DateTimeKind.Local).AddTicks(8405), null, "banudik_34@hotmail.com", "Banu", "Dik", "TC1246", new byte[] { 254, 92, 174, 164, 206, 24, 81, 217, 112, 93, 125, 253, 221, 149, 177, 229, 178, 13, 160, 207, 116, 165, 134, 48, 163, 200, 225, 89, 131, 204, 7, 27, 146, 140, 126, 66, 196, 220, 159, 157, 226, 103, 200, 5, 197, 75, 254, 16, 247, 205, 115, 109, 146, 45, 131, 112, 116, 59, 190, 3, 165, 230, 104, 7 }, new byte[] { 186, 214, 76, 60, 176, 184, 136, 68, 40, 155, 104, 165, 152, 78, 133, 130, 213, 255, 41, 44, 5, 111, 96, 178, 148, 142, 149, 165, 116, 55, 111, 251, 136, 190, 15, 83, 252, 176, 101, 58, 253, 101, 131, 154, 248, 49, 118, 206, 24, 16, 32, 188, 16, 147, 134, 82, 131, 2, 144, 198, 169, 170, 172, 195, 197, 10, 150, 65, 8, 96, 195, 75, 122, 207, 33, 196, 206, 63, 91, 223, 59, 178, 83, 9, 41, 194, 119, 178, 46, 187, 153, 60, 132, 73, 46, 35, 111, 36, 229, 3, 132, 188, 62, 191, 149, 99, 47, 166, 231, 66, 160, 240, 127, 62, 149, 158, 155, 56, 162, 209, 60, 247, 1, 137, 200, 140, 7, 179 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("a7fc6e21-7d88-4849-b5e5-b36fa4fa4ad5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("3a0a8944-7fd6-4269-a07d-3af27eea1168") });
        }
    }
}
