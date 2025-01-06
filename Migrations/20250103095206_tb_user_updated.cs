using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace controleDeContactos.Migrations
{
    /// <inheritdoc />
    public partial class tb_user_updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdate",
                table: "tbUser",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateUpdate",
                table: "tbUser");
        }
    }
}
