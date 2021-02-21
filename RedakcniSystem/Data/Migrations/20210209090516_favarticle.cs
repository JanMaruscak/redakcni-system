using Microsoft.EntityFrameworkCore.Migrations;

namespace RedakcniSystem.Data.Migrations
{
    public partial class favarticle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FavoriteArticles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteArticles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleId",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FavoriteArticlesId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleId_FavoriteArticles_FavoriteArticlesId",
                        column: x => x.FavoriteArticlesId,
                        principalTable: "FavoriteArticles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleId_FavoriteArticlesId",
                table: "ArticleId",
                column: "FavoriteArticlesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleId");

            migrationBuilder.DropTable(
                name: "FavoriteArticles");
        }
    }
}
