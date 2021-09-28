using System;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstract;
using Entity.Concrete;

namespace Entity.DTOs.Bill
{
    public class BillAddDto : IDto
    {

        public int UserId { get; set; }
        public string Type { get; set; }
        public DateTime InvoiceDate { get; set; }
        public double Amount { get; set; }

        [System.ComponentModel.DefaultValue(false)]
        public bool Status { get; set; }
    }
}
