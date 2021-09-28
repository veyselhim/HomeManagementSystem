using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.EntityFramework;
using DataAccess.Abstract;
using Entity;
using Entity.Concrete;
using Entity.DTOs;
using Entity.DTOs.Aparment;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class EfApartmentDal : EfRepository<Apartment> , IApartmentDal
    {
        private readonly ApsisContext _context;
        public EfApartmentDal(ApsisContext context) : base(context)
        {
            _context = context;
        }

        public List<ApartmentDetailDto> GetApartmentDetails()
        {
            using (_context)
            {
                var result = from apartment in  _context.Apartments 
                             join user in _context.Users on apartment.UserId equals user.Id
                             select new ApartmentDetailDto
                             {
                                 Id = apartment.UserId,
                                 Block = apartment.Block,
                                 DoorNumber = apartment.DoorNumber,
                                 Floor = apartment.Floor,
                                 Mail = user.Email,
                                 Name = user.FirstName,
                                 Status = apartment.Status,
                                 SurName = user.LastName,
                                 Type = apartment.Type
                             };

                return result.ToList();
            }
        }

        public async Task<ApartmentDetailDto> GetApartmentDetail(int id, Expression<Func<Apartment, bool>> filter = null)
        {
            using (_context)
            {
                var result = from apartment in filter == null ? _context.Apartments : _context.Apartments.Where(filter)
                    join user in _context.Users on apartment.UserId equals user.Id
                    select new ApartmentDetailDto()
                    {
                        Id = apartment.Id,
                        Block = apartment.Block,
                        DoorNumber = apartment.DoorNumber,
                        Floor = apartment.Floor,
                        Mail = user.Email,
                        Name = user.FirstName,
                        Status = apartment.Status,
                        SurName = user.LastName,
                        Type = apartment.Type
                    };

                return await result.FirstOrDefaultAsync();
            }
        }
    }
}
