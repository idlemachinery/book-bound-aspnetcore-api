using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookBoundCoreAPI.Entities
{
    [Table("Authors")]
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Name must be at least three characters")]
        [MaxLength(50, ErrorMessage = "Name must not exceed 50 characters")]
        public string Name { get; set; }
    }
}