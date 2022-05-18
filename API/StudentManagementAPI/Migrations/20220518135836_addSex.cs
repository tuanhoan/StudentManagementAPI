using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementAPI.Migrations
{
    public partial class addSex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sex",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sex",
                table: "AppUsers");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "59dc3d1f-07b5-4800-b5f0-eaf10dcd218b");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0a4ddf61-6d91-4235-b9f2-dd741e3e46e1", "AQAAAAEAACcQAAAAEDRx749F/Xe1slQPnXZsiP2LgoAdAVSNY+maKY2THTvC0aqAhG48MGpvuW2s46Y9UA==" });
        }
    }
}
