using AutoMapper;
using Entity.Concrete;
using Entity.DTOs.Bill;

namespace Business.Mapper.AutoMapper.Profiles
{
    public class BillProfile : Profile
    {
        public BillProfile()
        {
            CreateMap<BillAddDto, Bill>().ReverseMap();
            CreateMap<BillUpdateDto, Bill>().ReverseMap();
            CreateMap<BillDeleteDto, Bill>().ReverseMap();
            CreateMap<BillDto, Bill>().ReverseMap();

        }
    }
}
