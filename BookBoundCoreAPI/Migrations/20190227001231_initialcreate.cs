using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookBoundCoreAPI.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Author = table.Column<string>(maxLength: 50, nullable: false),
                    Genre = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    CoverImage = table.Column<string>(nullable: true),
                    GoodreadsId = table.Column<int>(nullable: false),
                    Read = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Lev Nikolayevich Tolstoy" },
                    { 2, "Victor Hugo" },
                    { 3, "H. G. Wells" },
                    { 4, "Jules Verne" },
                    { 5, "Henry Kuttner" },
                    { 6, "Kenneth Grahame" },
                    { 7, "Mark Twain" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CoverImage", "Description", "Genre", "GoodreadsId", "Read", "Title" },
                values: new object[,]
                {
                    { 1, "Lev Nikolayevich Tolstoy", "https://images.gr-assets.com/books/1413215930m/656.jpg", "", "Historical Fiction", 656, false, "War and Peace" },
                    { 2, "Victor Hugo", "https://images.gr-assets.com/books/1411852091m/24280.jpg", "", "Historical Fiction", 24280, false, "Les Misérables" },
                    { 3, "H. G. Wells", "https://images.gr-assets.com/books/1327942880m/2493.jpg", "", "Science Fiction", 2493, false, "The Time Machine" },
                    { 4, "Jules Verne", "https://s.gr-assets.com/assets/nophoto/book/111x148-bcc042a9c91a29c1d680899eff700a03.png", "", "Science Fiction", 32829, false, "A Journey into the Center of the Earth" },
                    { 5, "Henry Kuttner", "https://images.gr-assets.com/books/1322680910m/1881716.jpg", "", "Fantasy", 1881716, false, "The Dark World" },
                    { 6, "Kenneth Grahame", "https://images.gr-assets.com/books/1423183570m/5659.jpg", "", "Fantasy", 5659, false, "The Wind in the Willows" },
                    { 7, "Mark Twain", "https://images.gr-assets.com/books/1309286211m/99152.jpg", "", "History", 99152, false, "Life On The Mississippi" },
                    { 8, "Lev Nikolayevich Tolstoy", "https://s.gr-assets.com/assets/nophoto/book/111x148-bcc042a9c91a29c1d680899eff700a03.png", "", "Biography", 2359878, false, "Childhood" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
