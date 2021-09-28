using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.EntityFramework
{
    public interface IRepository<T> where T : class 
    {
        List<T> GetAll();
        Task<List<T>> GetAllAsync();

        T GetById(Expression<Func<T, bool>> filter);
        Task<T> GetByIdAsync(Expression<Func<T, bool>> filter);

        List<T> Get(Expression<Func<T, bool>> filter);
        Task<List<T>> GetAsync(Expression<Func<T, bool>> filter);

        void Add(T entity);
        Task AddAsync(T entity);

        void Delete(T entity);
        Task DeleteAsync(T entity);

        void Update(T entity);
        Task UpdateAsync(T entity);


    }
}
