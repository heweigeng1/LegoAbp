using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LegoAbp.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tenant",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    TenantName = table.Column<string>(maxLength: 32, nullable: true),
                    TenantCode = table.Column<string>(maxLength: 12, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 128, nullable: false),
                    PhoneNum = table.Column<string>(maxLength: 16, nullable: true),
                    Password = table.Column<string>(maxLength: 128, nullable: false),
                    Sex = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Tenant",
                columns: new[] { "Id", "CreationTime", "IsActive", "IsDeleted", "LastModificationTime", "TenantCode", "TenantName" },
                values: new object[] { 1, new DateTime(2018, 7, 19, 15, 19, 35, 684, DateTimeKind.Local), true, false, null, "123456", "defult" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreationTime", "IsActive", "IsDeleted", "LastModificationTime", "Password", "PhoneNum", "Sex", "TenantId", "UserName" },
                values: new object[] { new Guid("4ed3f08c-5a2c-4259-895c-f16d61f9de06"), new DateTime(2018, 7, 19, 15, 19, 35, 704, DateTimeKind.Local), true, false, null, "123456", null, 0, null, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tenant");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
