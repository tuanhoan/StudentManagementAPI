using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementAPI.Migrations
{
    public partial class seedingData1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "TestType",
                newName: "TestTypes");

            migrationBuilder.RenameTable(
                name: "Semester",
                newName: "Semesters");

            migrationBuilder.RenameTable(
                name: "Score",
                newName: "Scores");

            migrationBuilder.RenameIndex(
                name: "IX_Score_TestTypeId",
                table: "Scores",
                newName: "IX_Scores_TestTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Score_SubjectId",
                table: "Scores",
                newName: "IX_Scores_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Score_StudentId",
                table: "Scores",
                newName: "IX_Scores_StudentId");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "ddb335be-c85b-41fe-8f70-e05efecfc418");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d62a38b4-5e34-4228-849f-56841106e26f", "AQAAAAEAACcQAAAAEId9YMBxODqXenpKJFIb8/we/wBqL5hSxTUZnchrprQxxrkC3CJ1u5aRONIj9kOuOg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "TestTypes",
                newName: "TestType");

            migrationBuilder.RenameTable(
                name: "Semesters",
                newName: "Semester");

            migrationBuilder.RenameTable(
                name: "Scores",
                newName: "Score");

            migrationBuilder.RenameIndex(
                name: "IX_Scores_TestTypeId",
                table: "Score",
                newName: "IX_Score_TestTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Scores_SubjectId",
                table: "Score",
                newName: "IX_Score_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Scores_StudentId",
                table: "Score",
                newName: "IX_Score_StudentId");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "fd4b49f1-a828-49f7-8a63-0d87fd698d21");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b7345972-033b-417e-8d4e-6df81662088b", "AQAAAAEAACcQAAAAEEQrG5MCQqjVXBZKSN+QhE9oxndX35PdkLWbhOrb6O78d1LVOgVaTUvQQrQhHdmcfw==" });
        }
    }
}
