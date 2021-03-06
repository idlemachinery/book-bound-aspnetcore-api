﻿// <auto-generated />
using BookBoundCoreAPI.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookBoundCoreAPI.Migrations
{
    [DbContext(typeof(BookBoundContext))]
    partial class BookBoundContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookBoundCoreAPI.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Lev Nikolayevich Tolstoy"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Victor Hugo"
                        },
                        new
                        {
                            Id = 3,
                            Name = "H. G. Wells"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Jules Verne"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Henry Kuttner"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Kenneth Grahame"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Mark Twain"
                        });
                });

            modelBuilder.Entity("BookBoundCoreAPI.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("CoverImage");

                    b.Property<string>("Description")
                        .HasMaxLength(1000);

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("GoodreadsId");

                    b.Property<bool>("Read");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Lev Nikolayevich Tolstoy",
                            CoverImage = "https://images.gr-assets.com/books/1413215930m/656.jpg",
                            Description = "",
                            Genre = "Historical Fiction",
                            GoodreadsId = 656,
                            Read = false,
                            Title = "War and Peace"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Victor Hugo",
                            CoverImage = "https://images.gr-assets.com/books/1411852091m/24280.jpg",
                            Description = "",
                            Genre = "Historical Fiction",
                            GoodreadsId = 24280,
                            Read = false,
                            Title = "Les Misérables"
                        },
                        new
                        {
                            Id = 3,
                            Author = "H. G. Wells",
                            CoverImage = "https://images.gr-assets.com/books/1327942880m/2493.jpg",
                            Description = "",
                            Genre = "Science Fiction",
                            GoodreadsId = 2493,
                            Read = false,
                            Title = "The Time Machine"
                        },
                        new
                        {
                            Id = 4,
                            Author = "Jules Verne",
                            CoverImage = "https://s.gr-assets.com/assets/nophoto/book/111x148-bcc042a9c91a29c1d680899eff700a03.png",
                            Description = "",
                            Genre = "Science Fiction",
                            GoodreadsId = 32829,
                            Read = false,
                            Title = "A Journey into the Center of the Earth"
                        },
                        new
                        {
                            Id = 5,
                            Author = "Henry Kuttner",
                            CoverImage = "https://images.gr-assets.com/books/1322680910m/1881716.jpg",
                            Description = "",
                            Genre = "Fantasy",
                            GoodreadsId = 1881716,
                            Read = false,
                            Title = "The Dark World"
                        },
                        new
                        {
                            Id = 6,
                            Author = "Kenneth Grahame",
                            CoverImage = "https://images.gr-assets.com/books/1423183570m/5659.jpg",
                            Description = "",
                            Genre = "Fantasy",
                            GoodreadsId = 5659,
                            Read = false,
                            Title = "The Wind in the Willows"
                        },
                        new
                        {
                            Id = 7,
                            Author = "Mark Twain",
                            CoverImage = "https://images.gr-assets.com/books/1309286211m/99152.jpg",
                            Description = "",
                            Genre = "History",
                            GoodreadsId = 99152,
                            Read = false,
                            Title = "Life On The Mississippi"
                        },
                        new
                        {
                            Id = 8,
                            Author = "Lev Nikolayevich Tolstoy",
                            CoverImage = "https://s.gr-assets.com/assets/nophoto/book/111x148-bcc042a9c91a29c1d680899eff700a03.png",
                            Description = "",
                            Genre = "Biography",
                            GoodreadsId = 2359878,
                            Read = false,
                            Title = "Childhood"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
