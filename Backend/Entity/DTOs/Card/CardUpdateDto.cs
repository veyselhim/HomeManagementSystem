using System;
using Entity.Abstract;

namespace Entity.DTOs.Card
{
    public class CardUpdateDto : IDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CardNumber { get; set; }
        public string Cvv { get; set; }
        public DateTime ExpDate { get; set; }
    }
}
