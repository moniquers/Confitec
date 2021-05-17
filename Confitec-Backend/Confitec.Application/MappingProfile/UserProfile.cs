using AutoMapper;
using Confitec.Application.ViewModel;
using Confitec.Domain.Model;

namespace Confitec.Application.MappingProfile
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserVm>().ReverseMap();
            CreateMap<CreateUserVm, User>();
        }
    }
}