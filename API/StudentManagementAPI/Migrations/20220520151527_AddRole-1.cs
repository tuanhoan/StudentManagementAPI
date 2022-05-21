using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementAPI.Migrations
{
    public partial class AddRole1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "a458995b-ad3b-4d58-8991-85b8473c5072");

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("7f0ac7fe-bb4e-4be2-941a-d368e3f9336a"), "807fd416-0522-4d8f-860d-5b85c4beec9b", "Student role", "student", "student" },
                    { new Guid("22292118-048a-4673-a21f-2f3ae6fc9243"), "f48b70c5-9c19-4311-9272-0891508ed235", "Teacher role", "teacher", "teacher" }
                });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "92a3c9f1-645b-4cbe-960a-5f3376831104", "AQAAAAEAACcQAAAAEK3ft28UHypt5GB+g2wGHNIM9j6sGw+5pWVey1QzlwlN+UJnZA81DhlR2D50OQuq0A==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("22292118-048a-4673-a21f-2f3ae6fc9243"));

            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("7f0ac7fe-bb4e-4be2-941a-d368e3f9336a"));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "78446bed-04cb-4adf-a7a2-dd277ebe8ab3");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fefeb9fc-4c5c-448b-98eb-bccbf0b0b108", "AQAAAAEAACcQAAAAEH5LM2PCSAUGOpaROeCoZ4nHVzlSLoNQfI8gcAtD4tzIRVjIf5ysefYnRnuCtnPSFg==" });
        }
    }
}
