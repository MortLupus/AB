using AutoMapper;
using MVC4.Models;
using MVC4.ViewModels.Account;

namespace MVC4.Infrastructure.AutoMapper.Profiles
{
    public class UserProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<RegisterModel, User>()
                .ForMember(x => x.Id, o => o.Ignore());
        }
    }
}