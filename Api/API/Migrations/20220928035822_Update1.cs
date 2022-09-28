using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class Update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "From_HouseNumber",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "From_Street",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "To_HouseNumber",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "To_Street",
                table: "Routes");

            migrationBuilder.AddColumn<Guid>(
                name: "CarRouteMappingId",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RouteId",
                table: "Cars",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "CarRouteMapping",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CarRouteMappingId",
                table: "Tickets",
                column: "CarRouteMappingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_CarRouteMapping_CarRouteMappingId",
                table: "Tickets",
                column: "CarRouteMappingId",
                principalTable: "CarRouteMapping",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_CarRouteMapping_CarRouteMappingId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_CarRouteMappingId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "CarRouteMappingId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "RouteId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "CarRouteMapping");

            migrationBuilder.AddColumn<string>(
                name: "From_HouseNumber",
                table: "Routes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "From_Street",
                table: "Routes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "To_HouseNumber",
                table: "Routes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "To_Street",
                table: "Routes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
