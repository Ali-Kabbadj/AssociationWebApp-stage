using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class dd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PresnetationSections_Parallex_ParallexId",
                schema: "Admin",
                table: "PresnetationSections");

            migrationBuilder.DropTable(
                name: "Parallex",
                schema: "Admin");

            migrationBuilder.DropIndex(
                name: "IX_PresnetationSections_ParallexId",
                schema: "Admin",
                table: "PresnetationSections");

            migrationBuilder.DropColumn(
                name: "ParallexId",
                schema: "Admin",
                table: "PresnetationSections");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                schema: "Admin",
                table: "PresnetationSections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text",
                schema: "Admin",
                table: "PresnetationSections",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                schema: "Admin",
                table: "PresnetationSections");

            migrationBuilder.DropColumn(
                name: "Text",
                schema: "Admin",
                table: "PresnetationSections");

            migrationBuilder.AddColumn<string>(
                name: "ParallexId",
                schema: "Admin",
                table: "PresnetationSections",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Parallex",
                schema: "Admin",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parallex", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PresnetationSections_ParallexId",
                schema: "Admin",
                table: "PresnetationSections",
                column: "ParallexId");

            migrationBuilder.AddForeignKey(
                name: "FK_PresnetationSections_Parallex_ParallexId",
                schema: "Admin",
                table: "PresnetationSections",
                column: "ParallexId",
                principalSchema: "Admin",
                principalTable: "Parallex",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
