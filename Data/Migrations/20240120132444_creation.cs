using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GBBNews.Data.Migrations
{
    /// <inheritdoc />
    public partial class creation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NewsGenres",
                columns: table => new
                {
                    NewsGenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    genrepicture = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsGenres", x => x.NewsGenreId);
                });

            migrationBuilder.CreateTable(
                name: "NewsStaffs",
                columns: table => new
                {
                    NewsStaffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewsStaffName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewsStaffSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    staffBio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    staffpicture = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsStaffs", x => x.NewsStaffId);
                });

            migrationBuilder.CreateTable(
                name: "WebsiteContents",
                columns: table => new
                {
                    WebsiteContentId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebsiteContents", x => x.WebsiteContentId);
                });

            migrationBuilder.CreateTable(
                name: "NewsArticles",
                columns: table => new
                {
                    NewsArticleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArticlePicture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Newsarticle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewsGenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsArticles", x => x.NewsArticleId);
                    table.ForeignKey(
                        name: "FK_NewsArticles_NewsGenres_NewsGenreId",
                        column: x => x.NewsGenreId,
                        principalTable: "NewsGenres",
                        principalColumn: "NewsGenreId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NewsArticles_NewsGenreId",
                table: "NewsArticles",
                column: "NewsGenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewsArticles");

            migrationBuilder.DropTable(
                name: "NewsStaffs");

            migrationBuilder.DropTable(
                name: "WebsiteContents");

            migrationBuilder.DropTable(
                name: "NewsGenres");
        }
    }
}
