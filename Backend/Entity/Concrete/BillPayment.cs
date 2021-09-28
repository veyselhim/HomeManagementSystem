using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Abstract;

namespace Entity.Concrete
{
    public class BillPayment : IEntity
    {
        public int Id { get; set; }

        [ForeignKey("BillId")]
        public virtual Bill Bill { get; set; }
        [Required]
        public int BillId { get; set; }

        [Required]
        public string CardDocumentId { get; set; }

        [Required]
        public DateTime PayedDate { get; set; }

        [Required]
        [System.ComponentModel.DefaultValue(true)]
        public bool Status { get; set; }


    }
}
