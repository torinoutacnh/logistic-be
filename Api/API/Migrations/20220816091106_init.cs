using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Form",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Info_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Info_Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Info_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Form", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormAttribute",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Info_Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Info_DefaultValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Info_MapCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modify_ControlType = table.Column<int>(type: "int", nullable: false),
                    Modify_DataType = table.Column<int>(type: "int", nullable: false),
                    Modify_DropDownValues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Display_Col = table.Column<int>(type: "int", nullable: true),
                    Display_Row = table.Column<int>(type: "int", nullable: true),
                    Display_LabelCol = table.Column<int>(type: "int", nullable: true),
                    Display_LabelRow = table.Column<int>(type: "int", nullable: true),
                    Display_LabelStyle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Display_LabelClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Display_LabelPosition = table.Column<int>(type: "int", nullable: true),
                    Display_ContentCol = table.Column<int>(type: "int", nullable: true),
                    Display_ContentRow = table.Column<int>(type: "int", nullable: true),
                    Display_ContentStyle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Display_ContentClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormAttribute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormAttribute_Form_FormId",
                        column: x => x.FormId,
                        principalTable: "Form",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FormAttribute_FormId",
                table: "FormAttribute",
                column: "FormId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormAttribute");

            migrationBuilder.DropTable(
                name: "Form");
        }
    }
}
