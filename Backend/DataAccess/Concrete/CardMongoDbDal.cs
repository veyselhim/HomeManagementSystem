using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Concrete.MongoDb;
using Microsoft.Extensions.Options;
using MongoDB.Data;

namespace DataAccess.Concrete
{
    public class CardMongoDbDal : MongoDbRepositoryBase<CardDocument> , ICardMongoDbDal
    {
        public CardMongoDbDal(IOptions<MongoDbSettings> options) : base(options)
        {
        }
    }
}
