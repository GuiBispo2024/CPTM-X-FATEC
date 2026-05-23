using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddOfflineSupport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CREATED_AT",
                table: "PT_EFLUENTE",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IS_DELETED",
                table: "PT_EFLUENTE",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "SYNC_ID",
                table: "PT_EFLUENTE",
                type: "RAW(16)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "SYNC_STATUS",
                table: "PT_EFLUENTE",
                type: "NVARCHAR2(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UPDATED_AT",
                table: "PT_EFLUENTE",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CREATED_AT",
                table: "PT_EFLUENTE");

            migrationBuilder.DropColumn(
                name: "IS_DELETED",
                table: "PT_EFLUENTE");

            migrationBuilder.DropColumn(
                name: "SYNC_ID",
                table: "PT_EFLUENTE");

            migrationBuilder.DropColumn(
                name: "SYNC_STATUS",
                table: "PT_EFLUENTE");

            migrationBuilder.DropColumn(
                name: "UPDATED_AT",
                table: "PT_EFLUENTE");
        }
    }
}
