using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using Entity.DTOs.Dues;
using Entity.DTOs.DuesPayment;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class EfDuesPaymentDal : EfRepository<DuesPayment> , IDuesPaymentDal
    {
        private readonly ApsisContext _context;
        public EfDuesPaymentDal(ApsisContext context) : base(context)
        {
            _context = context;
        }


        public List<DuesPaymentDetailDto> GetDuesPaymentDetails()
        {
            using (_context)
            {
                var result = from duesPayment in _context.DuesPayments
                    join dues in _context.Dueses on duesPayment.DuesId equals dues.Id
                    join user in _context.Users on dues.UserId equals user.Id

                    select new DuesPaymentDetailDto
                    {
                        Name = user.FirstName,
                        SurName = user.LastName,
                        Phone = user.Phone,
                        Amount = dues.Amount,
                        InvoiceDate = dues.InvoiceDate,
                        Status = duesPayment.Status
                    };

                return result.ToList();
            }
        }

        public async Task<List<DuesPaymentDetailDto>> GetDuesPaymentDetailsByDues(Expression<Func<DuesPayment, bool>> filter = null)
        {
            var result =
                from duesPayment in filter == null ? _context.DuesPayments : _context.DuesPayments.Where(filter)
                join dues in _context.Dueses on duesPayment.DuesId equals dues.Id
                join user in _context.Users on dues.UserId equals user.Id
                select new DuesPaymentDetailDto
                {
                    Id = duesPayment.Id,
                    Name = user.FirstName,
                    SurName = user.LastName,
                    Phone = user.Phone,
                    Amount = dues.Amount,
                    InvoiceDate = dues.InvoiceDate,
                    Status = duesPayment.Status,
                    PayedDate = duesPayment.PayedDate
                    
                    
                };

            return await result.ToListAsync();
        }
    }
}
