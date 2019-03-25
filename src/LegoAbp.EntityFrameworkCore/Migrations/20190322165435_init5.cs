using Microsoft.EntityFrameworkCore.Migrations;

namespace LegoAbp.Migrations
{
    public partial class init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AbpRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "52de781c-d9b4-4612-a118-7d1420457ef0");

            migrationBuilder.UpdateData(
                table: "AbpUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "Password", "SecurityStamp" },
                values: new object[] { "aa870ddc-6965-47b5-958a-92669fb2cb47", "AQAAAAEAACcQAAAAEJmuf1RT3rSIajV8AgoyunjOBXf7qmnMReEpWxJ2cVoh1NOFcPZSH1y5HCouNBkgxg==", "ed54eca2-b6ad-9d5b-5649-39ecb8803640" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AbpRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "977485f2-d207-4c2a-a83e-9c3386f67a41");

            migrationBuilder.UpdateData(
                table: "AbpUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "Password", "SecurityStamp" },
                values: new object[] { "32f5bea6-63d5-48f8-b12e-9cf7a73af803", "AQAAAAEAACcQAAAAEGQqxvmniiocMO5zhEec1T/3/q/NfcQGXeiCaqfu5iYRXL6mY5MVbTKNzpjEoTvnmg==", "66f8d67e-984f-8d14-e952-39ecb87d34f7" });
        }
    }
}
