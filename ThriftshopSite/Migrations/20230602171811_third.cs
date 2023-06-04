using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThriftshopSite.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "1ec109a6-39cc-41fa-889d-908f8e1ad24d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "adccce45-ca54-4724-aa61-705a31466411");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "cc75c923-bbd2-4a26-89e6-bc43d9fa8907");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "17f96cb6-74b6-4b8b-8823-df073b277d2f", "AQAAAAEAACcQAAAAEK2vpdJG4rC3ZtjHIYzCsnAiXwmiFxURhyXAD0lcGPftNy4cE8RBjvhSCFmqM28u6A==", "503327cd-79f8-46c0-b88a-ebda2b022d87" });
        }
    }
}
