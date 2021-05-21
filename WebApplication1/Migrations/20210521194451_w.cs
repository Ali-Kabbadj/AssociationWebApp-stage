using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class w : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imgae",
                schema: "Admin",
                table: "Parallex");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                schema: "Admin",
                table: "Parallex",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                schema: "Admin",
                table: "Parallex");

            migrationBuilder.AddColumn<byte[]>(
                name: "Imgae",
                schema: "Admin",
                table: "Parallex",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
