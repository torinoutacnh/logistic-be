using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class update0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarsManagers_CarsManagerId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Cars_CarId",
                table: "Routes");

            migrationBuilder.DropIndex(
                name: "IX_Routes_CarId",
                table: "Routes");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CarNumber",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CarsManagerId",
                table: "Cars");

            migrationBuilder.AddColumn<Guid>(
                name: "SeatId",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "CarNumber",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<Guid>(
                name: "CarsManagerEntityId",
                table: "Cars",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Mapping",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RouteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    starttime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mapping_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mapping_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SeatId",
                table: "Tickets",
                column: "SeatId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarsManagerEntityId",
                table: "Cars",
                column: "CarsManagerEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Mapping_CarId",
                table: "Mapping",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Mapping_RouteId",
                table: "Mapping",
                column: "RouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarsManagers_CarsManagerEntityId",
                table: "Cars",
                column: "CarsManagerEntityId",
                principalTable: "CarsManagers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Seats_SeatId",
                table: "Tickets",
                column: "SeatId",
                principalTable: "Seats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarsManagers_CarsManagerEntityId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Seats_SeatId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "Mapping");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_SeatId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CarsManagerEntityId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "SeatId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "CarsManagerEntityId",
                table: "Cars");

            migrationBuilder.AlterColumn<string>(
                name: "CarNumber",
                table: "Cars",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_CarId",
                table: "Routes",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarNumber",
                table: "Cars",
                column: "CarNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarsManagerId",
                table: "Cars",
                column: "CarsManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarsManagers_CarsManagerId",
                table: "Cars",
                column: "CarsManagerId",
                principalTable: "CarsManagers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Cars_CarId",
                table: "Routes",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
