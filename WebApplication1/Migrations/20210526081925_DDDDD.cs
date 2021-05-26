using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class DDDDD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                schema: "Admin",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "Admin",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EndDate",
                schema: "Admin",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "StartDate",
                schema: "Admin",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                schema: "Admin",
                table: "Events",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "End",
                schema: "Admin",
                table: "Events",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EndTimezone",
                schema: "Admin",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAllDay",
                schema: "Admin",
                table: "Events",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "RecurrenceException",
                schema: "Admin",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecurrenceID",
                schema: "Admin",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecurrenceRule",
                schema: "Admin",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Start",
                schema: "Admin",
                table: "Events",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "StartTimezone",
                schema: "Admin",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Task1TaskId",
                schema: "Admin",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                schema: "Admin",
                table: "Events",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                schema: "Admin",
                table: "Events",
                column: "TaskId");

            migrationBuilder.UpdateData(
                schema: "Admin",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "2cea149f-345f-4ee4-b5f4-bec5cd685eb9");

            migrationBuilder.UpdateData(
                schema: "Admin",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d3a88f25-6929-4dc4-b2ff-845974d26b68", "AQAAAAEAACcQAAAAENKz+R8kI+PjGj1NpQpphhEAW7g/vAeYZhaJQEGPc19akJeqkrgldFOp6aph0kR0cA==" });

            migrationBuilder.CreateIndex(
                name: "IX_Events_Task1TaskId",
                schema: "Admin",
                table: "Events",
                column: "Task1TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Events_Task1TaskId",
                schema: "Admin",
                table: "Events",
                column: "Task1TaskId",
                principalSchema: "Admin",
                principalTable: "Events",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Events_Task1TaskId",
                schema: "Admin",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                schema: "Admin",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_Task1TaskId",
                schema: "Admin",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "TaskId",
                schema: "Admin",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "End",
                schema: "Admin",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EndTimezone",
                schema: "Admin",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "IsAllDay",
                schema: "Admin",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "RecurrenceException",
                schema: "Admin",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "RecurrenceID",
                schema: "Admin",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "RecurrenceRule",
                schema: "Admin",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Start",
                schema: "Admin",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "StartTimezone",
                schema: "Admin",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Task1TaskId",
                schema: "Admin",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Title",
                schema: "Admin",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                schema: "Admin",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                schema: "Admin",
                table: "Events",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                schema: "Admin",
                table: "Events",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                schema: "Admin",
                table: "Events",
                column: "Id");

            migrationBuilder.UpdateData(
                schema: "Admin",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "bc349629-d1c2-4f7f-884c-c9e931216895");

            migrationBuilder.UpdateData(
                schema: "Admin",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "914fe382-64c9-4f46-a2b7-8f85e69af3b7", "AQAAAAEAACcQAAAAENVMX3YNkOEsEjI7Jle8itGpLvil4MxLrvB9LVmTX/WX4RiCEXpN+Nm0R/9K7NZdtQ==" });
        }
    }
}
