using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace viacinema.Migrations
{
    public partial class ChangedColumnIDToScreeningIDInScreeningTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Screenings",
                newName: "ScreeningId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ScreeningId",
                table: "Screenings",
                newName: "Id");
        }
    }
}
