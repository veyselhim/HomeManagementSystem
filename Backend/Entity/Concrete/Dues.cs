using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstract;

namespace Entity.Concrete
{
    public class Dues : IEntity
    {
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public DateTime InvoiceDate { get; set; }
        [Required]
        public double Amount { get; set; }

        [System.ComponentModel.DefaultValue(false)]
        [Required]
        public bool Status { get; set; }
    }
}
