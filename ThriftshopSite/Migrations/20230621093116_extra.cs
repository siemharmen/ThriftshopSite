using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThriftshopSite.Migrations
{
    public partial class extra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                value: "cbfeae1d-dc3f-4ab4-8b86-8d004608e1f4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "f10cf12e-3563-44e4-a50d-6c363927e3b5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "a115550f-5728-412f-bc3b-d6438ee9ac5f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "65186825-0e6b-4f6f-a466-df86cdbb61dc", "AQAAAAEAACcQAAAAEP0JNvZJmOsVanjCclpAS56Ea+u0Ya49fsZiU0K6l+hRvPyt8w1BfSyUs18jQ4RK9w==", "430be543-7ea2-45fe-b5b1-6743958d8693" });

            migrationBuilder.InsertData(
                table: "ThriftShops",
                columns: new[] { "Name", "IsApproved", "Location" },
                values: new object[] { "ShareStore Deventer", true, "Deventer" });

            migrationBuilder.InsertData(
                table: "UserAccount",
                columns: new[] { "Id", "Name", "role" },
                values: new object[] { new Guid("9996b6f9-0061-4f4d-91bd-4bf6a2f190b8"), "Admin.Admin@admin.nl", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ThriftShops",
                keyColumn: "Name",
                keyValue: "ShareStore Deventer");

            migrationBuilder.DeleteData(
                table: "UserAccount",
                keyColumn: "Id",
                keyValue: new Guid("9996b6f9-0061-4f4d-91bd-4bf6a2f190b8"));

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
    }
}
