using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThriftshopSite.Migrations
{
    public partial class new1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "21694bbb-3c36-44a8-a2f6-8813d32d7d8e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "0c97841b-1f28-4e38-838c-cefde2db8abb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "ee8f42da-1966-45e5-89e0-d7c71e8a2c50");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "5a5d5dce-8e5a-4419-812b-e6d33efe9839", "Admin.Admin@admin.nl3", "AQAAAAEAACcQAAAAECqPxR859WQCoB4WU9dP6v2nO1S/gS2Q660+Zg3B6JIxBpuTVwBmJ5nxEYQp++F9Ng==", "1bbe045a-5c5f-4f76-85f9-99eace3c00da", "Admin.Admin@admin.nl3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "a0ce7db1-1b23-45a8-a64c-7269a1291afb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "1649ef88-4d7e-4c9d-bbff-9d66b85c29d4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "01029529-0726-4c3f-b0f7-1fd6f3495fdf");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "0c1ebdbb-114c-4d5e-a48c-7d507683955f", null, "AQAAAAEAACcQAAAAEFXk9vyXFktzeR33qiQvjCfD0C+PsaH7r9vyxRfTD2uz/1ijjIRhKCqVJ0TCDSBg7w==", "ff8852eb-5d26-4dc0-b760-a6794389d0cb", "Admin.Admin@admin.nl" });
        }
    }
}
