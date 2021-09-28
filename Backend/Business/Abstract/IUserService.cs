using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs.User;

namespace Business.Abstract
{
    public interface IUserService
    {
        Task<IDataResult<List<UserDetailDto>>> GetAllAsync();

        Task<List<OperationClaim>> GetClaimsAsync(User user);

        Task<IDataResult<UserDetailDto>> GetByIdAsync(int userId);

        Task<User> GetByEmailAsync(string email);

        Task<IDataResult<UserDetailDto>> GetUserByEmailAsync(string email);


        Task<IResult> AddAsync(User user);

        Task<IResult> DeleteWithDtoAsync(UserDeleteDto userDeleteDto);

        Task<IResult> EditProfileAsync(UserForUpdateDto useForUpdateDto , string password);



    }
}
