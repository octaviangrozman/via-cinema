using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace viacinema.Migrations
{
    public partial class ChangedScreenTypeToScreening : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "screenType",
                table: "Screenings",
                newName: "ScreenType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ScreenType",
                table: "Screenings",
                newName: "screenType");
        }
    }
}
