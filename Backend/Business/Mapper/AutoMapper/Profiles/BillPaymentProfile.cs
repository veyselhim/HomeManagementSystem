using AutoMapper;
using Entity.Concrete;
using Entity.DTOs.BillPayment;

namespace Business.Mapper.AutoMapper.Profiles
{
    public class BillPaymentProfile : Profile
    {
        public BillPaymentProfile()
        {
            CreateMap<BillPaymentAddDto, BillPayment>().ReverseMap();
            CreateMap<BillPaymentDeleteDto, BillPayment>().ReverseMap();
            CreateMap<BillPaymentUpdateDto, BillPayment>().ReverseMap();
            CreateMap<BillPaymentDetailDto, BillPayment>().ReverseMap();


        }
    }
}
