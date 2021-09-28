using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.ServiceRepository;
using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs.BillPayment;

namespace Business.Abstract
{
    public interface IBillPaymentService : IService<BillPayment>
    {
        IDataResult<List<BillPaymentDetailDto>> GetBillPaymentDetails();
        Task<IResult> AddWithDtoAsync(BillPaymentAddDto billPaymentAddDto);
        Task<IResult> UpdateWithDtoAsync(BillPaymentUpdateDto billPaymentUpdateDto);
        Task<IResult> DeleteWithDtoAsync(BillPaymentDeleteDto billPaymentDeleteDto);
    }
}
