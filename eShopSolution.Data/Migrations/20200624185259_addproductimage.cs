using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class addproductimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 22, 9, 17, 15, 76, DateTimeKind.Local).AddTicks(9107));

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    ImagePath = table.Column<string>(maxLength: 200, nullable: false),
                    Caption = table.Column<string>(maxLength: 200, nullable: true),
                    IsDefault = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    SortOrder = table.Column<int>(nullable: false),
                    FileSize = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 22, 9, 17, 15, 76, DateTimeKind.Local).AddTicks(9107),
                oldClrType: typeof(DateTime));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("b7c08565-f04d-4a3d-a1f3-fc5d215ec946"),
                column: "ConcurrencyStamp",
                value: "117e14f9-187c-4d3e-aaec-49f3e5f39b4d");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("cbb34d3c-504b-4ad5-8e42-d37121a45e8a"),
                columns: new[] { "ConcurrencyStamp", "Dob", "PasswordHash" },
                values: new object[] { "84a210d7-a178-4711-a1c6-b5e26a85ce49", new DateTime(2020, 6, 22, 9, 17, 15, 122, DateTimeKind.Local).AddTicks(4453), "AQAAAAEAACcQAAAAEEbr5mt/MBpEYoCSxuTtoiUYMs3566mpY+F9hoEC2I0g7TwUJPagq+C6784jWTRTVQ==" });

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
    }
}
