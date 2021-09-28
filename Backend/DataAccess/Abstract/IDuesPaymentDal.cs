using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.EntityFramework;
using Entity.Concrete;
using Entity.DTOs;
using Entity.DTOs.Dues;
using Entity.DTOs.DuesPayment;

namespace DataAccess.Abstract
{
    public interface IDuesPaymentDal : IRepository<DuesPayment>
    {
        List<DuesPaymentDetailDto> GetDuesPaymentDetails();
        Task<List<DuesPaymentDetailDto>> GetDuesPaymentDetailsByDues(Expression<Func<DuesPayment, bool>> filter = null);


    }
}
