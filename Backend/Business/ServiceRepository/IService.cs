using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;

namespace Business.ServiceRepository
{
    public interface IService<TEntity>
    {
        Task<IDataResult<TEntity>> GetByIdAsync(int id);

        Task<IDataResult<List<TEntity>>> GetAllAsync();

       

    }
}
