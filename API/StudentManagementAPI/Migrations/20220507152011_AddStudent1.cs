using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementAPI.Migrations
{
    public partial class AddStudent1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Teams_TeamsId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_TeamsId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "TeamsId",
                table: "Students");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "8e4c2a93-8f4f-4746-ac95-6146732f3889");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "46793217-6dfd-438c-9941-0f52cdeb1492", "AQAAAAEAACcQAAAAEEc+w7vO0d1W3uprMNP5iYOBvjBTn4ikPPri8xJ7qX92e17SnxMXCN8JGNxSQPXSTw==" });

            migrationBuilder.CreateIndex(
                name: "IX_Students_TeamId",
                table: "Students",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "fk_team_student",
                table: "Students",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_team_student",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_TeamId",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "TeamsId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "69a45b4f-7392-4d59-acd1-4644edd4f65e");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3b63c9b9-7923-457f-97c0-909d8d91d22f", "AQAAAAEAACcQAAAAEDDeOOFitDq7FRDF01Hv6lc3upv+6qYGF3vhjqwsf8gl01xk+kEah4dQudAhCyCd5g==" });

            migrationBuilder.CreateIndex(
                name: "IX_Students_TeamsId",
                table: "Students",
                column: "TeamsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Teams_TeamsId",
                table: "Students",
                column: "TeamsId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
