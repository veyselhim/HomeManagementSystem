using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.ServiceRepository;
using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs;
using Entity.DTOs.DuesPayment;

namespace Business.Abstract
{
    public interface IDuesPaymentService : IService<DuesPayment>
    {
        IDataResult<List<DuesPaymentDetailDto>> GetDuesPaymentDetails();
        Task<IDataResult<List<DuesPaymentDetailDto>>> GetDuesPaymentDetailByDues(int duesId);

        Task<IResult> AddWithDtoAsync(DuesPaymentAddDto duesPaymentAddDto);
        Task<IResult> UpdateWithDtoAsync(DuesPaymentUpdateDto duesPaymentUpdateDto);
        Task<IResult> DeleteWithDtoAsync(DuesPaymentDeleteDto duesPaymentDeleteDto);

    }
}
