using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThriftshopSite.Migrations
{
    public partial class useraccoutn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "34a12a12-3c50-4dc1-b3cc-1aff27aa06c9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "9c5de7f4-e7d7-4dae-bcbe-86f9b8bd9452");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "ecbed72a-1f3e-473d-a0c7-303c3b026b4d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1ed0ac41-4b43-4176-ae4c-acee4ea2b1c7", "AQAAAAEAACcQAAAAEKbcjahfi/4zysUCH6pK2ptonRcfzSFflUwtPHKkc+pHlsrYWn0Dl+Rh1/HIXagDTg==", "694653ca-2e58-4cdf-b78d-0e1c8c7c4305" });

            migrationBuilder.InsertData(
                table: "UserAccount",
                columns: new[] { "Id", "Name", "role" },
                values: new object[] { new Guid("22a52f5c-478d-4799-b30c-6e2b5523bc6d"), "Admin.Admin@admin.nl", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserAccount",
                keyColumn: "Id",
                keyValue: new Guid("22a52f5c-478d-4799-b30c-6e2b5523bc6d"));

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "50a90c67-e391-4c68-bf2a-28599e559949", "AQAAAAEAACcQAAAAEMXGo0P7lcjoZkCHCBWjhdCShtl85sntTWH/izZu+bpmfRtRfnotMQsyBLcUMTIkxg==", "0a800275-6040-4a34-a1b2-f5d5e7559953" });
        }
    }
}
