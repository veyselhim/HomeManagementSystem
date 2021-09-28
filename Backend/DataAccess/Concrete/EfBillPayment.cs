using System;
using System.Collections.Generic;
using System.Linq;
using Core.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs.BillPayment;

namespace DataAccess.Concrete
{
    public class EfBillPayment : EfRepository<BillPayment> , IBillPaymentDal
    {
        private readonly ApsisContext _context;
        public EfBillPayment(ApsisContext context) : base(context)
        {
            _context = context;
        }

        public List<BillPaymentDetailDto> GetBillPaymentDetails()
        {
            using (_context)
            {
                var result = from billPayment in _context.BillPayments
                    join bill in _context.Bills on billPayment.BillId equals bill.Id
                    join user in _context.Users on bill.UserId equals user.Id

                    select new BillPaymentDetailDto
                    {
                        Name = user.FirstName,
                        SurName = user.LastName,
                        Phone = user.Phone,
                        Amount = bill.Amount,
                        InvoiceDate = bill.InvoiceDate,
                        Status = billPayment.Status,
                        Type = bill.Type
                    };

                return result.ToList();
            }
        }
    }
}
