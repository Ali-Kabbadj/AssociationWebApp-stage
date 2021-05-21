using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class _134 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parallex",
                schema: "Admin",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Imgae = table.Column<byte[]>(nullable: true),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parallex", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PresnetationSections",
                schema: "Admin",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ParallexId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresnetationSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PresnetationSections_Parallex_ParallexId",
                        column: x => x.ParallexId,
                        principalSchema: "Admin",
                        principalTable: "Parallex",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Paragraphs",
                schema: "Admin",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ParagraphContent = table.Column<string>(nullable: true),
                    SectionId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paragraphs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paragraphs_PresnetationSections_SectionId",
                        column: x => x.SectionId,
                        principalSchema: "Admin",
                        principalTable: "PresnetationSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Paragraphs_SectionId",
                schema: "Admin",
                table: "Paragraphs",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_PresnetationSections_ParallexId",
                schema: "Admin",
                table: "PresnetationSections",
                column: "ParallexId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Paragraphs",
                schema: "Admin");

            migrationBuilder.DropTable(
                name: "PresnetationSections",
                schema: "Admin");

            migrationBuilder.DropTable(
                name: "Parallex",
                schema: "Admin");
        }
    }
}
