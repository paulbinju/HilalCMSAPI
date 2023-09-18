using AutoMapper;
using Domain.Models;
using Services.DTO;

namespace UserInterface.Profiles
{
    public class ProfileAutoMapper : Profile
    {
        public ProfileAutoMapper()
        {
            CreateMap<IssueDTO, Issue>();
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();
            CreateMap<LookupDTO, Lookup>();
            CreateMap<CategoryDTO, Category>();
            CreateMap<SubCategoryDTO, SubCategory>();
            CreateMap<ArticleExtensionDTO, ArticleExtension>();
            CreateMap<ArticleDTO, Article>();
        }
    }
}
