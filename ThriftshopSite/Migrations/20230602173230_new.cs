using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThriftshopSite.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0c1ebdbb-114c-4d5e-a48c-7d507683955f", "AQAAAAEAACcQAAAAEFXk9vyXFktzeR33qiQvjCfD0C+PsaH7r9vyxRfTD2uz/1ijjIRhKCqVJ0TCDSBg7w==", "ff8852eb-5d26-4dc0-b760-a6794389d0cb" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "e4c778f8-136e-4749-aeeb-e37321c50ce9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "689e282b-e065-433e-abc7-a6db3ae7e78a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "cb59c8ef-230a-470e-89ec-32bef68c1c1f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "acbdc7f6-0af8-4db9-89fb-cf647fbc20b7", "AQAAAAEAACcQAAAAEF4MaXYk0DVLQt6FzfhlFbw2xuRNRLk9qBPTcYE6IQqLMin+0aAbDb2uIgZnG+FpCQ==", "607477ce-0187-4926-9768-9cc9675d2090" });
        }
    }
}
