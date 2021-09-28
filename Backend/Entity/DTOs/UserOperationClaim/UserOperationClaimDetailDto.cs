using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Abstract;

namespace Entity.DTOs.UserOperationClaim
{
    public class UserOperationClaimDetailDto : IDto
    {
        public string FirstName { get; set; }
        public string OperationClaimName { get; set; }
    }
}
