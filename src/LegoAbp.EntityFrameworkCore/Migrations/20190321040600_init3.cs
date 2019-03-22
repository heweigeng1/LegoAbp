using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LegoAbp.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "ConcurrencyStamp", "CreationTime", "Password", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "97e5feea-2f42-4442-8a55-19d09e34c898", new DateTime(2019, 3, 21, 12, 5, 59, 100, DateTimeKind.Local), "AQAAAAEAACcQAAAAEGCkXUNdheKPkNgYGXtAfULw2Dlq5jpMkSw1KzMlsNr5/n07TusO+OZ+SJ1s27/bmQ==", "13333333333", "bec4f0a1-3886-a6db-a4cf-39ecb09a2cbc" });

            migrationBuilder.UpdateData(
                table: "TenantUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationTime",
                value: new DateTime(2019, 3, 21, 12, 5, 59, 57, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AbpRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreationTime" },
                values: new object[] { "365f598b-dfc6-4091-aaeb-2907d1719a35", new DateTime(2019, 3, 21, 10, 5, 41, 160, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "AbpTenants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2019, 3, 21, 10, 5, 40, 944, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "AbpUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "CreationTime", "Password", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "504e0359-6f45-4247-a2f8-910f3c2ddfaf", new DateTime(2019, 3, 21, 10, 5, 41, 9, DateTimeKind.Local), "AQAAAAEAACcQAAAAEC0nZELcchgbjAjua5ie6GGLKPrO6lGOpksJVCcCeau+Fp7aglIkI0cTN/Hx0Nd47g==", null, "b2284401-b1a9-83ba-578f-39ecb02c0911" });

            migrationBuilder.UpdateData(
                table: "TenantUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationTime",
                value: new DateTime(2019, 3, 21, 10, 5, 40, 952, DateTimeKind.Local));
        }
    }
}
