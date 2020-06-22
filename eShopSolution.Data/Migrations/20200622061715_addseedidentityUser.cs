using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class addseedidentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 22, 9, 17, 15, 76, DateTimeKind.Local).AddTicks(9107),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 22, 8, 59, 48, 623, DateTimeKind.Local).AddTicks(3379));

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("b7c08565-f04d-4a3d-a1f3-fc5d215ec946"), "117e14f9-187c-4d3e-aaec-49f3e5f39b4d", "Admin of Boss", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("cbb34d3c-504b-4ad5-8e42-d37121a45e8a"), new Guid("b7c08565-f04d-4a3d-a1f3-fc5d215ec946") });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("cbb34d3c-504b-4ad5-8e42-d37121a45e8a"), 0, "84a210d7-a178-4711-a1c6-b5e26a85ce49", new DateTime(2020, 6, 22, 9, 17, 15, 122, DateTimeKind.Local).AddTicks(4453), "congdoan@gmail.com", true, "Doan", "Bui", false, null, "congdoan@gmail.com", "admin", "AQAAAAEAACcQAAAAEEbr5mt/MBpEYoCSxuTtoiUYMs3566mpY+F9hoEC2I0g7TwUJPagq+C6784jWTRTVQ==", null, false, "", false, "admin" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 6, 22, 9, 17, 15, 90, DateTimeKind.Local).AddTicks(8953));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("b7c08565-f04d-4a3d-a1f3-fc5d215ec946"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("cbb34d3c-504b-4ad5-8e42-d37121a45e8a"), new Guid("b7c08565-f04d-4a3d-a1f3-fc5d215ec946") });

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("cbb34d3c-504b-4ad5-8e42-d37121a45e8a"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 22, 8, 59, 48, 623, DateTimeKind.Local).AddTicks(3379),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 22, 9, 17, 15, 76, DateTimeKind.Local).AddTicks(9107));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 6, 22, 8, 59, 48, 636, DateTimeKind.Local).AddTicks(9186));
        }
    }
}
