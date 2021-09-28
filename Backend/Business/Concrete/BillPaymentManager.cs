using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs.BillPayment;

namespace Business.Concrete
{
    public class BillPaymentManager : IBillPaymentService
    {
        private readonly IBillPaymentDal _billPaymentDal;
        private readonly IMapper _mapper;
        public BillPaymentManager(IBillPaymentDal billPaymentDal, IMapper mapper)
        {
            _billPaymentDal = billPaymentDal;
            _mapper = mapper;
        }

        public async Task<IDataResult<BillPayment>> GetByIdAsync(int id)
        {
            return new SuccessDataResult<BillPayment>(await _billPaymentDal.GetByIdAsync(x => x.Id == id),Messages.BillPaymentShown);
        }

        public async Task<IDataResult<List<BillPayment>>> GetAllAsync()
        {
            return new SuccessDataResult<List<BillPayment>>(await _billPaymentDal.GetAllAsync(),Messages.BillPaymentShown);
        }

        public IDataResult<List<BillPaymentDetailDto>> GetBillPaymentDetails()
        {
            return new SuccessDataResult<List<BillPaymentDetailDto>>(_billPaymentDal.GetBillPaymentDetails(),Messages.BillPaymentShown);
        }

        [ValidationAspect(typeof(BillPaymentValidator))]
        public async Task<IResult> AddWithDtoAsync(BillPaymentAddDto billPaymentAddDto)
        {
           await _billPaymentDal.AddAsync(_mapper.Map<BillPayment>(billPaymentAddDto));
            return new SuccessResult(Messages.BillPaymentAdded);
        }

        public async Task<IResult> UpdateWithDtoAsync(BillPaymentUpdateDto billPaymentUpdateDto)
        {
           await _billPaymentDal.UpdateAsync(_mapper.Map<BillPayment>(billPaymentUpdateDto));
            return new SuccessResult(Messages.BillPaymentUpdated);
        }

        public async Task<IResult> DeleteWithDtoAsync(BillPaymentDeleteDto billPaymentDeleteDto)
        {
           await _billPaymentDal.DeleteAsync(_mapper.Map<BillPayment>(billPaymentDeleteDto));
            return new SuccessResult(Messages.BillPaymentDeleted);
        }
    }
}
