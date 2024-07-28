using System.ComponentModel.DataAnnotations;

namespace LibraryInventory.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string? Name { get; set; }
    }
}
