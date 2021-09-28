using System;
using Entity.Abstract;

namespace Entity.DTOs.BillPayment
{
    public class BillPaymentUpdateDto : IDto
    {
        public int Id { get; set; }
        public int BillId { get; set; }
        public string CardDocumentId { get; set; }
        public DateTime PayedDate { get; set; }
        public bool Status { get; set; }


    }
}
