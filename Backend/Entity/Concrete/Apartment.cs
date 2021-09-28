using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstract;

namespace Entity.Concrete
{
    public class Apartment : IEntity
    {
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public int Floor { get; set; }
        [Required]
        public int DoorNumber { get; set; }
        [Required]
        public string Block { get; set; }
        [Required]
        public bool Status { get; set; }

    }
}
