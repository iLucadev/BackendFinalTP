using AutoMapper;
using BookLibrary.Models.Domain;
using BookLibrary.Models.DTOs;

namespace BookLibrary
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Book, BookDTO>();
            CreateMap<BookDTO, Book>();
        }
    }
}
