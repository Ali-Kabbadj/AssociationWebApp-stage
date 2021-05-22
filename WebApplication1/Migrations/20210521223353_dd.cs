using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class dd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Admin");

            migrationBuilder.CreateTable(
                name: "Section",
                schema: "Admin",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Image = table.Column<byte[]>(nullable: true),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Section", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Slide",
                schema: "Admin",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Image = table.Column<byte[]>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slide", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paragraph",
                schema: "Admin",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ParagraphContent = table.Column<string>(nullable: true),
                    SectionId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paragraph", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paragraph_Section_SectionId",
                        column: x => x.SectionId,
                        principalSchema: "Admin",
                        principalTable: "Section",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Paragraph_SectionId",
                schema: "Admin",
                table: "Paragraph",
                column: "SectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Paragraph",
                schema: "Admin");

            migrationBuilder.DropTable(
                name: "Slide",
                schema: "Admin");

            migrationBuilder.DropTable(
                name: "Section",
                schema: "Admin");
        }
    }
}
