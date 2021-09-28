using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete;
using Entity.DTOs.CardDocument;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CardDocumentValidator : AbstractValidator<CardAddDocument>
    {
        public CardDocumentValidator()
        {
            RuleFor(x => x.CardHolderName).NotNull();
            RuleFor(x => x.CardHolderName).MinimumLength(3);

            RuleFor(x => x.CardNumber).CreditCard();
            RuleFor(x => x.CardNumber).NotNull();

            RuleFor(x => x.Cvv).Length(3);
            RuleFor(x => x.Cvv).NotNull();

            RuleFor(x => x.ExpDate>DateTime.Now).NotNull();
            RuleFor(x => x.ExpDate).NotNull();





        }
    }
}
