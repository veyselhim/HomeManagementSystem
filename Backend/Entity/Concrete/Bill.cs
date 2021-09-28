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
    public class Bill : IEntity
    {
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public DateTime InvoiceDate { get; set; }
        [Required]
        public double Amount { get; set; }
        [Required]
        [System.ComponentModel.DefaultValue(false)]
        public bool Status { get; set; }

    }
}
