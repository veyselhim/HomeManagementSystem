using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.EntityFramework;
using Entity.Concrete;
using MongoDB.Data;

namespace DataAccess.Abstract
{
    public interface ICardMongoDbDal : IMongoDbRepository<CardDocument,string>
    {
    }
}
