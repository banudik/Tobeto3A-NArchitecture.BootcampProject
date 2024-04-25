using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migFAQ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("60f389ac-e001-41d7-8833-ba7cc5b01323"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("683f8b4c-e916-4bc5-877e-60802c320bce"));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Bootcamps",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "FAQs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 78, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "FAQs.Admin", null },
                    { 79, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "FAQs.Read", null },
                    { 80, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "FAQs.Write", null },
                    { 81, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "FAQs.Create", null },
                    { 82, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "FAQs.Update", null },
                    { 83, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "FAQs.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("eaa33389-fd15-44ad-a630-009d4b796139"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 23, 17, 2, 22, 13, DateTimeKind.Local).AddTicks(7960), null, "banudik_34@hotmail.com", "Banu", "Dik", "TC1246", new byte[] { 5, 187, 44, 194, 215, 230, 45, 111, 80, 226, 118, 71, 158, 156, 231, 226, 177, 214, 17, 148, 213, 149, 26, 227, 235, 128, 130, 237, 186, 160, 134, 186, 146, 119, 78, 7, 171, 132, 142, 93, 10, 213, 149, 62, 5, 132, 23, 164, 148, 74, 249, 135, 76, 167, 59, 233, 81, 147, 112, 197, 21, 210, 104, 157 }, new byte[] { 231, 0, 231, 30, 74, 254, 108, 56, 117, 28, 26, 129, 82, 156, 132, 31, 155, 139, 188, 88, 32, 213, 138, 6, 242, 96, 2, 93, 126, 146, 179, 179, 53, 54, 118, 100, 134, 234, 62, 234, 218, 94, 45, 193, 115, 250, 24, 251, 117, 86, 196, 142, 165, 75, 175, 69, 226, 41, 125, 25, 130, 105, 241, 152, 59, 248, 218, 231, 158, 113, 26, 211, 155, 242, 69, 35, 152, 100, 230, 139, 30, 142, 35, 183, 127, 99, 28, 109, 230, 167, 17, 199, 199, 57, 190, 48, 7, 118, 201, 147, 188, 39, 2, 183, 104, 180, 189, 150, 237, 233, 59, 185, 237, 45, 101, 145, 210, 231, 107, 132, 247, 199, 162, 127, 22, 249, 47, 210 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("2f744a22-69f9-4c11-9064-4f46a902c761"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("eaa33389-fd15-44ad-a630-009d4b796139") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FAQs");

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("2f744a22-69f9-4c11-9064-4f46a902c761"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("eaa33389-fd15-44ad-a630-009d4b796139"));

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Bootcamps");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("683f8b4c-e916-4bc5-877e-60802c320bce"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 15, 22, 49, 52, 919, DateTimeKind.Local).AddTicks(3061), null, "banudik_34@hotmail.com", "Banu", "Dik", "TC1246", new byte[] { 31, 44, 237, 200, 58, 65, 42, 28, 175, 255, 47, 113, 13, 28, 53, 1, 53, 195, 220, 115, 36, 130, 54, 88, 138, 28, 215, 131, 114, 92, 3, 7, 201, 26, 0, 14, 227, 94, 59, 233, 35, 248, 82, 59, 242, 88, 246, 229, 126, 41, 194, 248, 226, 6, 191, 22, 188, 134, 168, 70, 7, 212, 108, 146 }, new byte[] { 20, 171, 153, 106, 248, 162, 168, 132, 66, 4, 83, 16, 213, 97, 10, 48, 116, 250, 73, 209, 37, 239, 18, 43, 225, 219, 255, 45, 16, 129, 65, 110, 142, 36, 235, 1, 191, 119, 65, 92, 219, 101, 134, 206, 156, 60, 22, 158, 17, 21, 220, 1, 18, 92, 188, 75, 107, 72, 60, 243, 162, 235, 155, 79, 223, 23, 73, 130, 205, 31, 3, 245, 160, 22, 243, 187, 240, 70, 130, 228, 52, 77, 206, 73, 118, 74, 120, 67, 117, 158, 208, 144, 17, 177, 104, 83, 65, 29, 236, 116, 221, 236, 79, 168, 208, 79, 143, 141, 101, 211, 47, 194, 118, 89, 102, 198, 155, 246, 137, 218, 249, 0, 90, 220, 227, 252, 226, 84 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("60f389ac-e001-41d7-8833-ba7cc5b01323"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("683f8b4c-e916-4bc5-877e-60802c320bce") });
        }
    }
}
