using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConfigServer.API.Migrations
{
    public partial class Init_DB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "application");

            migrationBuilder.CreateTable(
                name: "Applications",
                schema: "application",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ApplicationSecret = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Configuration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_ApplicationName",
                schema: "application",
                table: "Applications",
                column: "ApplicationName");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_ApplicationSecret",
                schema: "application",
                table: "Applications",
                column: "ApplicationSecret");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applications",
                schema: "application");
        }
    }
}
