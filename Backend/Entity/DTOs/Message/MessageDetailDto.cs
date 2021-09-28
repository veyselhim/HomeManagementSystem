using System;
using Entity.Abstract;

namespace Entity.DTOs.Message
{
    public class MessageDetailDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
