using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entity.Concrete;
using Entity.DTOs.User;

namespace Business.Mapper.AutoMapper.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDetailDto, User>().ReverseMap();
            CreateMap<UserDeleteDto, User>().ReverseMap();

        }
    }
}
