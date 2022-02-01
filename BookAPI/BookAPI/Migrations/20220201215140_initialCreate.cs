using Microsoft.EntityFrameworkCore.Migrations;

namespace BookAPI.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    BookDescription = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    BookAuthor = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    BookPublisher = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    ISBN = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
