using System.ComponentModel.DataAnnotations;

namespace Mission6_Jones.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int Id { get; set; }  // Primary Key

        [Required]
        public string Category { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Range(1900, 2100)]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        public bool Edited { get; set; }  // Optional, defaults to false

        public string? LentTo { get; set; }  // Optional

        [StringLength(25)]
        public string? AdditionalNotes { get; set; }  // Optional, max 25 chars
    }
}

