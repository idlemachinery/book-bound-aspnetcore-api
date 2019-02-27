using System.ComponentModel.DataAnnotations;

namespace BookBoundCoreAPI.Models
{
    public class AuthorForUpdate
    {
        [Required]
        [MinLength(3, ErrorMessage = "Name must be at least three characters")]
        [MaxLength(50, ErrorMessage = "Name must not exceed 50 characters")]
        public string Name { get; set; }
    }
}
