using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class DefaultEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bb27b50d-b742-4566-ba05-db4e2b2c0d74", 0, "a6b85518-2067-4cbd-b180-0ccf7bdfe15d", null, false, false, null, null, "TESTUSER", "AQAAAAEAACcQAAAAEMA4+FHMGtEMq/3d7y5x5LtYnVNp7Nx0k93vy1iySj66fVx9h4vl0soWTiwo3zn1Jw==", null, false, "6dde22d0-59e8-4767-ab2f-70d5a24a8422", false, "TestUser" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "In Progress" },
                    { 3, "Done" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 2, 28, 8, 46, 40, 563, DateTimeKind.Local).AddTicks(9235), "Test", "bb27b50d-b742-4566-ba05-db4e2b2c0d74", "Test", null },
                    { 2, 2, new DateTime(2022, 11, 20, 8, 46, 40, 563, DateTimeKind.Local).AddTicks(9288), "Test2", "bb27b50d-b742-4566-ba05-db4e2b2c0d74", "Test2", null },
                    { 3, 3, new DateTime(2022, 8, 12, 8, 46, 40, 563, DateTimeKind.Local).AddTicks(9292), "Test3", "bb27b50d-b742-4566-ba05-db4e2b2c0d74", "Test3", null },
                    { 4, 3, new DateTime(2020, 6, 8, 8, 46, 40, 563, DateTimeKind.Local).AddTicks(9296), "Test4", "bb27b50d-b742-4566-ba05-db4e2b2c0d74", "Test4", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bb27b50d-b742-4566-ba05-db4e2b2c0d74");

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
