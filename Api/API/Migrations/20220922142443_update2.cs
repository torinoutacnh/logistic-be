using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Routes_StopPoints_FromId",
                table: "Routes");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_StopPoints_ToId",
                table: "Routes");

            migrationBuilder.DropIndex(
                name: "IX_Routes_FromId",
                table: "Routes");

            migrationBuilder.DropIndex(
                name: "IX_Routes_ToId",
                table: "Routes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Routes_FromId",
                table: "Routes",
                column: "FromId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_ToId",
                table: "Routes",
                column: "ToId");

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
    }
}
