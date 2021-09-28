using System;
using Entity.Abstract;

namespace Entity.DTOs.Message
{
    public class MessageAddDto : IDto
    {
        public int UserId { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
