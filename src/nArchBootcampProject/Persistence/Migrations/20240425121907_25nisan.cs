using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _25nisan : Migration
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

            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Header = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 93, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Announcements.Admin", null },
                    { 94, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Announcements.Read", null },
                    { 95, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Announcements.Write", null },
                    { 96, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Announcements.Create", null },
                    { 97, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Announcements.Update", null },
                    { 98, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Announcements.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("db0f4ff4-9453-4182-9db3-0e97018ec68f"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 25, 15, 19, 6, 635, DateTimeKind.Local).AddTicks(8738), null, "pair6@pair6.com", "Banu", "Dik", "TC1246", new byte[] { 201, 122, 54, 110, 175, 244, 84, 175, 242, 140, 98, 230, 145, 235, 108, 69, 36, 149, 51, 243, 180, 139, 76, 6, 192, 117, 104, 119, 169, 44, 88, 178, 50, 168, 86, 143, 167, 28, 157, 61, 76, 70, 218, 23, 193, 214, 99, 114, 125, 204, 8, 31, 219, 97, 207, 233, 90, 39, 168, 31, 128, 162, 249, 211 }, new byte[] { 123, 157, 223, 62, 132, 78, 36, 71, 235, 107, 199, 145, 232, 254, 174, 202, 9, 40, 12, 52, 74, 53, 136, 61, 85, 86, 118, 232, 234, 19, 40, 155, 53, 216, 73, 133, 134, 28, 143, 128, 34, 218, 10, 43, 225, 228, 224, 177, 18, 188, 19, 201, 100, 93, 209, 185, 196, 107, 45, 60, 235, 219, 196, 246, 142, 12, 159, 87, 164, 19, 247, 28, 167, 72, 221, 105, 142, 23, 54, 244, 212, 177, 127, 218, 198, 131, 205, 242, 64, 119, 117, 2, 32, 205, 120, 2, 14, 193, 241, 218, 212, 161, 94, 141, 226, 97, 122, 75, 229, 93, 200, 48, 139, 81, 134, 59, 16, 22, 120, 184, 140, 219, 212, 28, 8, 234, 134, 77 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("5699c9df-dcfb-46ca-8e50-154759ee50af"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("db0f4ff4-9453-4182-9db3-0e97018ec68f") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Announcements");

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
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("5699c9df-dcfb-46ca-8e50-154759ee50af"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("db0f4ff4-9453-4182-9db3-0e97018ec68f"));

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
