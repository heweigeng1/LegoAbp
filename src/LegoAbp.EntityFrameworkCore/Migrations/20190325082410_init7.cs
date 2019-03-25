using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LegoAbp.Migrations
{
    public partial class init7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AbpOrganizationUnitRoles",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    OrganizationUnitId = table.Column<long>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpOrganizationUnitRoles", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AbpRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "7c815c55-dd60-455e-a1b5-1cdc5b4d0dc0");

            migrationBuilder.UpdateData(
                table: "AbpUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "Password", "SecurityStamp" },
                values: new object[] { "155742e4-8e2a-4689-ab02-34abe8ae3a15", "AQAAAAEAACcQAAAAEEku2vf/O+Kb2DfpxD2b1GIvNDisgheFYVPBxJA9nx+cF4SnWu5W7+cFsDzzsJC4aA==", "ed784ee0-e567-c38c-0bd5-39ecc61ff9e2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbpOrganizationUnitRoles");

            migrationBuilder.UpdateData(
                table: "AbpRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "d1b0dc2c-2ea5-4c85-b552-f3d74a14656c");

            migrationBuilder.UpdateData(
                table: "AbpUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "Password", "SecurityStamp" },
                values: new object[] { "c9fcff75-7010-4a86-a11a-9cdb26d16c5e", "AQAAAAEAACcQAAAAEI8txvZu32yDKJ40SCPqevQeHxNHg0F+0r1f2a7tUoParDCLi4rM5RqIow+OoMKJKw==", "961b9427-b630-330d-7856-39ecc6157a64" });
        }
    }
}
