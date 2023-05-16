using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThriftshopSite.Migrations
{
    public partial class EmployeeThrift : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeThriftShops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ThriftShopName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeThriftShops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeThriftShops_ThriftShops_ThriftShopName",
                        column: x => x.ThriftShopName,
                        principalTable: "ThriftShops",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeThriftShops_UserAccount_AccountId",
                        column: x => x.AccountId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "65464ff7-ef66-4028-96d8-4076327b8415");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "baa06828-c821-4d80-a519-2c5a1555112a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "61906d44-e85a-46a0-ba1e-f2b7fe9c20b0");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeThriftShops_AccountId",
                table: "EmployeeThriftShops",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeThriftShops_ThriftShopName",
                table: "EmployeeThriftShops",
                column: "ThriftShopName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeThriftShops");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "f1dcbd4f-db85-4806-bc8a-66a6e32e3de2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "39497a05-7766-4248-81b8-25687e183726");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "755fa8aa-980f-4cd6-8f40-2a973fa79fe0");
        }
    }
}
