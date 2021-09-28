using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Abstract;

namespace Entity.DTOs.User
{
    public class UserDeleteDto : IDto
    {
        public int Id { get; set; }

    }
}
