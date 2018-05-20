using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace viacinema.Migrations
{
    public partial class AddedPaymentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Seats",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<decimal>(nullable: false),
                    CardNumber = table.Column<string>(nullable: false),
                    ExpiryMonth = table.Column<byte>(nullable: false),
                    ExpiryYear = table.Column<byte>(nullable: false),
                    NameOnCard = table.Column<string>(nullable: false),
                    ScreeningId = table.Column<int>(nullable: false),
                    SeatNo = table.Column<int>(nullable: false),
                    SecurityCode = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Seats",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
