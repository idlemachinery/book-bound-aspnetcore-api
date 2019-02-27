using BookBoundCoreAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookBoundCoreAPI.Contexts
{
    public class BookBoundContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        public BookBoundContext(DbContextOptions<BookBoundContext> options)
            : base(options)
        {
        }

        // seed the database with data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // authors
            modelBuilder.Entity<Author>().HasData(
               new Author() { Id = 1, Name = "Lev Nikolayevich Tolstoy" },
               new Author() { Id = 2, Name = "Victor Hugo" },
               new Author() { Id = 3, Name = "H. G. Wells" },
               new Author() { Id = 4, Name = "Jules Verne" },
               new Author() { Id = 5, Name = "Henry Kuttner" },
               new Author() { Id = 6, Name = "Kenneth Grahame" },
               new Author() { Id = 7, Name = "Mark Twain" }
               );

            modelBuilder.Entity<Book>().HasData(
                new Book()
                {
                    Id = 1,
                    Title = "War and Peace",
                    Genre = "Historical Fiction",
                    //AuthorId = 1,
                    Author = "Lev Nikolayevich Tolstoy",
                    Description = "",
                    CoverImage = "https://images.gr-assets.com/books/1413215930m/656.jpg",
                    GoodreadsId = 656,
                    Read = false
                },
                new Book()
                {
                    Id = 2,
                    Title = "Les Misérables",
                    Genre = "Historical Fiction",
                    //AuthorId = 2,
                    Author = "Victor Hugo",
                    Description = "",
                    CoverImage = "https://images.gr-assets.com/books/1411852091m/24280.jpg",
                    GoodreadsId = 24280,
                    Read = false
                },
                new Book()
                {
                    Id = 3,
                    Title = "The Time Machine",
                    Genre = "Science Fiction",
                    //AuthorId = 3,
                    Author = "H. G. Wells",
                    Description = "",
                    CoverImage = "https://images.gr-assets.com/books/1327942880m/2493.jpg",
                    GoodreadsId = 2493,
                    Read = false
                },
                new Book()
                {
                    Id = 4,
                    Title = "A Journey into the Center of the Earth",
                    Genre = "Science Fiction",
                    //AuthorId = 4,
                    Author = "Jules Verne",
                    Description = "",
                    CoverImage = "https://s.gr-assets.com/assets/nophoto/book/111x148-bcc042a9c91a29c1d680899eff700a03.png",
                    GoodreadsId = 32829,
                    Read = false
                },
                new Book()
                {
                    Id = 5,
                    Title = "The Dark World",
                    Genre = "Fantasy",
                    //AuthorId = 5,
                    Author = "Henry Kuttner",
                    Description = "",
                    CoverImage = "https://images.gr-assets.com/books/1322680910m/1881716.jpg",
                    GoodreadsId = 1881716,
                    Read = false
                },
                new Book()
                {
                    Id = 6,
                    Title = "The Wind in the Willows",
                    Genre = "Fantasy",
                    //AuthorId = 6,
                    Author = "Kenneth Grahame",
                    Description = "",
                    CoverImage = "https://images.gr-assets.com/books/1423183570m/5659.jpg",
                    GoodreadsId = 5659,
                    Read = false
                },
                new Book()
                {
                    Id = 7,
                    Title = "Life On The Mississippi",
                    Genre = "History",
                    //AuthorId = 7,
                    Author = "Mark Twain",
                    Description = "",
                    CoverImage = "https://images.gr-assets.com/books/1309286211m/99152.jpg",
                    GoodreadsId = 99152,
                    Read = false
                },
                new Book()
                {
                    Id = 8,
                    Title = "Childhood",
                    Genre = "Biography",
                    //AuthorId = 1,
                    Author = "Lev Nikolayevich Tolstoy",
                    Description = "",
                    CoverImage = "https://s.gr-assets.com/assets/nophoto/book/111x148-bcc042a9c91a29c1d680899eff700a03.png",
                    GoodreadsId = 2359878,
                    Read = false
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
