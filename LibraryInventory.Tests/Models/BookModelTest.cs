using LibraryInventory.Models;

namespace LibraryInventory.Tests.Models
{
    public class BookModelTest
    {
        [Fact]
        public void CheckAuthourFullNameForValidRequest()
        {
            // Arrange
            Book model = new Book
            {
                Title = "test title",
                AuthorFirstName = "John",
                AuthorLastName = "Pual",
                PublishDate = new DateTime(2000, 1, 1),
                NumberInStock = 1,
                GenreId = 1
            };

            // Act
            string result = "John Pual";

            // Assert
            Assert.Equal(result, model.AuthorName);
        }
    }
}
