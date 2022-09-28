using AutoMapper;
using Feed.Api.DTOs;
using Feed.Business.Models;

namespace Feed.Api.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Author, AuthorDTO>().ReverseMap();
            CreateMap<Content, ContentDTO>().ReverseMap();
            CreateMap<Post, PostDTO>().ReverseMap();

            //CreateMap<Post, PostDTO>()
            //    .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.Author.Id));

        }
    }
}
