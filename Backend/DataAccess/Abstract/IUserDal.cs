using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.EntityFramework;
using Entity.Concrete;
using Entity.DTOs.User;

namespace DataAccess.Abstract
{
    public interface IUserDal : IRepository<User>
    {
        Task<List<OperationClaim>> GetClaims(User user);

    }
}
