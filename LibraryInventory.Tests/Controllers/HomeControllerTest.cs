using LibraryInventory.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace LibraryInventory.Tests.Controllers
{
    public class HomeControllerTest
    {       
        [Fact]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult? result = controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
        }
    }
}
