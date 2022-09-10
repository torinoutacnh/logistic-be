using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class update5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Wards_ShortCodeName",
                table: "Wards");

            migrationBuilder.DropIndex(
                name: "IX_Districts_ShortCodeName",
                table: "Districts");

            migrationBuilder.AlterColumn<string>(
                name: "ShortCodeName",
                table: "Wards",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ShortCodeName",
                table: "Districts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ShortCodeName",
                table: "Wards",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ShortCodeName",
                table: "Districts",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Wards_ShortCodeName",
                table: "Wards",
                column: "ShortCodeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Districts_ShortCodeName",
                table: "Districts",
                column: "ShortCodeName",
                unique: true);
        }
    }
}
