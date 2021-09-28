using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Abstract;

namespace Entity.DTOs.Aparment
{
    public class ApartmentUpdateDto :IDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Type { get; set; }
        public int Floor { get; set; }
        public int DoorNumber { get; set; }
        public string Block { get; set; }
        public bool Status { get; set; }
    }
}
