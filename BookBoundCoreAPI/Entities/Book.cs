using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookBoundCoreAPI.Entities
{
    [Table("Books")]
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Title must be at least three characters")]
        [MaxLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
        public string Title { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Author must be at least three characters")]
        [MaxLength(50, ErrorMessage = "Author must not exceed 50 characters")]
        public string Author { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Genre cannot exceed 50 characters")]
        public string Genre { get; set; }

        [MaxLength(1000, ErrorMessage = "Description cannot exceed 1000 characters")]
        public string Description { get; set; }

        [RegularExpression(@".*\/.*.(png|jpg|jpeg)", ErrorMessage = "Must be a png or jpg")]
        public string CoverImage { get; set; }

        public int GoodreadsId { get; set; }

        public bool Read { get; set; }
    }
}
