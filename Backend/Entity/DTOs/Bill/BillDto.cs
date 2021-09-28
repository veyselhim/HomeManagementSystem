using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Abstract;

namespace Entity.DTOs.Bill
{
    public class BillDto : IDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Type { get; set; }
        public DateTime InvoiceDate { get; set; }
        public double Amount { get; set; }
        public bool Status { get; set; }
    }
}
