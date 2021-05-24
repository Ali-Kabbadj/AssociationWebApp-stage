using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class redesign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "members",
                schema: "Admin",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Image = table.Column<byte[]>(nullable: true),
                    FirsName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    ProfitionOrOrganization = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_members", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "members",
                schema: "Admin");

            migrationBuilder.UpdateData(
                schema: "Admin",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "d5634328-c7c3-423a-be0c-741ced3bd761");

            migrationBuilder.UpdateData(
                schema: "Admin",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b1d0ec8a-52c1-470d-94f7-1070c13eb641", "AQAAAAEAACcQAAAAEBJo8lgIOeUD5awilIgYWNZ3XdyQQ72Xki7/RARxWeLGRqjJ4f8Y0awjudgK5MeweA==" });
        }
    }
}
