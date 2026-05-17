using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPasswordReset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PASSWORD_RESET_TOKENS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    USER_ID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TOKEN = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EXPIRES_AT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    USED = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PASSWORD_RESET_TOKENS", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PASSWORD_RESET_TOKENS");
        }
    }
}
