using AutoMapper;
using LibraryInventory.Dto;
using LibraryInventory.Models;

namespace LibraryInventory.Utilities
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            // Domain to Dto
            CreateMap<Book, BookDto>();
            CreateMap<Genre, GenreDto>();

            // Dto to Domain              
            CreateMap<BookDto, Book>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}
