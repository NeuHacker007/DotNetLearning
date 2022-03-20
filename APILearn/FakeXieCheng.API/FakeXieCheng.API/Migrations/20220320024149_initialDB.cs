using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FakeXieCheng.API.Migrations
{
    public partial class initialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TouristRoutes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    OriginalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountPresent = table.Column<double>(type: "float", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Features = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fees = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TouristRoutes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TouristRoutePictures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TouristRouteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TouristRoutePictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TouristRoutePictures_TouristRoutes_TouristRouteId",
                        column: x => x.TouristRouteId,
                        principalTable: "TouristRoutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TouristRoutePictures_TouristRouteId",
                table: "TouristRoutePictures",
                column: "TouristRouteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TouristRoutePictures");

            migrationBuilder.DropTable(
                name: "TouristRoutes");
        }
    }
}
