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
using Entity.DTOs.CardDocument;

namespace Business.Concrete
{
    public class CardMongoDbManager : ICardMongoDbService
    {
        private readonly ICardMongoDbDal _cardMongoDbDal;
        private readonly IMapper _mapper;
        public CardMongoDbManager(ICardMongoDbDal cardMongoDbDal, IMapper mapper)
        {
            _cardMongoDbDal = cardMongoDbDal;
            _mapper = mapper;
        }

        public async Task<IDataResult<List<CardDocument>>> GetAllAsync()
        {
            return new SuccessDataResult<List<CardDocument>>(await _cardMongoDbDal.GetAllAsync(), Messages.CardShown);
        }

        public async Task<IDataResult<CardDocument>> GetById(string id)
        {
            return new SuccessDataResult<CardDocument>(await _cardMongoDbDal.GetByIdAsync(id), Messages.CardShown);
        }

        public async Task<IDataResult<List<CardDocument>>> GetByUserId(int userId)
        {
          return new SuccessDataResult<List<CardDocument>>(await _cardMongoDbDal.GetAllWithExpression(x => x.UserId == userId),Messages.CardShown);
        }

        [ValidationAspect(typeof(CardDocumentValidator))]
        public async Task<IResult> AddAsync(CardAddDocument cardAddDocument)
        {
            var result = _mapper.Map<CardDocument>(cardAddDocument);
            await _cardMongoDbDal.AddAsync(result);
            return new SuccessResult(Messages.CardAdded);
        }


        [ValidationAspect(typeof(CardDocumentValidator))]
        public async Task<IResult> AddRangeAsync(List<CardAddDocument> cardAddDocuments)
        {

            var result = _mapper.Map<List<CardDocument>>(cardAddDocuments);
            await _cardMongoDbDal.AddRangeAsync(result);
            return new SuccessResult("Toplu ekleme yapıldı");
        }

     

        public async Task<IResult> DeleteAsync(string id)
        {
            await _cardMongoDbDal.DeleteAsync(id);
            return new SuccessResult(Messages.CardDeleted);
        }

        public async Task<IResult> UpdateAsync(CardUpdateDocument cardUpdateDocument)
        {
            var result = _mapper.Map<CardDocument>(cardUpdateDocument);
            await _cardMongoDbDal.UpdateAsync(result);
            return new SuccessResult(Messages.CardUpdated);
        }
    }
}
