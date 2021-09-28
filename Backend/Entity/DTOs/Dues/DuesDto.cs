using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Abstract;

namespace Entity.DTOs.Dues
{
    public class DuesDto : IDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public double Amount { get; set; }
        public bool Status { get; set; }
    }
}
