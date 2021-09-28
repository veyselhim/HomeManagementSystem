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
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs.Bill;

namespace Business.Concrete
{
    public class BillManager : IBillService
    {
        private readonly IBillDal _billDal;
        private readonly IMapper _mapper;

        public BillManager(IBillDal billDal, IMapper mapper)
        {
            _billDal = billDal;
            _mapper = mapper;
        }

        public async Task<IDataResult<Bill>> GetByIdAsync(int id)
        {
            return new SuccessDataResult<Bill>(await _billDal.GetByIdAsync(x => x.Id == id),Messages.BillShown);

        }

        public async Task<IDataResult<List<BillDto>>> GetAllAsync()
        {
            var result = _mapper.Map<List<BillDto>>(await _billDal.GetAllAsync());
            return new SuccessDataResult<List<BillDto>>(result,Messages.BillShown);
        }

        public IDataResult<List<BillDetailDto>> GetBillDetails()
        {
            return new SuccessDataResult<List<BillDetailDto>>(_billDal.GetBillDetails(),Messages.BillShown);
        }

        public async Task<IDataResult<List<BillDetailDto>>> GetBillDetailsByUser(int userId)
        {
            return new SuccessDataResult<List<BillDetailDto>>(await _billDal.GetBillDetailsByUser( x => x.UserId == userId));
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(BillValidator))]
        public async Task<IResult> AddWithDtoAsync(BillAddDto billAddDto)
        {
           await _billDal.AddAsync(_mapper.Map<Bill>(billAddDto));

            return new SuccessResult(Messages.BillAdded);
        }

        [SecuredOperation("admin")]
        public async Task<IResult> UpdateWithDtoAsync(BillUpdateDto billUpdateDto)
        {
           await _billDal.UpdateAsync(_mapper.Map<Bill>(billUpdateDto));

            return new SuccessResult(Messages.BillUpdated);
        }

        [SecuredOperation("admin")]
        public async Task<IResult> DeleteWithDtoAsync(BillDeleteDto billDeleteDto)
        {
           await _billDal.AddAsync(_mapper.Map<Bill>(billDeleteDto));

            return new SuccessResult(Messages.BillDeleted);
        }

        public async Task<IDataResult<List<BillDto>>> GetByUserId(int id)
        {
          var result = await _billDal.GetAsync(x => x.UserId == id);

          return new SuccessDataResult<List<BillDto>>(_mapper.Map<List<BillDto>>(result) , Messages.BillShown);
        }
    }
}
