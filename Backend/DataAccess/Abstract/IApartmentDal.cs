using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.EntityFramework;
using Entity;
using Entity.Concrete;
using Entity.DTOs;
using Entity.DTOs.Aparment;

namespace DataAccess.Abstract
{
    public interface IApartmentDal : IRepository<Apartment>
    {
        List<ApartmentDetailDto> GetApartmentDetails();
        Task<ApartmentDetailDto> GetApartmentDetail(int id, Expression<Func<Apartment, bool>> filter = null);


    }
}
