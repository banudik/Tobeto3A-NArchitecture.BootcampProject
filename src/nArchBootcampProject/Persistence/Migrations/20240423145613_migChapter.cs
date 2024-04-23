using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migChapter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("c1d01347-068d-4dd8-bab6-fafd908c2215"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0ca1114b-10c7-4dd2-a408-0148174809b3"));

            migrationBuilder.CreateTable(
                name: "Chapters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BootcampId = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chapters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chapters_Bootcamps_BootcampId",
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
                    { 84, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Chapters.Admin", null },
                    { 85, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Chapters.Read", null },
                    { 86, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Chapters.Write", null },
                    { 87, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Chapters.Create", null },
                    { 88, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Chapters.Update", null },
                    { 89, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Chapters.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("d3a0c2b3-189a-4250-bb94-d2b0071396cf"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 23, 17, 56, 13, 429, DateTimeKind.Local).AddTicks(5504), null, "pair6@pair6.com", "Banu", "Dik", "TC1246", new byte[] { 155, 169, 173, 7, 228, 181, 252, 66, 8, 69, 224, 1, 86, 239, 44, 34, 120, 40, 44, 190, 36, 11, 10, 0, 73, 38, 116, 76, 124, 112, 196, 209, 242, 110, 32, 214, 116, 58, 198, 255, 4, 190, 212, 157, 129, 216, 245, 149, 38, 20, 74, 11, 141, 80, 153, 118, 142, 154, 246, 228, 192, 146, 226, 173 }, new byte[] { 205, 77, 108, 163, 31, 70, 3, 41, 85, 224, 241, 45, 169, 50, 123, 51, 248, 31, 205, 70, 248, 48, 134, 125, 165, 66, 39, 66, 88, 248, 102, 147, 165, 145, 16, 125, 73, 210, 197, 82, 197, 192, 97, 10, 60, 78, 191, 200, 12, 89, 119, 250, 108, 210, 245, 109, 95, 245, 52, 210, 78, 210, 25, 0, 64, 9, 62, 10, 92, 125, 252, 201, 179, 4, 224, 47, 11, 30, 95, 128, 162, 118, 2, 191, 250, 163, 110, 122, 195, 203, 36, 118, 42, 214, 241, 85, 25, 94, 242, 222, 243, 92, 206, 198, 173, 174, 66, 253, 60, 31, 29, 167, 192, 16, 223, 185, 49, 154, 49, 154, 29, 233, 136, 210, 253, 193, 140, 131 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("0e2ab8e0-e333-4338-b040-a6dcb6311837"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("d3a0c2b3-189a-4250-bb94-d2b0071396cf") });

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_BootcampId",
                table: "Chapters",
                column: "BootcampId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chapters");

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("0e2ab8e0-e333-4338-b040-a6dcb6311837"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d3a0c2b3-189a-4250-bb94-d2b0071396cf"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("0ca1114b-10c7-4dd2-a408-0148174809b3"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 22, 13, 6, 36, 649, DateTimeKind.Local).AddTicks(9854), null, "pair6@pair6.com", "Banu", "Dik", "TC1246", new byte[] { 210, 200, 17, 35, 231, 69, 71, 250, 128, 233, 55, 68, 192, 18, 1, 141, 108, 219, 157, 104, 167, 216, 217, 122, 180, 196, 135, 152, 31, 215, 126, 248, 253, 253, 165, 178, 205, 243, 78, 156, 205, 201, 167, 255, 99, 12, 159, 128, 91, 37, 171, 155, 120, 136, 185, 178, 195, 178, 159, 204, 58, 87, 80, 131 }, new byte[] { 51, 200, 244, 175, 79, 115, 139, 32, 170, 139, 160, 56, 104, 55, 7, 31, 3, 94, 153, 213, 13, 224, 211, 228, 34, 114, 245, 121, 214, 120, 107, 127, 100, 29, 144, 86, 64, 180, 229, 190, 190, 102, 206, 119, 121, 15, 226, 82, 128, 224, 151, 113, 49, 133, 129, 115, 167, 179, 186, 146, 64, 103, 158, 188, 253, 154, 180, 125, 192, 59, 52, 239, 156, 103, 137, 149, 75, 202, 87, 214, 184, 143, 136, 234, 140, 56, 231, 171, 85, 37, 27, 38, 101, 57, 20, 190, 180, 91, 196, 53, 228, 196, 204, 113, 206, 139, 251, 1, 212, 23, 231, 59, 164, 176, 248, 80, 23, 133, 179, 101, 50, 209, 4, 239, 107, 172, 61, 38 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("c1d01347-068d-4dd8-bab6-fafd908c2215"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("0ca1114b-10c7-4dd2-a408-0148174809b3") });
        }
    }
}
