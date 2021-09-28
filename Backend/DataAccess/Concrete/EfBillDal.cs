using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs.Bill;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class EfBillDal : EfRepository<Bill> , IBillDal
    {
        private readonly ApsisContext _context;
        public EfBillDal(ApsisContext context) : base(context)
        {
            _context = context;
        }

        public List<BillDetailDto> GetBillDetails()
        {
            using (_context)
            {
                var result = from bill in _context.Bills
                    join user in _context.Users on bill.UserId equals user.Id
                    select new BillDetailDto
                    {
                        Id = bill.Id,
                        Name = user.FirstName,
                        SurName = user.LastName,
                        Mail = user.Email,
                        Amount = bill.Amount,
                        InvoiceDate = bill.InvoiceDate,
                        Status = bill.Status,
                        Type = bill.Type
                    };

              return result.ToList();

            }
            
        }

        public async Task<List<BillDetailDto>> GetBillDetailsByUser(Expression<Func<Bill, bool>> filter = null)
        {
            using (_context)
            {
                var result = from bill in filter == null ? _context.Bills : _context.Bills.Where(filter)
                    join user in _context.Users on bill.UserId equals user.Id
                    select new BillDetailDto
                    {
                        Id = bill.Id,
                        Name = user.FirstName,
                        SurName = user.LastName,
                        Mail = user.Email,
                        Amount = bill.Amount,
                        InvoiceDate = bill.InvoiceDate,
                        Status = bill.Status,
                        Type = bill.Type
                    };

                return await result.ToListAsync();
            }
        }
    }
}
