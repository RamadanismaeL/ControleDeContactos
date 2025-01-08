using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace controleDeContactos.Migrations
{
    /// <inheritdoc />
    public partial class contactMapupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbContact",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    lastName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phoneNumber = table.Column<int>(type: "int", maxLength: 9, nullable: false),
                    dateRegister = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp"),
                    userID = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbContact", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbContact_tbUser_userID",
                        column: x => x.userID,
                        principalTable: "tbUser",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_tbContact_email",
                table: "tbContact",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbContact_name",
                table: "tbContact",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbContact_userID",
                table: "tbContact",
                column: "userID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbContact");
        }
    }
}
