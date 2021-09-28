using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.ServiceRepository;
using Core.Utilities.Results;
using Entity;
using Entity.Concrete;
using Entity.DTOs.Dues;

namespace Business.Abstract
{
    public interface IDuesService
    {
        Task<IResult> AddWithDtoAsync(DuesAddDto duesAddDto);
        Task<IResult> UpdateWithDtoAsync(DuesUpdateDto duesUpdateDto);
        Task<IResult> DeleteWithDtoAsync(DuesDeleteDto duesDeleteDto);

        IDataResult<List<DuesDetailDto>> GetDuesDetails();
        Task<IDataResult<List<DuesDto>>> GetAllAsync();
        Task<IDataResult<List<DuesDto>>> GetByUserId(int id);
        Task<IDataResult<Dues>> GetByIdAsync(int id);


    }
}
