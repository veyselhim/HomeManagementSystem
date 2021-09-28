using System;
using System.ComponentModel.DataAnnotations;
using Entity.Abstract;

namespace Entity.Concrete
{
    public class User : IEntity
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string IdentityNumber { get; set; }
        [Required]
        public string Phone { get; set; }
        public string VehiclePlateNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }
        [Required]
        public byte[] PasswordHash { get; set; }
        [Required]
        public bool Status { get; set; }
        public DateTime JoinDate { get; set; }



    }
}
