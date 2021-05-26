using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class FFF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                schema: "Admin",
                table: "Journals",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Admin",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "19bdf60f-d2fc-412c-a7b2-34a7b6759643");

            migrationBuilder.UpdateData(
                schema: "Admin",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "635cfa60-ab80-45b2-bb7d-c460e26890ea", "AQAAAAEAACcQAAAAEP9/rxyeEvONc49U9yOqIJuDw0rIALS8Uuz99Xax9wVCut5aUFY9Fx2kjsi7rIFX6w==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                schema: "Admin",
                table: "Journals");

            migrationBuilder.UpdateData(
                schema: "Admin",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "359d2cc8-601f-4323-abb7-ed317a9518d4");

            migrationBuilder.UpdateData(
                schema: "Admin",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7879bceb-06ad-40fe-82bf-e7f5241bba98", "AQAAAAEAACcQAAAAEIZeD/8y0FezscdIriE/bcf0+C1NUqcndy8rhDXA3Ue+00ebUF9yuy3qpogCezFm4A==" });
        }
    }
}
