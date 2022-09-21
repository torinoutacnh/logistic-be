using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class update12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Routes_StopPoints_FromId",
                table: "Routes");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_StopPoints_ToId",
                table: "Routes");

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_StopPoints_FromId",
                table: "Routes",
                column: "FromId",
                principalTable: "StopPoints",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_StopPoints_ToId",
                table: "Routes",
                column: "ToId",
                principalTable: "StopPoints",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Routes_StopPoints_FromId",
                table: "Routes");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_StopPoints_ToId",
                table: "Routes");

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_StopPoints_FromId",
                table: "Routes",
                column: "FromId",
                principalTable: "StopPoints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_StopPoints_ToId",
                table: "Routes",
                column: "ToId",
                principalTable: "StopPoints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
