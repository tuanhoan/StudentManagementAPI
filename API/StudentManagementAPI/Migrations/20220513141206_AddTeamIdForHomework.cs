using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementAPI.Migrations
{
    public partial class AddTeamIdForHomework : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Homeworks",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Homeworks_TeamId",
                table: "Homeworks",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "fk_homework_team",
                table: "Homeworks",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_homework_team",
                table: "Homeworks");

            migrationBuilder.DropIndex(
                name: "IX_Homeworks_TeamId",
                table: "Homeworks");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Homeworks");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "ca600487-f853-4824-9f7c-9c6a032abcf6");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "33192962-fa02-40a0-b54a-a2566d73ac6c", "AQAAAAEAACcQAAAAEOxYWxdGyeuo1bQpG7oIQu8umDnJXaUCss2G/5dEjfkD86LOPYlkCFsb4TZgaaR0bw==" });
        }
    }
}
