using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class update4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Wards_PhoneCode",
                table: "Wards");

            migrationBuilder.DropIndex(
                name: "IX_Districts_PhoneCode",
                table: "Districts");

            migrationBuilder.DropColumn(
                name: "PhoneCode",
                table: "Wards");

            migrationBuilder.DropColumn(
                name: "PhoneCode",
                table: "Districts");

            migrationBuilder.AddColumn<string>(
                name: "ShortCodeName",
                table: "Wards",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShortCodeName",
                table: "Districts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Wards_ShortCodeName",
                table: "Wards");

            migrationBuilder.DropIndex(
                name: "IX_Districts_ShortCodeName",
                table: "Districts");

            migrationBuilder.DropColumn(
                name: "ShortCodeName",
                table: "Wards");

            migrationBuilder.DropColumn(
                name: "ShortCodeName",
                table: "Districts");

            migrationBuilder.AddColumn<long>(
                name: "PhoneCode",
                table: "Wards",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "PhoneCode",
                table: "Districts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Wards_PhoneCode",
                table: "Wards",
                column: "PhoneCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Districts_PhoneCode",
                table: "Districts",
                column: "PhoneCode",
                unique: true);
        }
    }
}
