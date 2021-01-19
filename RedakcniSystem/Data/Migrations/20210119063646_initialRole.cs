using Microsoft.EntityFrameworkCore.Migrations;

namespace RedakcniSystem.Data.Migrations
{
    public partial class initialRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1b568609-f69a-4f40-84ed-dc08648f8be2", "d2a68826-ef8b-4be8-b1e3-bc26e76aed9e", "Redactor", "REDACTOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "41d04e84-088e-45fa-b05e-8befea7f1a8f", "a1879d91-3bf1-4e73-8bfe-3e0f76dbeb84", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b568609-f69a-4f40-84ed-dc08648f8be2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41d04e84-088e-45fa-b05e-8befea7f1a8f");
        }
    }
}
