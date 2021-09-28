using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entity.Concrete;
using Entity.DTOs.CardDocument;

namespace Business.Mapper.AutoMapper.Profiles
{
    public class CardDocumentProfile : Profile
    {
        public CardDocumentProfile()
        {
            CreateMap<CardAddDocument, CardDocument>().ReverseMap();
            CreateMap<CardAddDocument, CardDocument>().ReverseMap();
            CreateMap<CardUpdateDocument, CardDocument>().ReverseMap();
        }
    }
}
