using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class miggüncel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("e2a44b51-b125-4f90-bc48-ec762391b753"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7416802f-adcd-4967-b011-b7a97f204ac4"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("83e00ad5-6265-4535-8188-9b97ffc2630b"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 29, 0, 57, 31, 805, DateTimeKind.Local).AddTicks(6857), null, "pair6@pair6.com", "Banu", "Dik", "TC1246", new byte[] { 237, 228, 157, 227, 255, 235, 178, 226, 205, 166, 43, 127, 228, 102, 208, 228, 237, 101, 248, 202, 56, 162, 140, 154, 133, 51, 39, 72, 65, 220, 65, 226, 234, 51, 133, 74, 121, 238, 250, 175, 241, 9, 10, 233, 170, 57, 79, 177, 136, 70, 7, 238, 91, 158, 216, 96, 154, 225, 32, 22, 196, 175, 34, 196 }, new byte[] { 55, 85, 205, 157, 207, 167, 99, 212, 179, 93, 107, 227, 145, 250, 58, 146, 70, 222, 239, 125, 187, 101, 84, 228, 38, 63, 253, 43, 178, 112, 174, 92, 158, 131, 139, 62, 252, 4, 66, 137, 235, 116, 147, 242, 239, 252, 160, 43, 45, 49, 53, 16, 30, 96, 195, 188, 41, 214, 196, 118, 114, 96, 76, 11, 212, 185, 221, 177, 153, 203, 7, 244, 5, 72, 80, 130, 207, 171, 27, 117, 170, 218, 220, 22, 81, 126, 103, 19, 74, 103, 60, 144, 65, 87, 67, 39, 190, 132, 204, 230, 143, 149, 88, 232, 50, 36, 216, 65, 184, 165, 110, 199, 140, 195, 6, 35, 69, 30, 9, 194, 131, 198, 7, 37, 133, 245, 207, 144 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("4fd8ff7b-8bb7-4616-ab39-c286856ce898"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("83e00ad5-6265-4535-8188-9b97ffc2630b") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("4fd8ff7b-8bb7-4616-ab39-c286856ce898"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("83e00ad5-6265-4535-8188-9b97ffc2630b"));

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("e2a44b51-b125-4f90-bc48-ec762391b753"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("8cbc1466-eafa-4e65-a3e6-b616be4f6f12") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("7416802f-adcd-4967-b011-b7a97f204ac4"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 27, 16, 50, 8, 594, DateTimeKind.Local).AddTicks(2913), null, "pair6@pair6.com", "Banu", "Dik", "TC1246", new byte[] { 228, 91, 173, 143, 118, 201, 219, 89, 63, 6, 149, 155, 56, 241, 18, 226, 36, 105, 61, 177, 70, 152, 93, 75, 101, 138, 44, 23, 60, 27, 6, 70, 225, 184, 33, 40, 83, 217, 125, 53, 216, 6, 237, 187, 41, 22, 175, 68, 244, 165, 79, 137, 193, 135, 250, 72, 184, 1, 132, 149, 11, 132, 175, 35 }, new byte[] { 102, 208, 205, 202, 52, 132, 9, 30, 37, 122, 126, 207, 204, 237, 127, 191, 227, 230, 125, 193, 74, 0, 214, 6, 253, 20, 187, 31, 230, 168, 18, 215, 44, 243, 18, 199, 227, 5, 86, 156, 89, 78, 89, 190, 79, 50, 80, 249, 230, 223, 198, 222, 93, 210, 234, 3, 174, 177, 46, 22, 214, 203, 94, 230, 142, 168, 235, 35, 185, 145, 50, 227, 150, 251, 139, 247, 82, 49, 92, 166, 41, 172, 137, 182, 18, 196, 210, 249, 93, 164, 45, 209, 246, 70, 95, 48, 171, 42, 56, 76, 170, 172, 251, 72, 110, 89, 35, 178, 210, 175, 234, 149, 186, 145, 37, 75, 15, 16, 198, 19, 247, 77, 26, 94, 133, 31, 87, 99 }, null, "banudik" });
        }
    }
}
