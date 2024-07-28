using LibraryInventory.Configuration;
using LibraryInventory.Models;
using LibraryInventory.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryInventory.Controllers
{
    
    public class BooksController : Controller
    {
        private readonly IBookServices _bookService;

        public BooksController(IBookServices bookService)
        {
            _bookService = bookService;
        }

        [Authorize]
        public IActionResult Index()
        {
            var result = _bookService.GetBooks();

            if (result.Status != System.Net.HttpStatusCode.OK)
                return new StatusCodeResult((int)result.Status);

            if(User.IsInRole("ManageBook"))
            {
                return View("Index", result.Data);
            }

            return View("ReadOnlyIndex", result.Data);
        }

        [Authorize(Roles = "ManageBook")]
        public ActionResult New()
        {
            var result = _bookService.GetBookFormViewModel();

            if (result.Status != System.Net.HttpStatusCode.OK)
                return new StatusCodeResult((int)result.Status);

            return View("BookForm", result.Data);
        }

        [Authorize(Roles = "ManageBook")]
        public IActionResult Edit(int id)
        {
            var result = _bookService.GetBookFormViewModel(id);

            if (result.Status != System.Net.HttpStatusCode.OK)
                return new StatusCodeResult((int)result.Status);

            return View("BookForm", result.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidationFilterAttribute]
        [Authorize(Roles = "ManageBook")]
        public ActionResult Save(Book book)
        {
            //Modelstate validation is handled in Action Filter called ValidationFilterAttribute

            var result = _bookService.Save(book);

            if (result.Status != System.Net.HttpStatusCode.OK)
                return new StatusCodeResult((int)result.Status);

            return RedirectToAction("Index", "Books");
        }

        [HttpDelete]
        [Authorize(Roles = "ManageBook")]
        public ActionResult Delete(int id)
        {
            var result = _bookService.DeleteBook(id);

            if (result.Status != System.Net.HttpStatusCode.OK)
                return new StatusCodeResult((int)result.Status);   

            return RedirectToAction("Index", "Books");
        }
    }
}
