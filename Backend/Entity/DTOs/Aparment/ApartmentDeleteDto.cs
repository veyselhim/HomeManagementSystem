using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Abstract;

namespace Entity.DTOs.Aparment
{
    public class ApartmentDeleteDto : IDto
    {
        public int Id { get; set; }
    }
}
