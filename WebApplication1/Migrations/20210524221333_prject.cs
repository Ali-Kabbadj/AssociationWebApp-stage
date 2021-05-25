using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class prject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                schema: "Admin",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<byte[]>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    SubTitle = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    FilePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.UpdateData(
                schema: "Admin",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "083df9f4-089a-4383-91b9-bfe4f83eb2ef");

            migrationBuilder.UpdateData(
                schema: "Admin",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e7390ec2-7989-4065-acf1-f0e4c3d6db53", "AQAAAAEAACcQAAAAEH1YmmGkvebvam4c3RmXMAjFIwg2G8nVwj8VmIvXPoJZJAqqTV1WU8p2INEsNzZHQw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects",
                schema: "Admin");

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
    }
}
