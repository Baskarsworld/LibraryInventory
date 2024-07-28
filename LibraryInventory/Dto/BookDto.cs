using System.ComponentModel.DataAnnotations;

namespace LibraryInventory.Dto
{
    public class BookDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string? Title { get; set; }

        [Required]
        [StringLength(255)]
        public string? AuthorLastName { get; set; }

        [Required]
        [StringLength(255)]
        public string? AuthorFirstName { get; set; }

        public string? AuthorName { get; set; }

        public DateTime? PublishDate { get; set; }

        public DateTime? DateAdded { get; set; }

        public int NumberInStock { get; set; }

        public int NumberAvailable { get; set; }

        [Required]
        public int GenreId { get; set; }

        public GenreDto? Genre { get; set; }

    }
}