using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete;
using Entity.DTOs.BillPayment;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class BillPaymentValidator : AbstractValidator<BillPaymentAddDto>
    {
        public BillPaymentValidator()
        {
            RuleFor(x => x.BillId).NotNull();

            RuleFor(x => x.CardDocumentId).NotNull();

            RuleFor(x => x.PayedDate).NotNull();
        }
    }
}
