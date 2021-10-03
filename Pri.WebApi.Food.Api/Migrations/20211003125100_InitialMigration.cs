using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pri.WebApi.Food.Api.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEditedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEditedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedOn", "LastEditedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2021, 10, 3, 12, 51, 0, 213, DateTimeKind.Utc).AddTicks(2145), new DateTime(2021, 10, 3, 12, 51, 0, 213, DateTimeKind.Utc).AddTicks(2332), "Pizza" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2021, 10, 3, 12, 51, 0, 213, DateTimeKind.Utc).AddTicks(2489), new DateTime(2021, 10, 3, 12, 51, 0, 213, DateTimeKind.Utc).AddTicks(2490), "Pasta" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2021, 10, 3, 12, 51, 0, 213, DateTimeKind.Utc).AddTicks(2493), new DateTime(2021, 10, 3, 12, 51, 0, 213, DateTimeKind.Utc).AddTicks(2493), "Groenten" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new DateTime(2021, 10, 3, 12, 51, 0, 213, DateTimeKind.Utc).AddTicks(2496), new DateTime(2021, 10, 3, 12, 51, 0, 213, DateTimeKind.Utc).AddTicks(2496), "Fruit" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "LastEditedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2021, 10, 3, 12, 51, 0, 214, DateTimeKind.Utc).AddTicks(176), new DateTime(2021, 10, 3, 12, 51, 0, 214, DateTimeKind.Utc).AddTicks(179), "Pepperoni" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2021, 10, 3, 12, 51, 0, 214, DateTimeKind.Utc).AddTicks(186), new DateTime(2021, 10, 3, 12, 51, 0, 214, DateTimeKind.Utc).AddTicks(187), "Hawai" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2021, 10, 3, 12, 51, 0, 214, DateTimeKind.Utc).AddTicks(190), new DateTime(2021, 10, 3, 12, 51, 0, 214, DateTimeKind.Utc).AddTicks(191), "Macaroni" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2021, 10, 3, 12, 51, 0, 214, DateTimeKind.Utc).AddTicks(194), new DateTime(2021, 10, 3, 12, 51, 0, 214, DateTimeKind.Utc).AddTicks(195), "Spaghetti" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2021, 10, 3, 12, 51, 0, 214, DateTimeKind.Utc).AddTicks(198), new DateTime(2021, 10, 3, 12, 51, 0, 214, DateTimeKind.Utc).AddTicks(199), "Komkommer" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2021, 10, 3, 12, 51, 0, 214, DateTimeKind.Utc).AddTicks(202), new DateTime(2021, 10, 3, 12, 51, 0, 214, DateTimeKind.Utc).AddTicks(203), "Tomaat" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000004"), new DateTime(2021, 10, 3, 12, 51, 0, 214, DateTimeKind.Utc).AddTicks(206), new DateTime(2021, 10, 3, 12, 51, 0, 214, DateTimeKind.Utc).AddTicks(207), "Appel" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000004"), new DateTime(2021, 10, 3, 12, 51, 0, 214, DateTimeKind.Utc).AddTicks(210), new DateTime(2021, 10, 3, 12, 51, 0, 214, DateTimeKind.Utc).AddTicks(211), "Peer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
