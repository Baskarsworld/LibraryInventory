using AutoMapper;
using LibraryInventory.Dto;
using LibraryInventory.EntityDB;
using LibraryInventory.Models;
using LibraryInventory.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace LibraryInventory.Services
{
    public class BookServices : IBookServices
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<BookServices> _logger;

        public BookServices(ApplicationDbContext dbContext, IMapper mapper, ILogger<BookServices> logger) 
        { 
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public ServiceResponse<IEnumerable<BookDto>> GetBooks()
        {
            IEnumerable<BookDto>? response = null;

            try
            {
                var booksQuery = _dbContext.Books
               .Include(b => b.Genre)
               .Where(b => b.NumberInStock > 0);

                response = booksQuery
                    .ToList()
                    .Select(_mapper.Map<Book, BookDto>);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured while retrieving Books", ex);

                return new ServiceResponse<IEnumerable<BookDto>>
                {
                    Status = System.Net.HttpStatusCode.InternalServerError
                };
            }

            return new ServiceResponse<IEnumerable<BookDto>> 
            {
                Data = response
            };
        }

        public ServiceResponse<BookFormViewModel> GetBookFormViewModel(int? id = null)
        {
            BookFormViewModel? viewModel = null;

            try
            {
                if (id != null) //for Edit
                {
                    var book = _dbContext.Books.SingleOrDefault(b => b.Id == id);

                    if (book == null)
                    {
                        return new ServiceResponse<BookFormViewModel>
                        {
                            Status = System.Net.HttpStatusCode.NotFound
                        };
                    }

                    viewModel = new BookFormViewModel(book)
                    {
                        Genres = _dbContext.Genres.ToList()
                    };
                }
                else //for New
                {
                    viewModel = new BookFormViewModel()
                    {
                        Genres = _dbContext.Genres.ToList()
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured while retrieving Book Form View Model", ex);

                return new ServiceResponse<BookFormViewModel>
                {
                    Status = System.Net.HttpStatusCode.InternalServerError
                };
            }

            return new ServiceResponse<BookFormViewModel>
            {
                Data = viewModel
            };
        }

        public ServiceResponse<bool> Save(Book book)
        {
            try
            {
                if (book.Id == 0)
                {
                    book.DateAdded = DateTime.Now;
                    book.NumberAvailable = book.NumberInStock;
                    _dbContext.Books.Add(book);
                }
                else
                {
                    var bookInDb = _dbContext.Books.Single(b => b.Id == book.Id);
                    bookInDb.Title = book.Title;
                    bookInDb.AuthorFirstName = book.AuthorFirstName;
                    bookInDb.AuthorLastName = book.AuthorLastName;
                    bookInDb.PublishDate = book.PublishDate;
                    bookInDb.NumberInStock = book.NumberInStock;
                }

                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured while Adding / Saving Book", ex);

                return new ServiceResponse<bool>
                {
                    Status = System.Net.HttpStatusCode.InternalServerError
                };
            }

            return new ServiceResponse<bool>
            {
                Data = true,
            };
        }

        public ServiceResponse<bool> DeleteBook(int id)
        {
            try
            {
                var bookInDb = _dbContext.Books.SingleOrDefault(c => c.Id == id);

                if (bookInDb == null)
                {
                    return new ServiceResponse<bool>
                    {
                        Status = System.Net.HttpStatusCode.NotFound
                    };
                }

                _dbContext.Books.Remove(bookInDb);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured while deleting Book", ex);

                return new ServiceResponse<bool>
                {
                    Status = System.Net.HttpStatusCode.InternalServerError
                };
            }

            return new ServiceResponse<bool>
            {
                Data = true,
            };
        }
    }

    public interface IBookServices
    {
        public ServiceResponse<IEnumerable<BookDto>> GetBooks();
        public ServiceResponse<BookFormViewModel> GetBookFormViewModel(int? id = null);
        public ServiceResponse<bool> Save(Book book);
        public ServiceResponse<bool> DeleteBook(int id);
   }
}
