using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete;
using Entity.DTOs.DuesPayment;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class DuesPaymentValidator : AbstractValidator<DuesPaymentAddDto>
    {
        public DuesPaymentValidator()
        {
            RuleFor(x => x.CardDocumentId).NotNull();

            RuleFor(x => x.DuesId).NotNull();

            RuleFor(x => x.PayedDate).NotNull();


        }
    }
}
