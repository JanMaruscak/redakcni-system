using Microsoft.EntityFrameworkCore.Migrations;

namespace RedakcniSystem.Data.Migrations
{
    public partial class visibility : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b594d67-b21b-4512-b3a2-eb76cc58faa4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c04b07ba-e691-4440-810e-51e2ca505a86");

            migrationBuilder.AddColumn<bool>(
                name: "Visible",
                table: "Articles",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3c127d8d-c62a-45e4-889d-df3117e7f454", "aa685154-51fe-4f23-ba9e-cbf73bd69761", "Redactor", "REDACTOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4153cf29-4d21-4b59-9948-fe2a2d4849c5", "8c20e163-aad0-4449-aa4d-c29bd8b2bf3d", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c127d8d-c62a-45e4-889d-df3117e7f454");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4153cf29-4d21-4b59-9948-fe2a2d4849c5");

            migrationBuilder.DropColumn(
                name: "Visible",
                table: "Articles");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1b594d67-b21b-4512-b3a2-eb76cc58faa4", "5c1dd07f-5cc6-40c1-ae63-27a52d7e928e", "Redactor", "REDACTOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c04b07ba-e691-4440-810e-51e2ca505a86", "26459bb1-59ec-4845-a7c4-0c79aaf819c7", "Administrator", "ADMINISTRATOR" });
        }
    }
}
