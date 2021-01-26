using Microsoft.EntityFrameworkCore.Migrations;

namespace RedakcniSystem.Data.Migrations
{
    public partial class menu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c127d8d-c62a-45e4-889d-df3117e7f454");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4153cf29-4d21-4b59-9948-fe2a2d4849c5");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3c127d8d-c62a-45e4-889d-df3117e7f454", "aa685154-51fe-4f23-ba9e-cbf73bd69761", "Redactor", "REDACTOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4153cf29-4d21-4b59-9948-fe2a2d4849c5", "8c20e163-aad0-4449-aa4d-c29bd8b2bf3d", "Administrator", "ADMINISTRATOR" });
        }
    }
}
