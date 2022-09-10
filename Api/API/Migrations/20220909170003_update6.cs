using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class update6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Wards_CodeName",
                table: "Wards");

            migrationBuilder.DropIndex(
                name: "IX_Wards_Name",
                table: "Wards");

            migrationBuilder.DropIndex(
                name: "IX_Districts_CodeName",
                table: "Districts");

            migrationBuilder.DropIndex(
                name: "IX_Districts_Name",
                table: "Districts");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Wards",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CodeName",
                table: "Wards",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Districts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CodeName",
                table: "Districts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Wards",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CodeName",
                table: "Wards",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Districts",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CodeName",
                table: "Districts",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Wards_CodeName",
                table: "Wards",
                column: "CodeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wards_Name",
                table: "Wards",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Districts_CodeName",
                table: "Districts",
                column: "CodeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Districts_Name",
                table: "Districts",
                column: "Name",
                unique: true);
        }
    }
}
