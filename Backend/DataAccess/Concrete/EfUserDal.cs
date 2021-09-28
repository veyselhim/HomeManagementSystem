using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs.User;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class EfUserDal : EfRepository<User>, IUserDal
    {
        private readonly ApsisContext _context;
        public EfUserDal(ApsisContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<OperationClaim>> GetClaims(User user)
        {
            using (_context)
            {
                var result = from operationClaim in _context.OperationClaims
                    join userOperationClaim in _context.UserOperationClaims on operationClaim.Id equals
                        userOperationClaim.OperationClaimId
                    where userOperationClaim.UserId == user.Id
                    select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return await result.ToListAsync();


            }
        }

    }
}
