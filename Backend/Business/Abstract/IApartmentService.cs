using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.ServiceRepository;
using Core.Utilities.Results;
using Entity;
using Entity.Concrete;
using Entity.DTOs;
using Entity.DTOs.Aparment;

namespace Business.Abstract
{
    public interface IApartmentService : IService<Apartment>
    {
       IDataResult<List<ApartmentDetailDto>> GetApartmentDetails();
       Task<IDataResult<ApartmentDetailDto>> GetApartmentDetail(int id);

        Task<IResult> AddWithDtoAsync(ApartmentAddDto apartmentAddDto);
       Task<IResult> UpdateWithDtoAsync(ApartmentUpdateDto apartmentUpdateDto);
       Task<IResult> DeleteWithDtoAsync(ApartmentDeleteDto apartmentDeleteDto);

       Task<IDataResult<ApartmentAddDto>> GetByUserId(int id);



    }
}
