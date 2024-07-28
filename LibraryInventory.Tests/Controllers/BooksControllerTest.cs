using LibraryInventory.Controllers;
using LibraryInventory.Models;
using LibraryInventory.Services;
using Moq;

namespace LibraryInventory.Tests.Controllers
{
    public class BooksControllerTest 
    {
        public Mock<IBookServices> mock = new Mock<IBookServices>();

        [Fact]
        public void ShouldDeleteBookForValidRequest()
        {
            // Arrage
            var bookId = 1;
            mock.Setup(p => p.DeleteBook(bookId)).Returns(new LibraryInventory.Models.ServiceResponse<bool>
            {
                Data = true
            });
            var controller = new BooksController(mock.Object);

            // Act
            var result = controller.Delete(bookId);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSaveBookForValidRequest()
        {
            // Arrage
            var book = new Book
            {
                Id = 1,
                Title = "Harry Potter",
                AuthorFirstName = "Paul",
                AuthorLastName = "Joseph"
            };
            mock.Setup(p => p.Save(book)).Returns(new LibraryInventory.Models.ServiceResponse<bool>
            {
                Data = true
            });
            var controller = new BooksController(mock.Object);

            // Act
            var result = controller.Save(book);

            // Assert
            Assert.NotNull(result);
        }
    }
}
