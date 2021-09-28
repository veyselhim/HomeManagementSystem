using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete;
using Entity.DTOs.Message;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class MessageValidator : AbstractValidator<MessageAddDto>
    {
        public MessageValidator()
        {
            RuleFor(x => x.Content).NotNull().GreaterThan("20");

            RuleFor(x => x.UserId).NotNull();

            RuleFor(x => x.Subject).NotNull().GreaterThan("5");

            RuleFor(x => x.CreatedDate).NotNull();
        }
    }
}
