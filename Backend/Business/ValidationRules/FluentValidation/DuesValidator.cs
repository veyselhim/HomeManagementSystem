using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete;
using Entity.DTOs.Dues;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class DuesValidator : AbstractValidator<DuesAddDto>
    {
        public DuesValidator()
        {
            RuleFor(x => x.Amount).NotNull();

            RuleFor(x => x.InvoiceDate).NotNull();

            RuleFor(x => x.UserId).NotNull();

        }
    }
}
