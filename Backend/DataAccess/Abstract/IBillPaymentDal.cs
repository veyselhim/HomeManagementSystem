using System.Collections.Generic;
using Core.EntityFramework;
using Entity.Concrete;
using Entity.DTOs.BillPayment;

namespace DataAccess.Abstract
{
    public interface IBillPaymentDal : IRepository<BillPayment>
    {
        List<BillPaymentDetailDto> GetBillPaymentDetails();
    }
}
