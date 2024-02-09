using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pri.WebApi.Food.Core.Migrations
{
    public partial class first : Migration
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
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    { new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2024, 2, 9, 11, 47, 6, 251, DateTimeKind.Utc).AddTicks(5082), new DateTime(2024, 2, 9, 11, 47, 6, 251, DateTimeKind.Utc).AddTicks(5084), "Pizza" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2024, 2, 9, 11, 47, 6, 251, DateTimeKind.Utc).AddTicks(5085), new DateTime(2024, 2, 9, 11, 47, 6, 251, DateTimeKind.Utc).AddTicks(5085), "Pasta" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2024, 2, 9, 11, 47, 6, 251, DateTimeKind.Utc).AddTicks(5087), new DateTime(2024, 2, 9, 11, 47, 6, 251, DateTimeKind.Utc).AddTicks(5087), "Groenten" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new DateTime(2024, 2, 9, 11, 47, 6, 251, DateTimeKind.Utc).AddTicks(5088), new DateTime(2024, 2, 9, 11, 47, 6, 251, DateTimeKind.Utc).AddTicks(5089), "Fruit" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "Image", "LastEditedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2024, 2, 9, 11, 47, 6, 251, DateTimeKind.Utc).AddTicks(5153), null, new DateTime(2024, 2, 9, 11, 47, 6, 251, DateTimeKind.Utc).AddTicks(5153), "Peperoni" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2024, 2, 9, 11, 47, 6, 251, DateTimeKind.Utc).AddTicks(5155), null, new DateTime(2024, 2, 9, 11, 47, 6, 251, DateTimeKind.Utc).AddTicks(5155), "Hawai" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2024, 2, 9, 11, 47, 6, 251, DateTimeKind.Utc).AddTicks(5156), null, new DateTime(2024, 2, 9, 11, 47, 6, 251, DateTimeKind.Utc).AddTicks(5156), "Macaroni" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2024, 2, 9, 11, 47, 6, 251, DateTimeKind.Utc).AddTicks(5158), null, new DateTime(2024, 2, 9, 11, 47, 6, 251, DateTimeKind.Utc).AddTicks(5158), "Spaghetti" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2024, 2, 9, 11, 47, 6, 251, DateTimeKind.Utc).AddTicks(5159), null, new DateTime(2024, 2, 9, 11, 47, 6, 251, DateTimeKind.Utc).AddTicks(5159), "Komkommer" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2024, 2, 9, 11, 47, 6, 251, DateTimeKind.Utc).AddTicks(5161), null, new DateTime(2024, 2, 9, 11, 47, 6, 251, DateTimeKind.Utc).AddTicks(5161), "Tomaat" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000004"), new DateTime(2024, 2, 9, 11, 47, 6, 251, DateTimeKind.Utc).AddTicks(5162), null, new DateTime(2024, 2, 9, 11, 47, 6, 251, DateTimeKind.Utc).AddTicks(5163), "Appel" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000004"), new DateTime(2024, 2, 9, 11, 47, 6, 251, DateTimeKind.Utc).AddTicks(5164), null, new DateTime(2024, 2, 9, 11, 47, 6, 251, DateTimeKind.Utc).AddTicks(5164), "Peer" }
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
