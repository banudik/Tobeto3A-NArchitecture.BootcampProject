using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migChangedCommentRemovedFaQ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FAQs");

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
                keyValue: new Guid("9e203bce-750a-405c-91d7-bf6d8cac8ce5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3cc39bf4-e2d1-4631-b1ff-8902d51c4a63"));

            migrationBuilder.RenameColumn(
                name: "BootcampId",
                table: "Comments",
                newName: "BootcampChapterId");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 81,
                column: "Name",
                value: "Chapters.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 82,
                column: "Name",
                value: "Chapters.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 83,
                column: "Name",
                value: "Chapters.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 84,
                column: "Name",
                value: "Chapters.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 85,
                column: "Name",
                value: "Chapters.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 86,
                column: "Name",
                value: "Chapters.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 87,
                column: "Name",
                value: "Comments.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 88,
                column: "Name",
                value: "Comments.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 89,
                column: "Name",
                value: "Comments.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 90,
                column: "Name",
                value: "Comments.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 91,
                column: "Name",
                value: "Comments.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 92,
                column: "Name",
                value: "Comments.Delete");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("a19eb723-158a-4444-ba01-8deeed57720f"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 25, 13, 54, 59, 545, DateTimeKind.Local).AddTicks(9907), null, "pair6@pair6.com", "Banu", "Dik", "TC1246", new byte[] { 239, 218, 203, 150, 116, 81, 185, 143, 60, 254, 206, 63, 237, 73, 179, 96, 80, 140, 41, 160, 182, 29, 185, 210, 141, 86, 197, 231, 93, 196, 162, 203, 193, 159, 56, 223, 95, 84, 67, 210, 250, 231, 137, 220, 95, 145, 197, 54, 102, 236, 62, 207, 193, 9, 50, 37, 70, 214, 172, 132, 87, 208, 117, 46 }, new byte[] { 67, 34, 14, 74, 168, 152, 73, 25, 179, 28, 132, 182, 126, 40, 9, 45, 198, 243, 112, 135, 252, 159, 67, 100, 183, 136, 148, 154, 231, 186, 238, 159, 198, 103, 242, 74, 184, 244, 238, 209, 210, 185, 114, 187, 201, 241, 84, 153, 168, 1, 176, 90, 45, 155, 63, 248, 78, 17, 224, 101, 9, 201, 179, 2, 237, 15, 116, 104, 242, 96, 7, 82, 41, 161, 31, 118, 232, 88, 118, 251, 189, 217, 84, 203, 236, 191, 99, 119, 160, 170, 105, 142, 124, 216, 148, 218, 202, 170, 213, 46, 30, 0, 73, 34, 191, 137, 188, 107, 134, 100, 88, 102, 244, 156, 79, 192, 133, 243, 130, 105, 32, 163, 166, 138, 200, 104, 7, 102 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("90e0542e-baa0-48fb-889f-4a80f487d782"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("a19eb723-158a-4444-ba01-8deeed57720f") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("90e0542e-baa0-48fb-889f-4a80f487d782"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a19eb723-158a-4444-ba01-8deeed57720f"));

            migrationBuilder.RenameColumn(
                name: "BootcampChapterId",
                table: "Comments",
                newName: "BootcampId");

            migrationBuilder.CreateTable(
                name: "FAQs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQs", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 81,
                column: "Name",
                value: "FAQs.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 82,
                column: "Name",
                value: "FAQs.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 83,
                column: "Name",
                value: "FAQs.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 84,
                column: "Name",
                value: "FAQs.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 85,
                column: "Name",
                value: "FAQs.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 86,
                column: "Name",
                value: "FAQs.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 87,
                column: "Name",
                value: "Chapters.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 88,
                column: "Name",
                value: "Chapters.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 89,
                column: "Name",
                value: "Chapters.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 90,
                column: "Name",
                value: "Chapters.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 91,
                column: "Name",
                value: "Chapters.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 92,
                column: "Name",
                value: "Chapters.Delete");

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 93, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Comments.Admin", null },
                    { 94, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Comments.Read", null },
                    { 95, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Comments.Write", null },
                    { 96, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Comments.Create", null },
                    { 97, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Comments.Update", null },
                    { 98, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Comments.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("3cc39bf4-e2d1-4631-b1ff-8902d51c4a63"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 23, 19, 25, 6, 561, DateTimeKind.Local).AddTicks(1863), null, "pair6@pair6.com", "Banu", "Dik", "TC1246", new byte[] { 35, 19, 152, 74, 45, 32, 3, 231, 120, 179, 25, 157, 133, 60, 66, 62, 210, 135, 244, 133, 65, 26, 49, 224, 96, 217, 122, 247, 182, 50, 78, 73, 68, 76, 230, 203, 111, 22, 222, 66, 14, 59, 43, 0, 67, 159, 156, 107, 62, 176, 39, 11, 110, 146, 157, 242, 186, 75, 190, 162, 219, 193, 117, 19 }, new byte[] { 165, 49, 98, 195, 122, 26, 196, 47, 95, 225, 220, 38, 14, 114, 66, 198, 44, 107, 153, 74, 123, 140, 245, 136, 22, 178, 25, 74, 77, 50, 89, 241, 239, 90, 154, 166, 20, 122, 195, 12, 205, 175, 131, 11, 134, 186, 4, 119, 98, 99, 85, 203, 98, 41, 17, 165, 5, 186, 63, 140, 31, 33, 224, 83, 54, 232, 164, 194, 155, 55, 167, 80, 136, 145, 6, 231, 243, 58, 201, 201, 195, 169, 35, 46, 9, 127, 31, 129, 238, 253, 62, 54, 170, 44, 159, 50, 159, 20, 97, 105, 65, 165, 2, 99, 14, 177, 194, 104, 220, 77, 169, 176, 243, 154, 212, 59, 236, 156, 166, 229, 166, 230, 212, 5, 56, 114, 191, 255 }, null, "banudik" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("9e203bce-750a-405c-91d7-bf6d8cac8ce5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("3cc39bf4-e2d1-4631-b1ff-8902d51c4a63") });
        }
    }
}
