using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class changeTypeFileSizeInProductImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "FileSize",
                table: "ProductImages",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("b7c08565-f04d-4a3d-a1f3-fc5d215ec946"),
                column: "ConcurrencyStamp",
                value: "90244ca5-fbf4-46e7-adf0-833ece36b859");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("cbb34d3c-504b-4ad5-8e42-d37121a45e8a"),
                columns: new[] { "ConcurrencyStamp", "Dob", "PasswordHash" },
                values: new object[] { "fdffc875-21db-4ab5-bf5b-3f6b9ab625bc", new DateTime(2020, 6, 25, 6, 39, 30, 99, DateTimeKind.Local).AddTicks(3207), "AQAAAAEAACcQAAAAEMbGZ0jwRnvCrNvSO69fUSglYJYxGJjXWIe4woIjWi2EPSEth3ksv/iw0MNqEIwyug==" });

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
                value: new DateTime(2020, 6, 25, 6, 39, 30, 81, DateTimeKind.Local).AddTicks(3714));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FileSize",
                table: "ProductImages",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("b7c08565-f04d-4a3d-a1f3-fc5d215ec946"),
                column: "ConcurrencyStamp",
                value: "5479606b-bfae-4ebb-8497-71caea849012");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("cbb34d3c-504b-4ad5-8e42-d37121a45e8a"),
                columns: new[] { "ConcurrencyStamp", "Dob", "PasswordHash" },
                values: new object[] { "085ea6e1-eb56-4775-801d-bdf486cd55d7", new DateTime(2020, 6, 24, 21, 52, 59, 7, DateTimeKind.Local).AddTicks(4625), "AQAAAAEAACcQAAAAEMoe0AD7c9MEuEPxgtv6yBxy8F4+jxCGNc4K8ryv5sRYtyK6sCk4kkQJU9PhOEzCNA==" });

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
                value: new DateTime(2020, 6, 24, 21, 52, 58, 987, DateTimeKind.Local).AddTicks(5111));
        }
    }
}
