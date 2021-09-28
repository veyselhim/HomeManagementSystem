using System;
using Entity.Abstract;

namespace Entity.DTOs.Bill
{
    public class BillUpdateDto :IDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Type { get; set; }
        public DateTime InvoiceDate { get; set; }
        public double Amount { get; set; }

        [System.ComponentModel.DefaultValue(false)]
        public bool Status { get; set; }
    }
}
