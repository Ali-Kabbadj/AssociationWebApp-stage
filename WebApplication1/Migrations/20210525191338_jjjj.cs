using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class jjjj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                schema: "Admin",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Latitude = table.Column<string>(nullable: true),
                    Longitude = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.UpdateData(
                schema: "Admin",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "8ffa42cd-6911-4863-93cf-cc51e44ae80b");

            migrationBuilder.UpdateData(
                schema: "Admin",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ceb251f5-b624-45f5-927a-2cea57e66ffa", "AQAAAAEAACcQAAAAEKb1baNpaC7vzRCk1NFMNUa2kbbhoH84yx0vUUKwP35r0l8Or6GPW3UffNhH5QAqgg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locations",
                schema: "Admin");

            migrationBuilder.UpdateData(
                schema: "Admin",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "1e9dfe04-6580-458b-b371-7d37653f80a6");

            migrationBuilder.UpdateData(
                schema: "Admin",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dc1c8258-87bb-4cc8-9e47-82f9c99f85c2", "AQAAAAEAACcQAAAAECcHRTCeqggbPXL/82yU7F+/2onD40SiF3H8HbR9I375rystw4UdkdpRU/5ZPFWPdQ==" });
        }
    }
}
