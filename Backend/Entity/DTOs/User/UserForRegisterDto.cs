using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Abstract;

namespace Entity.DTOs.User
{
    public class UserForRegisterDto : IDto
    {
        public string Email { get; set; }
       // public string Password { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public string Phone { get; set; }
        public string VehiclePlateNumber { get; set; }
        public DateTime JoinDate { get; set; }
        public bool Status { get; set; }
    }
}
