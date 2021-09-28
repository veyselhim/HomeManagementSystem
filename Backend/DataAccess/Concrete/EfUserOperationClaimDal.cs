using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs.UserOperationClaim;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class EfUserOperationClaimDal : EfRepository<UserOperationClaim> , IUserOperationClaimDal
    {
        private readonly ApsisContext _context;
        public EfUserOperationClaimDal(ApsisContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<UserOperationClaimDetailDto>> GetUserOperationClaimDetails()
        {
            using (_context)
            {
                var result = from userOperation in _context.UserOperationClaims
                    join user in _context.Users on userOperation.UserId equals user.Id
                    join operationClaim in _context.OperationClaims on userOperation.OperationClaimId equals
                        operationClaim.Id
                    select new UserOperationClaimDetailDto
                    {
                        FirstName = user.FirstName,
                        OperationClaimName = operationClaim.Name
                    };

                return await result.ToListAsync();
            }
        }
    }
}
