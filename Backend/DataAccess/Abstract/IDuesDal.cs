using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.EntityFramework;
using Core.Utilities.Results;
using Entity;
using Entity.Concrete;
using Entity.DTOs.Dues;

namespace DataAccess.Abstract
{
    public interface IDuesDal : IRepository<Dues>
    {
        List<DuesDetailDto> GetDuesDetails();

    }
}
