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
using Entity.DTOs.Message;

namespace Business.Concrete
{
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _messageDal;
        private readonly IMapper _mapper;
        public MessageManager(IMessageDal messageDal, IMapper mapper)
        {
            _messageDal = messageDal;
            _mapper = mapper;
        }

        public async Task<IDataResult<Message>> GetByIdAsync(int id)
        {
            return new SuccessDataResult<Message>(await _messageDal.GetByIdAsync(x => x.Id == id), Messages.MessageShown);
        }
        [SecuredOperation("admin")]
        public async Task<IDataResult<List<Message>>> GetAllAsync()
        {
            return new SuccessDataResult<List<Message>>(await _messageDal.GetAllAsync(), Messages.MessageShown);
        }
        [SecuredOperation("admin")]
        public IDataResult<List<MessageDetailDto>> GetMessageDetails()
        {
            return new SuccessDataResult<List<MessageDetailDto>>(_messageDal.GetMessageDetails(),
                Messages.MessageShown);
        }

        [ValidationAspect(typeof(MessageValidator))]
        public async Task<IResult> AddWithDtoAsync(MessageAddDto messageAddDto)
        {
           await _messageDal.AddAsync(_mapper.Map<Message>(messageAddDto));
            return new SuccessResult(Messages.MessageAdded);
        }

        public async Task<IResult> DeleteWithDtoAsync(MessageDeleteDto messageDeleteDto)
        { 
           await _messageDal.DeleteAsync(_mapper.Map<Message>(messageDeleteDto));
            return new SuccessResult(Messages.MessageDeleted);
        }
    }
}
