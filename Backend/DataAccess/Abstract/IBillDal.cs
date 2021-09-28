using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.EntityFramework;
using Entity.Concrete;
using Entity.DTOs.Aparment;
using Entity.DTOs.Bill;

namespace DataAccess.Abstract
{
    public interface IBillDal : IRepository<Bill>
    {
        List<BillDetailDto> GetBillDetails();
        Task<List<BillDetailDto>> GetBillDetailsByUser(Expression<Func<Bill, bool>> filter = null);
    }
}
