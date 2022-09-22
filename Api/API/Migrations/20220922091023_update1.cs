using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mapping_Cars_CarId",
                table: "Mapping");

            migrationBuilder.DropForeignKey(
                name: "FK_Mapping_Routes_RouteId",
                table: "Mapping");

            migrationBuilder.DropForeignKey(
                name: "FK_StopPoints_Cars_CarId",
                table: "StopPoints");

            migrationBuilder.DropIndex(
                name: "IX_StopPoints_CarId",
                table: "StopPoints");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mapping",
                table: "Mapping");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "StopPoints");

            migrationBuilder.RenameTable(
                name: "Mapping",
                newName: "CarRouteMapping");

            migrationBuilder.RenameIndex(
                name: "IX_Mapping_RouteId",
                table: "CarRouteMapping",
                newName: "IX_CarRouteMapping_RouteId");

            migrationBuilder.RenameIndex(
                name: "IX_Mapping_CarId",
                table: "CarRouteMapping",
                newName: "IX_CarRouteMapping_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarRouteMapping",
                table: "CarRouteMapping",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarRouteMapping_Cars_CarId",
                table: "CarRouteMapping",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarRouteMapping_Routes_RouteId",
                table: "CarRouteMapping",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarRouteMapping_Cars_CarId",
                table: "CarRouteMapping");

            migrationBuilder.DropForeignKey(
                name: "FK_CarRouteMapping_Routes_RouteId",
                table: "CarRouteMapping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarRouteMapping",
                table: "CarRouteMapping");

            migrationBuilder.RenameTable(
                name: "CarRouteMapping",
                newName: "Mapping");

            migrationBuilder.RenameIndex(
                name: "IX_CarRouteMapping_RouteId",
                table: "Mapping",
                newName: "IX_Mapping_RouteId");

            migrationBuilder.RenameIndex(
                name: "IX_CarRouteMapping_CarId",
                table: "Mapping",
                newName: "IX_Mapping_CarId");

            migrationBuilder.AddColumn<Guid>(
                name: "CarId",
                table: "StopPoints",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mapping",
                table: "Mapping",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_StopPoints_CarId",
                table: "StopPoints",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mapping_Cars_CarId",
                table: "Mapping",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mapping_Routes_RouteId",
                table: "Mapping",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StopPoints_Cars_CarId",
                table: "StopPoints",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
