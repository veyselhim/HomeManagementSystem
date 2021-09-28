using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entity.Concrete;
using Entity.DTOs.Message;

namespace Business.Mapper.AutoMapper.Profiles
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<MessageAddDto, Message>().ReverseMap();
            CreateMap<MessageDeleteDto, Message>().ReverseMap();
        }
    }
}
