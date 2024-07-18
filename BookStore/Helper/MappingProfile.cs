using AutoMapper;
using BookStore.Dto;
using BookStore.Model;

namespace BookStore.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() { 
            CreateMap<BookDetail, BookDetailsDto>();
            CreateMap<BookDetailsDto, BookDetail>()
                .ForMember(src => src.BookImage, opt => opt.Ignore());

            CreateMap<AuthorDto, Author>()
                .ForMember(src => src.ImageAuthor, opt => opt.Ignore());
            CreateMap<Author,AuthorDto>()
                .ForMember(src => src.ImageAuthor, opt => opt.Ignore());

        }
    }
}
