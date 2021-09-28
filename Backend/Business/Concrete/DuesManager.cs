using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity;
using Entity.Concrete;
using Entity.DTOs.Dues;

namespace Business.Concrete
{
    public class DuesManager : IDuesService
    {
        private readonly IDuesDal _duesDal;
        private readonly IMapper _mapper;
        public DuesManager(IDuesDal duesDal, IMapper mapper)
        {
            _duesDal = duesDal;
            _mapper = mapper;
        }

        public async Task<IDataResult<Dues>> GetByIdAsync(int id)
        {
           return new SuccessDataResult<Dues>(await _duesDal.GetByIdAsync(x => x.Id == id),Messages.DuesShown);
        }

      
        public async Task<IDataResult<List<DuesDto>>> GetAllAsync()
        {
            var result =  _mapper.Map<List<DuesDto>>(await _duesDal.GetAllAsync());

           return new SuccessDataResult<List<DuesDto>>(result,Messages.DuesShown);
        }

        public IDataResult<List<DuesDetailDto>> GetDuesDetails()
        {
            return new SuccessDataResult<List<DuesDetailDto>>(_duesDal.GetDuesDetails(), Messages.DuesShown);
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("IDuesService.Get")]
        [ValidationAspect(typeof(DuesValidator))]
        public async Task<IResult> AddWithDtoAsync(DuesAddDto duesAddDto)
        {
          await _duesDal.AddAsync(_mapper.Map<Dues>(duesAddDto));
           return new SuccessResult(Messages.DuesAdded);
        }

        [SecuredOperation("admin")]
        public async Task<IResult> UpdateWithDtoAsync(DuesUpdateDto duesUpdateDto)
        {
            await _duesDal.UpdateAsync(_mapper.Map<Dues>(duesUpdateDto));
            return new SuccessResult(Messages.DuesUpdated);
        }

        [SecuredOperation("admin")]
        public async Task<IResult> DeleteWithDtoAsync(DuesDeleteDto duesDeleteDto)
        {
           await _duesDal.DeleteAsync(_mapper.Map<Dues>(duesDeleteDto));
            return new SuccessResult(Messages.DuesDeleted);
        }

        public async Task<IDataResult<List<DuesDto>>> GetByUserId(int id)
        {
            var result = await _duesDal.GetAsync(x => x.UserId == id);

            return new SuccessDataResult<List<DuesDto>>(_mapper.Map<List<DuesDto>>(result), Messages.BillShown);
        }
    }
}
