using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class NewTestUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bb27b50d-b742-4566-ba05-db4e2b2c0d74");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5a844331-408a-4e07-87a0-750c0f4b543e", 0, "47285f99-faf3-4544-82d0-11bb291afca9", null, false, false, null, null, "TESTUSER@GMAIL.COM", "AQAAAAEAACcQAAAAEI9oQB37ikoSJpzNZ++7gAN12g+xmzvPAOo1zU8IUUey55S8p1LlaiEAdjPhuhlvMQ==", null, false, "804cb394-5ffb-4ff7-bc55-f80886b264b5", false, "testuser@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2023, 2, 28, 8, 50, 21, 675, DateTimeKind.Local).AddTicks(8017), "5a844331-408a-4e07-87a0-750c0f4b543e" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2022, 11, 20, 8, 50, 21, 675, DateTimeKind.Local).AddTicks(8057), "5a844331-408a-4e07-87a0-750c0f4b543e" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2022, 8, 12, 8, 50, 21, 675, DateTimeKind.Local).AddTicks(8060), "5a844331-408a-4e07-87a0-750c0f4b543e" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2020, 6, 8, 8, 50, 21, 675, DateTimeKind.Local).AddTicks(8064), "5a844331-408a-4e07-87a0-750c0f4b543e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a844331-408a-4e07-87a0-750c0f4b543e");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bb27b50d-b742-4566-ba05-db4e2b2c0d74", 0, "a6b85518-2067-4cbd-b180-0ccf7bdfe15d", null, false, false, null, null, "TESTUSER", "AQAAAAEAACcQAAAAEMA4+FHMGtEMq/3d7y5x5LtYnVNp7Nx0k93vy1iySj66fVx9h4vl0soWTiwo3zn1Jw==", null, false, "6dde22d0-59e8-4767-ab2f-70d5a24a8422", false, "TestUser" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2023, 2, 28, 8, 46, 40, 563, DateTimeKind.Local).AddTicks(9235), "bb27b50d-b742-4566-ba05-db4e2b2c0d74" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2022, 11, 20, 8, 46, 40, 563, DateTimeKind.Local).AddTicks(9288), "bb27b50d-b742-4566-ba05-db4e2b2c0d74" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2022, 8, 12, 8, 46, 40, 563, DateTimeKind.Local).AddTicks(9292), "bb27b50d-b742-4566-ba05-db4e2b2c0d74" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2020, 6, 8, 8, 46, 40, 563, DateTimeKind.Local).AddTicks(9296), "bb27b50d-b742-4566-ba05-db4e2b2c0d74" });
        }
    }
}
