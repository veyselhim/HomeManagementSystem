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
    public class DuesPayment : IEntity
    {
        public int Id { get; set; }

        [ForeignKey("DuesId")]
        public virtual Dues Dues { get; set; }
        [Required]
        public int DuesId { get; set; }

        [Required]
        public string CardDocumentId { get; set; }


        [Required]
        public DateTime PayedDate { get; set; }

        [Required]
        [System.ComponentModel.DefaultValue(true)]
        public bool Status { get; set; }


    }
}
