using AutoMapper;

namespace BookBoundCoreAPI.Profiles
{
    public class AuthorsProfile : Profile
    {
        public AuthorsProfile()
        {
            CreateMap<Entities.Author, Models.Author>();
            CreateMap<Models.AuthorForCreation, Entities.Author>();
            CreateMap<Models.AuthorForUpdate, Entities.Author>().ReverseMap();
        }
    }
}
