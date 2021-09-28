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
using Core.Utilities.BusinessRules;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity;
using Entity.Concrete;
using Entity.DTOs;
using Entity.DTOs.Aparment;

namespace Business.Concrete
{
    public class ApartmentManager : IApartmentService
    {
        private readonly IApartmentDal _apartmentDal;
        private readonly IMapper _mapper;
        public ApartmentManager( IApartmentDal apartmentDal, IMapper mapper)
        {
            _apartmentDal = apartmentDal;
            _mapper = mapper;
        }


        public async Task<IDataResult<Apartment>> GetByIdAsync(int id)
        {
           return new SuccessDataResult<Apartment>(await _apartmentDal.GetByIdAsync(x => x.Id == id),Messages.ApartmentShown);
        }

        public async Task<IDataResult<List<Apartment>>> GetAllAsync()
        {
           return new SuccessDataResult<List<Apartment>>(await _apartmentDal.GetAllAsync(),Messages.ApartmentShown);
        }

        public IDataResult<List<ApartmentDetailDto>> GetApartmentDetails()
        {
            return new SuccessDataResult<List<ApartmentDetailDto>>(_apartmentDal.GetApartmentDetails(),Messages.ApartmentShown);
        }

        public async Task<IDataResult<ApartmentDetailDto>> GetApartmentDetail(int id)
        {
            return new SuccessDataResult<ApartmentDetailDto>(
              await  _apartmentDal.GetApartmentDetail(id, x => x.Id == id));
        }

        //[SecuredOperation("admin")]
        [ValidationAspect(typeof(ApartmentValidator))]
        public async Task<IResult> AddWithDtoAsync(ApartmentAddDto apartmentAddDto)
        {
            IResult result = BusinessRules.Run(CheckIfUserIdExists(apartmentAddDto.UserId));

            if (result != null)
            {
                return new ErrorResult(result.Message);
            }
            await _apartmentDal.AddAsync(_mapper.Map<Apartment>(apartmentAddDto));

            return new SuccessResult(Messages.ApartmentAdded);
        }

        public async Task<IResult> UpdateWithDtoAsync(ApartmentUpdateDto apartmentUpdateDto)
        {
            
           await _apartmentDal.UpdateAsync(_mapper.Map<Apartment>(apartmentUpdateDto));

            return new SuccessResult(Messages.ApartmentUpdated);
        }

        public async Task<IResult> DeleteWithDtoAsync(ApartmentDeleteDto apartmentDeleteDto)
        {
           await _apartmentDal.DeleteAsync(_mapper.Map<Apartment>(apartmentDeleteDto));

            return new SuccessResult(Messages.ApartmentDeleted);
        }

        public async Task<IDataResult<ApartmentAddDto>> GetByUserId(int id)
        {
            var result =await _apartmentDal.GetByIdAsync(x => x.UserId == id);

            return new SuccessDataResult<ApartmentAddDto>(_mapper.Map<ApartmentAddDto>(result),Messages.ApartmentShown);
        }

        private IResult CheckIfUserIdExists(int userId)
        {
           var result = _apartmentDal.Get(x=>x.UserId==userId).Any();
           if (result)
           {
               return new ErrorResult(Messages.UserAlreadyExists);
           }

           return new SuccessResult();
        }

    }
}
