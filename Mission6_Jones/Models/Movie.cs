using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6_Jones.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }  // Nullable because DB allows NULL
        public Category? Category { get; set; } // Navigation Property

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Range(1888, 2025, ErrorMessage = "Year must be between 1888 and the current year.")]
        public int Year { get; set; }
        public string? Director { get; set; }  // Change to nullable
        public string? Rating { get; set; }  // Change to nullable

        [Required]
        public bool Edited { get; set; } = false;
        public string? LentTo { get; set; }
        [Required]
        public bool CopiedToPlex { get; set; } = false;

        [StringLength(25, ErrorMessage = "Notes must be 25 characters or fewer.")]
        public string? Notes { get; set; }
    }
}