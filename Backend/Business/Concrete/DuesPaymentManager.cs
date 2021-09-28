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
using Entity.DTOs;
using Entity.DTOs.DuesPayment;

namespace Business.Concrete
{
    public class DuesPaymentManager : IDuesPaymentService
    {
        private readonly IDuesPaymentDal _paymentDal;
        private readonly IMapper _mapper;
        public DuesPaymentManager(IDuesPaymentDal paymentDal, IMapper mapper)
        {
            _paymentDal = paymentDal;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(DuesPaymentValidator))]
       

        public async Task<IDataResult<DuesPayment>> GetByIdAsync(int id)
        {
           return new SuccessDataResult<DuesPayment>(await _paymentDal.GetByIdAsync(x => x.Id == id),Messages.DuesPaymentShown);
        }

        public async Task<IDataResult<List<DuesPayment>>> GetAllAsync()
        {
            return new SuccessDataResult<List<DuesPayment>>(await _paymentDal.GetAllAsync(),Messages.DuesPaymentShown);
        }


        public IDataResult<List<DuesPaymentDetailDto>> GetDuesPaymentDetails()
        {
            return new SuccessDataResult<List<DuesPaymentDetailDto>>(_paymentDal.GetDuesPaymentDetails(),
                Messages.DuesPaymentShown);
        }

        public async Task<IDataResult<List<DuesPaymentDetailDto>>> GetDuesPaymentDetailByDues(int duesId)
        {
          var result =await  _paymentDal.GetDuesPaymentDetailsByDues(x => x.DuesId == duesId);
          return new SuccessDataResult<List<DuesPaymentDetailDto>>(result);
        }

        // [SecuredOperation("admin")]
        [ValidationAspect(typeof(DuesPaymentValidator))]
        public async Task<IResult> AddWithDtoAsync(DuesPaymentAddDto duesPaymentAddDto)
        {
          
            await _paymentDal.AddAsync(_mapper.Map<DuesPayment>(duesPaymentAddDto));

            return new SuccessResult(Messages.DuesPaymentAdded);

        }

        public async Task<IResult> UpdateWithDtoAsync(DuesPaymentUpdateDto duesPaymentUpdateDto)
        {
           await _paymentDal.UpdateAsync(_mapper.Map<DuesPayment>(duesPaymentUpdateDto));
            return new SuccessResult(Messages.DuesPaymentUpdated);
        }

        public async Task<IResult> DeleteWithDtoAsync(DuesPaymentDeleteDto duesPaymentDeleteDto)
        {
           await _paymentDal.DeleteAsync(_mapper.Map<DuesPayment>(duesPaymentDeleteDto));
            return new SuccessResult(Messages.DuesPaymentDeleted);
        }
    }
}
