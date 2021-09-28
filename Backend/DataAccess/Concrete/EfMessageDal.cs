using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs.Message;

namespace DataAccess.Concrete
{
    public class EfMessageDal : EfRepository<Message> , IMessageDal
    {
        private readonly ApsisContext _context;
        public EfMessageDal(ApsisContext context) : base(context)
        {
            _context = context;
        }

        public List<MessageDetailDto> GetMessageDetails()
        {
            using (_context)
            {
                var result = from message in _context.Messages
                    join user in _context.Users on message.UserId equals user.Id
                    select new MessageDetailDto
                    {
                        Id = message.Id,
                        Name = user.FirstName,
                        SurName = user.LastName,
                        Content = message.Content,
                        Subject = message.Subject,
                        CreatedDate = message.CreatedDate
                    };
                return result.ToList();
            }
        }
    }
}
