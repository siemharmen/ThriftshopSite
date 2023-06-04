using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThriftshopSite.Migrations
{
    public partial class af : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "a8217c97-32e6-4f96-8d43-d353f1bbc8d2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "9b87c24e-d817-4b08-92b0-c0b3731542b4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "50654f40-7b5f-4414-b1ed-df0528ce6c9f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ecab79d-db50-4461-a17a-6b43d2addb42", "AQAAAAEAACcQAAAAELTCnmbcWuqUt6an0+oeljOle7m0bh4OWSKBUBsSshm3h0+P0bSijAfjLJjACEuXHg==", "db171ba5-e86a-40c6-b20c-eb9ef06fad05" });
        }
    }
}
