using System;
using Entity.Abstract;

namespace Entity.DTOs.DuesPayment
{
    public class DuesPaymentDetailDto : IDto
    {
        public int Id { get; set; }
        public DateTime InvoiceDate { get; set; }
        public double Amount { get; set; }
        public bool Status { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Phone { get; set; }
        public DateTime PayedDate { get; set; }
    }
}
