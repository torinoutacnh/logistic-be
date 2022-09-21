using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class update11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StopPoints_Cars_CarId",
                table: "StopPoints");

            migrationBuilder.AddForeignKey(
                name: "FK_StopPoints_Cars_CarId",
                table: "StopPoints",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StopPoints_Cars_CarId",
                table: "StopPoints");

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
