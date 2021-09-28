using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.EntityFramework;
using Entity.Concrete;
using Entity.DTOs.Aparment;
using Entity.DTOs.UserOperationClaim;

namespace DataAccess.Abstract
{
    public interface IUserOperationClaimDal : IRepository<UserOperationClaim>
    {
        Task<List<UserOperationClaimDetailDto>> GetUserOperationClaimDetails();
    }
}
