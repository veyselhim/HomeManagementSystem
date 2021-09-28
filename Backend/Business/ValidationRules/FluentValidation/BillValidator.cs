using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete;
using Entity.DTOs.Bill;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class BillValidator : AbstractValidator<BillAddDto>
    {
        public BillValidator()
        {
            RuleFor(x => x.Amount).NotNull();
            RuleFor(x => x.InvoiceDate).NotNull();
            RuleFor(x => x.UserId).NotNull();
            RuleFor(x => x.Type).NotNull();
        }
    }
}
