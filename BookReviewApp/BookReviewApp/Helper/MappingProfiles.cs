using AutoMapper;
using BookReviewApp.Dto;

namespace BookReviewApp.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Book, BookDto>();
            CreateMap<Genre, GenreDto>();
            CreateMap<Country, CountryDto>();
        }
    }
}