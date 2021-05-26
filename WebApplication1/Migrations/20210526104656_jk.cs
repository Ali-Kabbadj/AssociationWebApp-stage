using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class jk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Events_Task1TaskId",
                schema: "Admin",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_Task1TaskId",
                schema: "Admin",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Task1TaskId",
                schema: "Admin",
                table: "Events");

            migrationBuilder.AlterColumn<string>(
                name: "RecurrenceID",
                schema: "Admin",
                table: "Events",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Color",
                schema: "Admin",
                table: "Events",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "Admin",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "d419c5b3-ebef-4eba-a0b3-170aa0340323");

            migrationBuilder.UpdateData(
                schema: "Admin",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8fcfee3c-b560-40ed-9ffd-154791612e75", "AQAAAAEAACcQAAAAEOV6oszoZuMwbj35J2NSn/rHstyaymgbwJg+WbEwUAgPO+RCgWGp7CuQzX6SwJ/MPg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RecurrenceID",
                schema: "Admin",
                table: "Events",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                schema: "Admin",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Task1TaskId",
                schema: "Admin",
                table: "Events",
                type: "int",
                nullable: true);

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
    }
}
