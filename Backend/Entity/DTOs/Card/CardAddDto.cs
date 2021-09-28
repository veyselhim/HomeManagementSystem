using System;
using Entity.Abstract;

namespace Entity.DTOs.Card
{
    public class CardAddDto : IDto
    {
        public int UserId { get; set; }
        public string CardNumber { get; set; }
        public string Cvv { get; set; }
        public DateTime ExpDate { get; set; }
    }
}
