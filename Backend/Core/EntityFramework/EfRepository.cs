using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Entity.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Core.EntityFramework
{
    public abstract class EfRepository<TEntity> : IRepository<TEntity> 
        where TEntity : class , IEntity

    {
        private readonly ApsisContext _context = null;

        private readonly DbSet<TEntity> _object;

        public EfRepository(ApsisContext context)
        {
            _context = context;
            _object = _context.Set<TEntity>();
        }

        public async Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            return filter == null
                ?await  _context.Set<TEntity>().ToListAsync()
                :await _context.Set<TEntity>().Where(filter).ToListAsync();
        }

        public void Add(TEntity entity)
        {

            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Added;
            _context.SaveChanges();


        }

        public async Task AddAsync(TEntity entity)
        {
            var addedEntity =  _context.Entry(entity);
            addedEntity.State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public void Delete(TEntity entity)
        {


            var deletedEntity = _context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            _context.SaveChanges();

        }

        public async Task DeleteAsync(TEntity entity)
        {

            var deletedEntity = _context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
           await _context.SaveChangesAsync();

        }


        public async Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _context.Set<TEntity>().SingleOrDefaultAsync(filter);
        }

        public List<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {

            return filter == null
                ? _context.Set<TEntity>().ToList()
                : _context.Set<TEntity>().Where(filter).ToList();

        }

        public  List<TEntity> GetAll()
        {
            return _object.ToList();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _object.ToListAsync();
        }

        public TEntity GetById(Expression<Func<TEntity, bool>> filter)
        {

            return _context.Set<TEntity>().SingleOrDefault(filter);


        }

        public void Update(TEntity entity)
        {

            var updatedEntity = _context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();

        }

        public async Task UpdateAsync(TEntity entity)
        {

            var updatedEntity =  _context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
