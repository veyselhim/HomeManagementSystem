using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs.CardDocument;

namespace Business.Abstract
{
    public interface ICardMongoDbService
    {
        Task<IDataResult<List<CardDocument>>> GetAllAsync();
        Task<IDataResult<CardDocument>> GetById(string id);
        Task<IDataResult<List<CardDocument>>> GetByUserId(int userId);

        Task<IResult> AddAsync(CardAddDocument cardAddDocument);
        Task<IResult> AddRangeAsync(List<CardAddDocument> cardAddDocuments);
        Task<IResult> DeleteAsync(string id);
        Task<IResult> UpdateAsync(CardUpdateDocument cardUpdateDocument);
    }
}
