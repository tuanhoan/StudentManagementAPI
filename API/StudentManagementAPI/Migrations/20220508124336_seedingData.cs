using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementAPI.Migrations
{
    public partial class seedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Semester",
                columns: new[] { "Id", "Name", "TimeEnd", "TimeStart" },
                values: new object[,]
                {
                    { 1, "Học Kì 1", "2/15/2023 12:00:00 AM", "9/4/2022 12:00:00 AM" },
                    { 2, "Học Kì 2", "6/5/2023 12:00:00 AM", "2/20/2023 12:00:00 AM" }
                });

            migrationBuilder.InsertData(
                table: "TestType",
                columns: new[] { "Id", "ScoreFactor", "TestName" },
                values: new object[,]
                {
                    { 1, 1.0, "15P" },
                    { 2, 2.0, "60P" },
                    { 3, 3.0, "Học Kì" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Semester",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Semester",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TestType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TestType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TestType",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "d604f6fa-c3fc-4d2f-86cb-8c7b1f064944");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "72eaa2ef-5878-4bd3-a64f-264aec44a135", "AQAAAAEAACcQAAAAEF2MheabBMuYK8skjbIHqtJAW9qyOzFf242iOVPUhXFVjqjiZoEXgtJY549TtrQlDA==" });
        }
    }
}
