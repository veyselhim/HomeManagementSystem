using System;
using Entity.Abstract;

namespace Entity.DTOs.DuesPayment
{
    public class DuesPaymentUpdateDto : IDto
    {
        public int Id { get; set; }
        public int DuesId { get; set; }
        public string CardDocumentId { get; set; }

        public DateTime PayedDate { get; set; }
        public bool Status { get; set; }

    }
}
