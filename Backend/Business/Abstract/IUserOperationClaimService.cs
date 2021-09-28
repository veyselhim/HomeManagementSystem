using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.ServiceRepository;
using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs.UserOperationClaim;

namespace Business.Abstract
{
    public interface IUserOperationClaimService : IService<UserOperationClaim>
    {
        Task<IResult> AddAsync(UserOperationClaimAddDto userOperationClaimAddDto);
        Task<IResult> DeleteAsync(UserOperationClaimDeleteDto userOperationClaimDeleteDto);

        Task<IDataResult<List<UserOperationClaimDetailDto>>> GetUserOperationClaimsDetail();


    }
}
