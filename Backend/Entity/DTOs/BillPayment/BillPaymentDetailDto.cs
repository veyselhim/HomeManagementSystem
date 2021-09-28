using System;
using Entity.Abstract;

namespace Entity.DTOs.BillPayment
{
    public class BillPaymentDetailDto : IDto
    {
        public string Type { get; set; }
        public DateTime InvoiceDate { get; set; }
        public double Amount { get; set; }
        public bool Status { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Phone { get; set; }
        public string CardNumber { get; set; }
        public string Cvv { get; set; }
        public DateTime ExpDate { get; set; }
        public DateTime PayedDate { get; set; }
    }
}
