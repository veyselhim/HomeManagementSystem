using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.EntityFramework;
using Entity.Concrete;
using Entity.DTOs.Message;

namespace DataAccess.Abstract
{
    public interface IMessageDal : IRepository<Message>
    {
        List<MessageDetailDto> GetMessageDetails();
    }
}
