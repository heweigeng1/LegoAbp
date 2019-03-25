using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LegoAbp.Migrations
{
    public partial class init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AbpAuditLogs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: true),
                    ServiceName = table.Column<string>(nullable: true),
                    MethodName = table.Column<string>(nullable: true),
                    Parameters = table.Column<string>(nullable: true),
                    ExecutionTime = table.Column<DateTime>(nullable: false),
                    ExecutionDuration = table.Column<int>(nullable: false),
                    ClientIpAddress = table.Column<string>(nullable: true),
                    ClientName = table.Column<string>(nullable: true),
                    BrowserInfo = table.Column<string>(nullable: true),
                    Exception = table.Column<string>(nullable: true),
                    ImpersonatorUserId = table.Column<long>(nullable: true),
                    ImpersonatorTenantId = table.Column<int>(nullable: true),
                    CustomData = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpAuditLogs", x => x.Id);
                });

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
                values: new object[] { "18062c45-0b10-431c-a3d3-7d40ad0e222d", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

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
                values: new object[] { "2bd17a22-867a-4700-adf3-d159959fe25f", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAEAACcQAAAAEGU0VAY7xoc2iiyMqaV1h0LPT6LtEriQh+YhHbkNrHgZgvK3KSUNLTG7YIBpWC9eqg==", "cbc98259-91ed-b0d0-cf3a-39ecc4e2847e" });

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
                name: "AbpAuditLogs");

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
