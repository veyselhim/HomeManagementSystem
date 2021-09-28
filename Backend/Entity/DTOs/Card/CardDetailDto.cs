using System;
using Entity.Abstract;

namespace Entity.DTOs.Card
{
    public class CardDetailDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string CardNumber { get; set; }
        public string Cvv { get; set; }
        public DateTime ExpDate { get; set; }
    }
}
