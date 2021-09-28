using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete;
using Entity.DTOs.Aparment;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ApartmentValidator :  AbstractValidator<ApartmentAddDto>
    {
        public ApartmentValidator()
        {
            RuleFor(x => x.UserId).NotNull();
            RuleFor(x => x.Block).NotNull();
            RuleFor(x => x.Floor).NotNull();

            RuleFor(x => x.DoorNumber).NotNull();
            RuleFor(x => x.Type).NotNull();
        }
    }
}
