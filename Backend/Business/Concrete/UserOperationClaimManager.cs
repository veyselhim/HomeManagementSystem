using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs.UserOperationClaim;

namespace Business.Concrete
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        private readonly IUserOperationClaimDal _userOperationClaimDal;
        private readonly IMapper _mapper;
        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal, IMapper mapper)
        {
            _userOperationClaimDal = userOperationClaimDal;
            _mapper = mapper;
        }

        public async Task<IDataResult<UserOperationClaim>> GetByIdAsync(int id)
        {
            return new SuccessDataResult<UserOperationClaim>(await _userOperationClaimDal.GetByIdAsync(x => x.Id == id));
        }

        [SecuredOperation("admin")]
        public async Task<IDataResult<List<UserOperationClaim>>> GetAllAsync()
        {
           
            return new SuccessDataResult<List<UserOperationClaim>>(await _userOperationClaimDal.GetAllAsync());
        }

        [SecuredOperation("admin")]
        public async Task<IResult> AddAsync(UserOperationClaimAddDto userOperationClaimAddDto)
        {
           await _userOperationClaimDal.AddAsync(_mapper.Map<UserOperationClaim>(userOperationClaimAddDto));
            return new SuccessResult(Messages.UserOperationClaimAdded);
        }

        [SecuredOperation("admin")]
        public async Task<IResult> DeleteAsync(UserOperationClaimDeleteDto userOperationClaimDeleteDto)
        {
          await _userOperationClaimDal.DeleteAsync(_mapper.Map<UserOperationClaim>(userOperationClaimDeleteDto));
            return new SuccessResult(Messages.UserOperationClaimDeleted);
        }

        public async Task<IDataResult<List<UserOperationClaimDetailDto>>> GetUserOperationClaimsDetail()
        {

            return new SuccessDataResult<List<UserOperationClaimDetailDto>>(await _userOperationClaimDal.GetUserOperationClaimDetails());
        }
    }
}
