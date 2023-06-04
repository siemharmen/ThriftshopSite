using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThriftshopSite.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "35b8247e-45e4-4eea-ae23-68f0e5ba8369");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "398cd96b-0782-4e92-af70-5a02e8d00ba6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "f2178a93-a7c1-4f05-9c74-0b7707df32d8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5af6e749-c5f2-43f2-8e45-a396425778b2", "AQAAAAEAACcQAAAAECj9EWSApNo5vqC+oJE6bY4O4fIXediMUoeeMZhL04Vxx5WvqGosa3FZrWFOQFnJdw==", "83df5359-04c4-4919-a059-2a8ce13062fb" });
        }
    }
}
