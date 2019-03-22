using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LegoAbp.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AbpFeatures",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpFeatures", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AbpRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreationTime" },
                values: new object[] { "977485f2-d207-4c2a-a83e-9c3386f67a41", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "AbpTenants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AbpUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "CreationTime", "Password", "SecurityStamp" },
                values: new object[] { "32f5bea6-63d5-48f8-b12e-9cf7a73af803", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAEAACcQAAAAEGQqxvmniiocMO5zhEec1T/3/q/NfcQGXeiCaqfu5iYRXL6mY5MVbTKNzpjEoTvnmg==", "66f8d67e-984f-8d14-e952-39ecb87d34f7" });

            migrationBuilder.UpdateData(
                table: "TenantUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationTime",
                value: new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbpFeatures");

            migrationBuilder.UpdateData(
                table: "AbpRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreationTime" },
                values: new object[] { "226a8cde-7c93-40fd-87a6-34bfe17080bd", new DateTime(2019, 3, 21, 12, 5, 59, 222, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "AbpTenants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2019, 3, 21, 12, 5, 59, 53, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "AbpUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "CreationTime", "Password", "SecurityStamp" },
                values: new object[] { "97e5feea-2f42-4442-8a55-19d09e34c898", new DateTime(2019, 3, 21, 12, 5, 59, 100, DateTimeKind.Local), "AQAAAAEAACcQAAAAEGCkXUNdheKPkNgYGXtAfULw2Dlq5jpMkSw1KzMlsNr5/n07TusO+OZ+SJ1s27/bmQ==", "bec4f0a1-3886-a6db-a4cf-39ecb09a2cbc" });

            migrationBuilder.UpdateData(
                table: "TenantUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationTime",
                value: new DateTime(2019, 3, 21, 12, 5, 59, 57, DateTimeKind.Local));
        }
    }
}
