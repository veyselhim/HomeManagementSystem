using AutoMapper;
using Entity.Concrete;
using Entity.DTOs.DuesPayment;

namespace Business.Mapper.AutoMapper.Profiles
{
    public class DuesPaymentProfile : Profile
    {
        public DuesPaymentProfile()
        {
            CreateMap<DuesPaymentAddDto, DuesPayment>().ReverseMap();
            CreateMap<DuesPaymentDeleteDto, DuesPayment>().ReverseMap();
            CreateMap<DuesPaymentUpdateDto, DuesPayment>().ReverseMap();
            CreateMap<DuesPaymentDetailDto, DuesPayment>().ReverseMap();

        }

    }
}
