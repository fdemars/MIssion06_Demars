using Mission06_Demars.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MIssion06_Demars.Models
{
    public class Movie
    {
        [Key] // set the MovieId as the key and required
        [Required]
        public int MovieId { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        [Required (ErrorMessage = "Please input a title")] // set the title as required and add an error message
        public string Title { get; set; }

        [Required]
        [Range(1888, int.MaxValue, ErrorMessage = "The year must be greater than or equal to 1888.")] //set the year as required, and no year greater than 1888
        public int Year {  get; set; }

        public string? Director { get; set; }

        public string? Rating { get; set; }

        [Required]
        public bool Edited { get; set; } //this field is required

        public string? LentTo { get; set; }

        [Required]
        public bool CopiedToPlex { get; set; } //this field is required

        [MaxLength(25, ErrorMessage = "Limit notes to under 25 characters")] // limit notes to 25 characters. add an error message
        public string? Notes { get; set; }
        
    }
}
