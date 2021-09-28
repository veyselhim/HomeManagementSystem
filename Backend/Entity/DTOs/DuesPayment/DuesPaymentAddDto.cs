using System;
using Entity.Abstract;

namespace Entity.DTOs.DuesPayment
{
    public class DuesPaymentAddDto : IDto
    {
        public int DuesId { get; set; }
        public string CardDocumentId { get; set; }

        public DateTime PayedDate { get; set; }
        public bool Status { get; set; }

    }
}
