using System.ComponentModel.DataAnnotations;

namespace LibraryInventory.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string? Title { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Author First Name")]
        public string? AuthorFirstName { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Author Last Name")]
        public string? AuthorLastName { get; set; }
               
        public string? AuthorName => AuthorFirstName + " " + AuthorLastName;

        [Display(Name = "Date of Publication")]
        public DateTime? PublishDate { get; set; }

        public DateTime? DateAdded { get; set; }

        [Display(Name = "Number in Stock")]
        public int? NumberInStock { get; set; }

        public int? NumberAvailable { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public int? GenreId { get; set; }

        public Genre? Genre { get; set; }
    }
}
