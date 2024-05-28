using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class may26 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("340ae187-a773-482e-ba85-254e22483fc7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f47bb1e9-77e4-4404-b580-526036c76723"));

            migrationBuilder.DropColumn(
                name: "BootcampChapterId",
                table: "Comments");

            migrationBuilder.CreateTable(
                name: "BootcampLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BootcampId = table.Column<int>(type: "int", nullable: false),
                    ChapterId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BootcampLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BootcampLogs_Bootcamps_BootcampId",
                        column: x => x.BootcampId,
                        principalTable: "Bootcamps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BootcampLogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 105, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "BootcampLogs.Admin", null },
                    { 106, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "BootcampLogs.Read", null },
                    { 107, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "BootcampLogs.Write", null },
                    { 108, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "BootcampLogs.Create", null },
                    { 109, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "BootcampLogs.Update", null },
                    { 110, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "BootcampLogs.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("c8a96723-faee-4587-b76a-849d866912fe"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 26, 17, 14, 48, 148, DateTimeKind.Local).AddTicks(2710), null, "pair6@pair6.com", "Banu", "Dik", "TC1246", new byte[] { 5, 210, 89, 74, 164, 176, 102, 205, 89, 158, 96, 112, 69, 81, 81, 190, 70, 152, 208, 48, 7, 26, 77, 160, 234, 50, 75, 141, 246, 153, 166, 23, 254, 215, 242, 134, 26, 63, 38, 80, 197, 225, 69, 112, 52, 166, 94, 39, 165, 87, 149, 247, 137, 53, 138, 244, 40, 125, 9, 229, 52, 176, 208, 228 }, new byte[] { 250, 95, 18, 44, 120, 124, 213, 83, 161, 58, 101, 173, 107, 247, 114, 122, 203, 125, 71, 5, 166, 201, 171, 231, 189, 187, 253, 77, 201, 79, 104, 40, 195, 120, 235, 107, 85, 90, 99, 253, 158, 182, 252, 191, 31, 197, 185, 148, 23, 62, 23, 55, 91, 76, 17, 198, 44, 249, 151, 246, 201, 59, 195, 145, 144, 174, 152, 84, 247, 217, 225, 113, 82, 73, 9, 102, 64, 20, 81, 90, 234, 226, 217, 107, 117, 26, 182, 218, 110, 127, 112, 161, 56, 221, 78, 248, 195, 138, 113, 20, 107, 116, 149, 196, 113, 241, 90, 97, 79, 151, 151, 16, 164, 85, 139, 138, 20, 19, 16, 194, 119, 55, 193, 3, 179, 233, 116, 45 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("86f03eab-f67e-4eb5-b690-ad125579ad9c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("c8a96723-faee-4587-b76a-849d866912fe") });

            migrationBuilder.CreateIndex(
                name: "IX_BootcampLogs_BootcampId",
                table: "BootcampLogs",
                column: "BootcampId");

            migrationBuilder.CreateIndex(
                name: "IX_BootcampLogs_UserId",
                table: "BootcampLogs",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BootcampLogs");

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("86f03eab-f67e-4eb5-b690-ad125579ad9c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c8a96723-faee-4587-b76a-849d866912fe"));

            migrationBuilder.AddColumn<int>(
                name: "BootcampChapterId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("f47bb1e9-77e4-4404-b580-526036c76723"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 21, 14, 55, 15, 461, DateTimeKind.Local).AddTicks(491), null, "pair6@pair6.com", "Banu", "Dik", "TC1246", new byte[] { 237, 171, 210, 176, 88, 248, 88, 184, 69, 117, 164, 136, 84, 111, 131, 2, 54, 80, 85, 0, 248, 49, 56, 6, 174, 248, 17, 70, 24, 65, 228, 109, 85, 2, 127, 18, 216, 115, 31, 199, 159, 97, 166, 103, 236, 34, 98, 42, 80, 81, 57, 206, 190, 120, 50, 78, 179, 241, 224, 44, 68, 79, 154, 16 }, new byte[] { 28, 62, 237, 76, 212, 95, 224, 67, 233, 180, 193, 161, 69, 116, 87, 146, 175, 214, 143, 153, 214, 215, 214, 199, 192, 50, 142, 79, 76, 202, 224, 233, 38, 187, 28, 113, 89, 190, 28, 87, 161, 34, 214, 183, 237, 21, 164, 113, 100, 219, 17, 148, 69, 188, 245, 6, 187, 237, 111, 24, 210, 159, 18, 106, 5, 168, 234, 129, 128, 232, 99, 241, 167, 197, 113, 45, 152, 24, 240, 27, 107, 185, 233, 140, 32, 9, 13, 6, 17, 7, 69, 241, 130, 93, 39, 176, 238, 245, 212, 153, 209, 221, 176, 4, 184, 225, 195, 167, 55, 88, 196, 143, 63, 105, 68, 204, 61, 160, 139, 58, 172, 117, 198, 177, 82, 149, 179, 78 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("340ae187-a773-482e-ba85-254e22483fc7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("f47bb1e9-77e4-4404-b580-526036c76723") });
        }
    }
}
