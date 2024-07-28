using LibraryInventory.Models;
using System.ComponentModel.DataAnnotations;

namespace LibraryInventory.ViewModels
{
    /// <summary>
    ///  The BookFormViewModel is a model built 
    ///  specifically for the BookForm View.
    ///   
    ///   It includes data from the Book and Genre 
    ///   classes.
    ///   
    ///   The BookFormViewModel is passed to the
    ///   BookForm.cshtml View by the Books Controller.
    ///  
    /// </summary>
    public class BookFormViewModel
    {
        public IEnumerable<Genre>? Genres { get; set; }

        public int? Id { get; set; }

        [Required]
        public string? Title { get; set; }

        [Display(Name = "Author Last Name")]
        [StringLength(255)]
        [Required]
        public string? AuthorLastName { get; set; }

        [Display(Name = "Author First Name")]
        [StringLength(255)]
        [Required]
        public string? AuthorFirstName { get; set; }

        public string? AuthorName => AuthorFirstName + " " + AuthorLastName;

        [Display(Name = "Date of Publication")]
        [Required]
        [DataType(DataType.Date, ErrorMessage ="Please enter valid date.")]
        public DateTime? PublishDate { get; set; }

        [Display(Name = "Number in Stock")]
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid Number")]
        public int? NumberInStock { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public int? GenreId { get; set; }

        public string HeadingTitle
        {
            get
            {
                return Id != 0 ? "Edit Book" : "New Book";
            }
        }

        public BookFormViewModel()
        {
            Id = 0;
        }

        public BookFormViewModel(Book book)
        {
            Id = book.Id;
            Title = book.Title;
            AuthorFirstName = book.AuthorFirstName;
            AuthorLastName = book.AuthorLastName;
            PublishDate = book.PublishDate;
            NumberInStock = book.NumberInStock;
            GenreId = book.GenreId;
        }
    }
}
