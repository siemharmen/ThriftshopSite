using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThriftshopSite.Migrations
{
    public partial class newnormal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "5bc12334-33c7-493b-ae65-561957b3e74f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "da6f1be5-1282-42ed-aafc-0a1f87e15337");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "8095dc71-44b6-49b1-a2d5-5c25937c0331");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "50a90c67-e391-4c68-bf2a-28599e559949", "Admin.Admin@admin.nl", "ADMIN.ADMIN@ADMIN.NL", "ADMIN.ADMIN@ADMIN.NL", "AQAAAAEAACcQAAAAEMXGo0P7lcjoZkCHCBWjhdCShtl85sntTWH/izZu+bpmfRtRfnotMQsyBLcUMTIkxg==", "0a800275-6040-4a34-a1b2-f5d5e7559953", "Admin.Admin@admin.nl" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "5a5d5dce-8e5a-4419-812b-e6d33efe9839", "Admin.Admin@admin.nl3", null, "ADMIN", "AQAAAAEAACcQAAAAECqPxR859WQCoB4WU9dP6v2nO1S/gS2Q660+Zg3B6JIxBpuTVwBmJ5nxEYQp++F9Ng==", "1bbe045a-5c5f-4f76-85f9-99eace3c00da", "Admin.Admin@admin.nl3" });
        }
    }
}
