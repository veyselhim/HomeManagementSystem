using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete;
using Entity.DTOs.Card;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CardValidator : AbstractValidator<CardAddDto>
    {
        public CardValidator()
        {
            RuleFor(x => x.UserId).NotNull();

            RuleFor(x => x.CardNumber).NotNull();
            RuleFor(x => x.CardNumber).CreditCard();

            RuleFor(x => x.Cvv).NotNull();
            RuleFor(x => x.Cvv).Length(3);

            RuleFor(x => x.ExpDate).NotNull();

        }
    }
}
