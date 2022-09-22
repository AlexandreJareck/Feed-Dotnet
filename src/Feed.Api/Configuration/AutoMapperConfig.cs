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
            CreateMap<Post, PostDTO>().ReverseMap();
            CreateMap<Content, ContentDTO>().ReverseMap();
        }
    }
}
