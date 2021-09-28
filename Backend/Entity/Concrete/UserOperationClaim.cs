using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities;
using Entity.Abstract;

namespace Entity.Concrete
{
    public class UserOperationClaim : IEntity
    {
        public int Id { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [Required]
        public int UserId { get; set; }

        [ForeignKey("OperationClaimId")]
        public virtual OperationClaim OperationClaim { get; set; }
        [Required]
        public int OperationClaimId { get; set; }

    }
}
