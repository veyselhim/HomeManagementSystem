using System;
using Entity.Abstract;

namespace Entity.DTOs.Dues
{
    public class DuesAddDto : IDto
    {
        public int UserId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public double Amount { get; set; }

        [System.ComponentModel.DefaultValue(false)]
        public bool Status { get; set; }
    }
}
