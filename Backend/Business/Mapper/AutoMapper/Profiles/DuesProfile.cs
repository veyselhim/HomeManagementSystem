using AutoMapper;
using Entity.Concrete;
using Entity.DTOs.Dues;

namespace Business.Mapper.AutoMapper.Profiles
{
    public class DuesProfile : Profile
    {
        public DuesProfile()
        {

            CreateMap<DuesAddDto, Dues>().ReverseMap();
            CreateMap<DuesUpdateDto, Dues>().ReverseMap();
            CreateMap<DuesDeleteDto, Dues>().ReverseMap();
            CreateMap<DuesDetailDto, Dues>().ReverseMap();
            CreateMap<DuesDto, Dues>().ReverseMap();

        }
    }
}
