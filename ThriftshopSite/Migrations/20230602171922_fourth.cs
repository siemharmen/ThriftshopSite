using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThriftshopSite.Migrations
{
    public partial class fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "524b3142-447a-46e8-8efc-17abc88add75");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "b242046d-4eaa-411c-98f8-b4067254fc47");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "96fb8fb7-f129-4196-8c06-9de93a373aaa");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d71d297-b0eb-4635-a162-b7d4dc502270", "AQAAAAEAACcQAAAAELNqs2ZafKc++JHhHecazS7EPjE+Y0mswp7YpeA58e4RdsYyvGhUvDPuWFARxV770A==", "8c7d53a7-4a66-4a66-8c5b-6ad40f4fc826" });
        }
    }
}
