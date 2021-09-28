using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs.User;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly IMapper _mapper;
        public UserManager(IUserDal userDal, IMapper mapper)
        {
            _userDal = userDal;
            _mapper = mapper;
        }

        public async Task<IDataResult<List<UserDetailDto>>> GetAllAsync()
        {
            var result = _mapper.Map<List<UserDetailDto>>( await _userDal.GetAllAsync());
            
            return new SuccessDataResult<List<UserDetailDto>>( result, Messages.UserShown);
        }

        public async Task<IDataResult<UserDetailDto>> GetByIdAsync(int id)
        {
            var result =await _userDal.GetByIdAsync(x => x.Id == id);
            return new SuccessDataResult<UserDetailDto>(_mapper.Map<UserDetailDto>(result),Messages.UserShown);
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(UserValidator))]
        public async Task<IResult> AddAsync(User user)
        {

           await _userDal.AddAsync(user);

            return new SuccessResult(Messages.UserAdded);
        }

        [SecuredOperation("admin")]
        public async Task<IResult> DeleteWithDtoAsync(UserDeleteDto userDeleteDto)
        {
            await _userDal.DeleteAsync(_mapper.Map<User>(userDeleteDto));
            return new SuccessResult(Messages.UserDeleted);
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(UserUpdateValidator))]
        public async Task<IResult> EditProfileAsync(UserForUpdateDto userForUpdateDto,string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password,out passwordHash,out passwordSalt);

            var updatedUser = new User
            {
                Id = userForUpdateDto.Id,
                Email = userForUpdateDto.Email,
                FirstName = userForUpdateDto.FirstName,
                LastName = userForUpdateDto.LastName,
                Phone = userForUpdateDto.Phone,
                IdentityNumber = userForUpdateDto.IdentityNumber,
                VehiclePlateNumber = userForUpdateDto.VehiclePlateNumber,
                JoinDate = userForUpdateDto.JoinDate,
                Status = userForUpdateDto.Status,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
            await _userDal.UpdateAsync(updatedUser);

            return new SuccessDataResult<User>(updatedUser, Messages.UserUpdated);

        }

        public async Task<List<OperationClaim>> GetClaimsAsync(User user)
        {
            return await _userDal.GetClaims(user);

        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _userDal.GetByIdAsync(u => u.Email == email);
        }
        
        public async Task<IDataResult<UserDetailDto>> GetUserByEmailAsync(string email)
        {
            var result =await _userDal.GetByIdAsync(x => x.Email == email);
            return new SuccessDataResult<UserDetailDto>(_mapper.Map<UserDetailDto>(result),Messages.UserShown);
        }

    
    }
}
