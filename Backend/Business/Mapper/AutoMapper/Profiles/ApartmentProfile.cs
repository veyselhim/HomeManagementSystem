using AutoMapper;
using Entity.Concrete;
using Entity.DTOs.Aparment;

namespace Business.Mapper.AutoMapper.Profiles
{
    public class ApartmentProfile : Profile
    {
        public ApartmentProfile()
        {
            CreateMap<ApartmentAddDto, Apartment>().ReverseMap();
            CreateMap<ApartmentUpdateDto, Apartment>().ReverseMap();
            CreateMap<ApartmentDeleteDto, Apartment>().ReverseMap();

        }
    }
}
