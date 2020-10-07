using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobsApp.Core.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    LogoUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Bookmarked = table.Column<bool>(nullable: false),
                    Salary = table.Column<decimal>(nullable: true),
                    PostedDate = table.Column<DateTime>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    LocationId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jobs_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jobs_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Development" },
                    { 2, "Management" }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "LogoUrl", "Name" },
                values: new object[,]
                {
                    { 1, null, "Benivo" },
                    { 2, null, "PCS AM" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Armenia, Yerevan" });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "Bookmarked", "CategoryId", "CompanyId", "Description", "LocationId", "PostedDate", "Salary", "Title", "Type" },
                values: new object[,]
                {
                    { 1, false, 1, 1, "Seeking of .Net Developer", 1, new DateTime(2020, 10, 3, 9, 45, 1, 945, DateTimeKind.Local).AddTicks(784), null, "Software Developer", 1 },
                    { 2, false, 1, 1, "Seeking of Senior Developer", 1, new DateTime(2020, 9, 29, 9, 45, 1, 947, DateTimeKind.Local).AddTicks(5892), 200000m, "Senior Software Developer", 2 },
                    { 3, false, 1, 1, "Seeking of Senior React Developer", 1, new DateTime(2020, 9, 26, 9, 45, 1, 947, DateTimeKind.Local).AddTicks(7150), null, "Senior React Developer", 4 },
                    { 4, true, 1, 2, "Seeking of .Net Developer", 1, new DateTime(2020, 9, 27, 9, 45, 1, 947, DateTimeKind.Local).AddTicks(7171), 100000m, ".Net Developer", 0 },
                    { 5, false, 2, 2, "Seeking of CTO", 1, new DateTime(2020, 10, 1, 9, 45, 1, 947, DateTimeKind.Local).AddTicks(7195), null, "CTO", 3 },
                    { 6, false, 2, 2, "Seeking of Project Manager", 1, new DateTime(2020, 10, 1, 9, 45, 1, 947, DateTimeKind.Local).AddTicks(7216), null, "Project Manager", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CategoryId",
                table: "Jobs",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CompanyId",
                table: "Jobs",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_LocationId",
                table: "Jobs",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
