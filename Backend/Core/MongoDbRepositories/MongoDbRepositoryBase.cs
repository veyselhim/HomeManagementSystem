using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Entity.Concrete;
using Entity.Concrete.MongoDb;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MongoDB.Data
{
    public abstract class MongoDbRepositoryBase<T> : IMongoDbRepository<T, string> where T : MongoDbEntity, new()
    {
        protected readonly IMongoCollection<T> Collection;
        private readonly MongoDbSettings settings;
        protected MongoDbRepositoryBase(IOptions<MongoDbSettings> options)
        {
            this.settings = options.Value;
            var client = new MongoClient(this.settings.ConnectionString);
            var db = client.GetDatabase(this.settings.Database);
            this.Collection = db.GetCollection<T>(typeof(T).Name.ToLowerInvariant());
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await Collection.Find(x => true).ToListAsync();
        }

        public async Task<List<T>> GetAllWithExpression(Expression<Func<T, bool>> predicate)
        {
            return await Collection.Find(predicate).ToListAsync();
        }

        public virtual Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return Collection.Find(predicate).FirstOrDefaultAsync();
        }

        public virtual Task<T> GetByIdAsync(string id)
        {
            return Collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public virtual async Task AddAsync(T entity)
        {
            await Collection.InsertOneAsync(entity);
            
        }

        public virtual async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await Collection.InsertManyAsync(entities);
        }

        public virtual async Task UpdateAsync(string id, T entity)
        {
            await Collection.FindOneAndReplaceAsync(x => x.Id == id, entity);
        }

        public virtual async Task UpdateAsync(T entity)
        {
            await Collection.ReplaceOneAsync(x=>x.Id==entity.Id,entity);
        }


        public virtual async Task<T> UpdateAsync(T entity, Expression<Func<T, bool>> predicate)
        {
            return await Collection.FindOneAndReplaceAsync(predicate, entity);
        }

        public virtual async Task<T> DeleteAsync(T entity)
        {
            return await Collection.FindOneAndDeleteAsync(x => x.Id == entity.Id);
        }

        public virtual async Task<T> DeleteAsync(string id)
        {
            return await Collection.FindOneAndDeleteAsync(x => x.Id == id);
        }

        public virtual async Task<T> DeleteAsync(Expression<Func<T, bool>> filter)
        {
            return await Collection.FindOneAndDeleteAsync(filter);
        }

       
    }
}
