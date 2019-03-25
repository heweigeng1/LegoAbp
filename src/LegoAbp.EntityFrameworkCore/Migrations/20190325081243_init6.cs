using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LegoAbp.Migrations
{
    public partial class init6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastLoginTime",
                table: "AbpUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AbpUsers",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 32);

            migrationBuilder.AddColumn<string>(
                name: "ReturnValue",
                table: "AbpAuditLogs",
                nullable: true);

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
                columns: new[] { "ConcurrencyStamp", "IsLockoutEnabled", "Password", "SecurityStamp" },
                values: new object[] { "c9fcff75-7010-4a86-a11a-9cdb26d16c5e", false, "AQAAAAEAACcQAAAAEI8txvZu32yDKJ40SCPqevQeHxNHg0F+0r1f2a7tUoParDCLi4rM5RqIow+OoMKJKw==", "961b9427-b630-330d-7856-39ecc6157a64" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_CreatorUserId",
                table: "AbpUsers",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_DeleterUserId",
                table: "AbpUsers",
                column: "DeleterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_LastModifierUserId",
                table: "AbpUsers",
                column: "LastModifierUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_AbpUsers_CreatorUserId",
                table: "AbpUsers",
                column: "CreatorUserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_AbpUsers_DeleterUserId",
                table: "AbpUsers",
                column: "DeleterUserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_AbpUsers_LastModifierUserId",
                table: "AbpUsers",
                column: "LastModifierUserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_AbpUsers_CreatorUserId",
                table: "AbpUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_AbpUsers_DeleterUserId",
                table: "AbpUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_AbpUsers_LastModifierUserId",
                table: "AbpUsers");

            migrationBuilder.DropIndex(
                name: "IX_AbpUsers_CreatorUserId",
                table: "AbpUsers");

            migrationBuilder.DropIndex(
                name: "IX_AbpUsers_DeleterUserId",
                table: "AbpUsers");

            migrationBuilder.DropIndex(
                name: "IX_AbpUsers_LastModifierUserId",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "ReturnValue",
                table: "AbpAuditLogs");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AbpUsers",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 64);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLoginTime",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AbpRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "18062c45-0b10-431c-a3d3-7d40ad0e222d");

            migrationBuilder.UpdateData(
                table: "AbpUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "IsLockoutEnabled", "Password", "SecurityStamp" },
                values: new object[] { "2bd17a22-867a-4700-adf3-d159959fe25f", true, "AQAAAAEAACcQAAAAEGU0VAY7xoc2iiyMqaV1h0LPT6LtEriQh+YhHbkNrHgZgvK3KSUNLTG7YIBpWC9eqg==", "cbc98259-91ed-b0d0-cf3a-39ecc4e2847e" });
        }
    }
}
