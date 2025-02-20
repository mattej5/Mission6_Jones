using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6_Jones.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }  // Nullable because DB allows NULL
        public Category? Category { get; set; } // Navigation Property

        [Required(ErrorMessage = "Movie Title is required")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Movie requires a year")]
        [Range(1888, 2025, ErrorMessage = "Year must be between 1888 and the current year.")]
        public int Year { get; set; }
        public string? Director { get; set; }  // Change to nullable
        public string? Rating { get; set; }  // Change to nullable

        [Required(ErrorMessage = "Error submitting due to 'Edited' status")]
        public bool Edited { get; set; } = false;
        public string? LentTo { get; set; }
        [Required(ErrorMessage = "Error submitting due to 'LentTo' status")]
        public bool CopiedToPlex { get; set; } = false;

        [StringLength(25, ErrorMessage = "Notes must be 25 characters or fewer.")]
        public string? Notes { get; set; }
    }
}