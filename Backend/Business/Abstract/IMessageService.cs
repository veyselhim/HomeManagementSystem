using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.ServiceRepository;
using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs.Message;

namespace Business.Abstract
{
    public interface IMessageService : IService<Message>
    {
        IDataResult<List<MessageDetailDto>> GetMessageDetails();
        Task<IResult> AddWithDtoAsync(MessageAddDto messageAddDto);
        Task<IResult> DeleteWithDtoAsync(MessageDeleteDto messageDeleteDto);
    }
}
