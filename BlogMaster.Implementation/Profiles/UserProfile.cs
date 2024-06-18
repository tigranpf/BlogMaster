using AutoMapper;
using BlogMaster.Application.DTO.Users;
using BlogMaster.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMaster.Implementation.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>()
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => new RoleDTO
            {
                RoleId = src.RoleId,
                Title = src.Role.Title
            }))
            .ForMember(dest => dest.UserUseCases, opt => opt.MapFrom(src => src.UserUseCases.Select(uuc => uuc.UseCaseId).ToList()));
        }
    }
}
