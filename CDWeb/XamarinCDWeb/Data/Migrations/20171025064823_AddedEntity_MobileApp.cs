using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace XamarinCDWeb.Data.Migrations
{
    public partial class AddedEntity_MobileApp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MobileApps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "BLOB", nullable: false),
                    ApkVersion = table.Column<string>(type: "TEXT", nullable: true),
                    IpaVersion = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobileApps", x => x.Id);
                });

        
            migrationBuilder.CreateIndex(
                name: "IX_MobileApps_Name",
                table: "MobileApps",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MobileApps");
        }
    }
}
