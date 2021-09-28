using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.ServiceRepository;
using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs.Bill;

namespace Business.Abstract
{
    public interface IBillService
    {
        Task<IResult> AddWithDtoAsync(BillAddDto billAddDto);
        Task<IResult> UpdateWithDtoAsync(BillUpdateDto billUpdateDto);
        Task<IResult> DeleteWithDtoAsync(BillDeleteDto billDeleteDto);

        Task<IDataResult<List<BillDto>>> GetAllAsync();
        Task<IDataResult<Bill>> GetByIdAsync(int id);

        Task<IDataResult<List<BillDto>>> GetByUserId(int id);
        IDataResult<List<BillDetailDto>> GetBillDetails();
        Task<IDataResult<List<BillDetailDto>>> GetBillDetailsByUser(int userId);


    }
}
