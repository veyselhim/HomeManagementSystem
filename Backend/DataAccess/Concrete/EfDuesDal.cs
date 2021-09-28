using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity;
using Entity.Concrete;
using Entity.DTOs.Bill;
using Entity.DTOs.Dues;

namespace DataAccess.Concrete
{
    public class EfDuesDal : EfRepository<Dues> , IDuesDal
    {
        private readonly ApsisContext _context;
        public EfDuesDal(ApsisContext context) : base(context)
        {
            _context = context;
        }

        public List<DuesDetailDto> GetDuesDetails()
        {
            using (_context)
            {
                var result = from dues in _context.Dueses
                    join user in _context.Users on dues.UserId equals user.Id
                    select new DuesDetailDto
                    {
                        Id = dues.Id,
                        Name = user.FirstName,
                        SurName = user.LastName,
                        Mail = user.Email,
                        Amount = dues.Amount,
                        InvoiceDate = dues.InvoiceDate,
                        Status = dues.Status,
                        
                    };

                return result.ToList();
            }
        }

       
    }
}
