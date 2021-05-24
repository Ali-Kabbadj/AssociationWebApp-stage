using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class NEW : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ListSectionMission",
                schema: "Admin",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Image = table.Column<byte[]>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    SmallTitle = table.Column<string>(nullable: true),
                    Paragraph = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListSectionMission", x => x.Id);
                });

            migrationBuilder.UpdateData(
                schema: "Admin",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "1d162573-02ef-4c8d-a03b-d0c82250dd53");

            migrationBuilder.UpdateData(
                schema: "Admin",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8f1d1985-ebe0-4976-a7cb-02bb842a1940", "AQAAAAEAACcQAAAAEB1cObDlP1nx/6k2B8kCxrRCFSSogb0WQmMYhs1oLbNwTwZuf22y0IaggeCJ6YgETQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListSectionMission",
                schema: "Admin");

            migrationBuilder.UpdateData(
                schema: "Admin",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "5264fb75-f593-4960-8e20-1123fccd32d8");

            migrationBuilder.UpdateData(
                schema: "Admin",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2349a87a-5338-4918-a072-88db1ff594a7", "AQAAAAEAACcQAAAAEPRp65y5zGyAhO7eQB0vWQAvuaKsC8ETAgk6SpzoYn3ol7RHY4sQBw/cJl/SSqljKQ==" });
        }
    }
}
