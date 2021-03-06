using System;
using Entity.Abstract;

namespace Entity.DTOs.Dues
{
    public class DuesDetailDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Mail { get; set; }
        public DateTime InvoiceDate { get; set; }
        public double Amount { get; set; }

        [System.ComponentModel.DefaultValue(false)]
        public bool Status { get; set; }
    }
}
