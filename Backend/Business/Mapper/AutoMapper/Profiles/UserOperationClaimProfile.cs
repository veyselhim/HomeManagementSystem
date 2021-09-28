using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entity.Concrete;
using Entity.DTOs.UserOperationClaim;

namespace Business.Mapper.AutoMapper.Profiles
{
    public class UserOperationClaimProfile : Profile
    {
        public UserOperationClaimProfile()
        {
            CreateMap<UserOperationClaimDetailDto, UserOperationClaim>().ReverseMap();
            CreateMap<UserOperationClaimAddDto, UserOperationClaim>().ReverseMap();
            CreateMap<UserOperationClaimDeleteDto, UserOperationClaim>().ReverseMap();

        }
    }
}
