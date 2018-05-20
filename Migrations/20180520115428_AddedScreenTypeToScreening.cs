using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace viacinema.Migrations
{
    public partial class AddedScreenTypeToScreening : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "screenType",
                table: "Rooms");

            migrationBuilder.AddColumn<string>(
                name: "screenType",
                table: "Screenings",
                maxLength: 5,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "screenType",
                table: "Screenings");

            migrationBuilder.AddColumn<string>(
                name: "screenType",
                table: "Rooms",
                maxLength: 5,
                nullable: false,
                defaultValue: "");
        }
    }
}
